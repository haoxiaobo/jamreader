using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Text;

namespace JAMReader
{
	/// <summary>
	/// 信区对象							  
	/// </summary>
	public class MailArea
	{
		public string sAreaname;
		public string sDes;
		public string sFullPathName;
		public string sFileName;
		public CDateTime dtCreateTime;
		public uint lMailCount = 0;

		//public JamMail[] mails;

		public MailArea(BinaryReader br)
		{			
			Encoding en = Encoding.GetEncoding(936);
			// 信区名
			byte[] arChars = br.ReadBytes(0x33);			
			this.sAreaname = en.GetString(arChars).Trim('\0', ' ');
			
			// 信区说明
			arChars = br.ReadBytes(0x3d);
			this.sDes =  en.GetString(arChars).Trim('\0', ' ');

			// 文件路径
			arChars = br.ReadBytes(0x70);
			this.sFullPathName =  en.GetString(arChars).Trim('\0', ' ');
			if (this.sFullPathName == null || this.sFullPathName.Length == 0 )
			{
				this.sFullPathName = this.sAreaname;
			}

			// 文件名
			string [] arPath = this.sFullPathName.Split('\\', ':');
			this.sFileName = arPath[arPath.Length - 1];


			// 抛弃字节部分．
			arChars = br.ReadBytes(0x230);			

		}

		public void ChangePath(string sNewPath)
		{
			if (sNewPath == null || sNewPath.Length == 0)
			{
				return;
			}
			if (sNewPath.EndsWith("\\"))
			{			
				this.sFullPathName = sNewPath + this.sFileName;
			}
			else
			{
				this.sFullPathName = sNewPath + '\\' + this.sFileName;
			}
		}


		/// <summary>
		/// 从一个文件里加载所有的信区对象
		/// </summary>
		/// <param name="sFileName"></param>
		/// <returns></returns>
		public static MailArea[] LoadAreasFromFile(string sFileName)
		{
			ArrayList alAreas = new ArrayList(30);	
			FileStream fs;
			try
			{
				fs = new FileStream(sFileName, FileMode.Open, FileAccess.Read);
			}
			catch
			{
				return null;
			}

			
			BinaryReader br = new BinaryReader(fs);
			fs.Seek(6, SeekOrigin.Begin);
			//读信区
			while(fs.Position < fs.Length)
			{
				MailArea m = new MailArea(br);
				if (m != null)
				{				
					alAreas.Add(m);
				}
			}

			br.Close();			
			MailArea[] arMailAreas = new MailArea[alAreas.Count];
			alAreas.CopyTo(arMailAreas);
			return arMailAreas;			
		}

		public bool LoadAreaInfo()
		{
			FileStream fs = null;
			try
			{			
				fs = new FileStream(this.sFullPathName + ".jhr", FileMode.Open, FileAccess.Read);
			}
			catch
			{
				this.sDes += "(Err)";
				return false;
			}
			BinaryReader br = new BinaryReader(fs);
			fs.Seek(4, SeekOrigin.Begin);
			this.dtCreateTime = new CDateTime(br.ReadUInt32());
			br.ReadInt32();
			this.lMailCount = br.ReadUInt32();
            
			br.Close();
			return true;
		}

		public JamMail[] LoadMails()
		{
			JamMail[] arMails = null;
			FileStream fs = null;
			try
			{			
				fs = new FileStream(this.sFullPathName + ".jhr", FileMode.Open, FileAccess.Read);
			}
			catch
			{
				return null;
			}
			BinaryReader br = new BinaryReader(fs);
			fs.Seek(0x400, SeekOrigin.Begin);
			ArrayList alMails = new ArrayList((int)this.lMailCount);
			while(fs.Position < fs.Length && alMails.Count < this.lMailCount)
			{
				JamMail jm = new JamMail();
				jm.sFileName = this.sFullPathName;
				try
				{				
					jm.LoadInfoFromStream(br);
				}
				catch
				{
					br.Close();
					arMails = new JamMail[alMails.Count];
					alMails.CopyTo(arMails);
					return arMails;
				}

				alMails.Add(jm);
			}
			br.Close();
			arMails = new JamMail[alMails.Count];
			alMails.CopyTo(arMails);
			return arMails;
		}
	}
}