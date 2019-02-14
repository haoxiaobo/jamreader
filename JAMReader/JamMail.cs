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
	/// 
	/// </summary>
	public class JamMail
	{
		public string sFrom = "";
		public string sTo = "";
		public CDateTime dtSendTime;
		public CDateTime dtReciveTime;
		public uint iIndex;
		public int uSize;
		public int uStartOffset;
		public string sSubject = "";
		public string sSendSite = "";
		public string sMsgID = "";
		public string sReciveSite = "";
		public string sWriter = "";
		public string sTID = "";
		public string sRoute = "";
		public string sFileName = "";
		// JAM...			4 byte
		// 01 00 00 00		4 byte
		// 索引长			4 byte			非固定长段的长度.
		// 0				4 byte
		// 未知            4 BYTE
		// 未知            4 BYTE
		// 0				8 byte
		// 0				4 byte
		// 发日期(C)		4 byte
		// 0				4 byte
		// 收日期(C)		4 byte
		// 包内号			4 byte
		// 00000001		4 byte
		// 0				4 byte
		// 文本起始		4 byte
		// 文本长度		4 byte
		// -1				4 byte
		// 0				4 byte
		// 
		// 02 00 00 00		4 byte
		// 发信人长		4 byte
		// 发信人			float len
		// 03 00 00 00 	4 byte
		// 收信人长    	4 byte
		// 收信人			float len
		// 06 00 00 00 	4 byte
		// 主题长			4 byte
		// 主题			float len
		// 04 00 00 00		4 byte
		// 发信站长度		4 byte
		// 发信站			float len
		// 05 00 00 00		4 byte
		// 发信站长度		4 byte
		// 发信站			float len
		// 07 00 00 00		4 byte
		// 写信器长		4 byte
		// 写信器			float len
		// d0 07 00 00 	float len
		// TID长			4 byte
		// TID				float len
		// d2 07 00 00 	float len
		// 转信路径长		4 byte
		// 转信路径		float len

		public JamMail()
		{
			// 
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public void LoadInfoFromStream(BinaryReader br)
		{
			// JAM...			4 byte
			br.ReadBytes(4);

			// 01 00 00 00		4 byte
			br.ReadInt32();

			// 非固定长段的长度	4 byte.
			int len = br.ReadInt32();
			
			// 0				4 byte
			br.ReadInt32();

			// 未知            4 BYTE
			br.ReadInt32();

			// 未知            4 BYTE
			br.ReadInt32();

			// 0				8 byte
			br.ReadBytes(8);
			// 0				4 byte
			br.ReadBytes(4);

			// 发日期(C)		4 byte
			this.dtSendTime = new CDateTime(br.ReadUInt32());

			// 0				4 byte
			br.ReadInt32();
			// 收日期(C)		4 byte
			this.dtReciveTime = new CDateTime(br.ReadUInt32());

			// 包内号			4 byte
			this.iIndex = br.ReadUInt32();

			// 00000001		4 byte
			br.ReadInt32();
			// 0				4 byte
			br.ReadInt32();

			// 文本起始		4 byte
			this.uStartOffset = br.ReadInt32();
			// 文本长度		4 byte
			this.uSize = br.ReadInt32();
			// -1				4 byte
			br.ReadInt32();
			// 0				4 byte
			br.ReadInt32();

			int iReaded = 0;
			Encoding en = Encoding.GetEncoding(936);
			while(iReaded < len)
			{				
				// 字段类别
				int iItemType = br.ReadInt32();
				// 字段长度
				int iItemLen = br.ReadInt32();
				
				byte [] buf = br.ReadBytes(iItemLen);
				string s = en.GetString(buf).Trim('\0', ' ');
				switch(iItemType)
				{
					// 02 00 00 00	4 byte
					// 发信人长		4 byte
					// 发信人		float len
					case 2:
						this.sFrom = s;
						break;

					// 03 00 00 00 	4 byte
					// 收信人长    	4 byte
					// 收信人			float len
					case 3:
						this.sTo = s;
						break;
					// 06 00 00 00 	4 byte
					// 主题长			4 byte
					// 主题			float len
					case 6:
						this.sSubject = s;
						break;
					// 04 00 00 00		4 byte
					// sMsgID长度		4 byte
					// sMsgID			float len
					case 4:
						this.sMsgID = s;
						break;
					// 05 00 00 00		4 byte
					// MSGID长度		4 byte
					// 发信站			float len
					case 5:
						this.sSendSite = s;
						break;
					// 07 00 00 00		4 byte
					// 写信器长		4 byte
					// 写信器			float len
					case 7:
						this.sWriter = s;
						break;
					// d0 07 00 00 	float len
					// TID长			4 byte
					// TID				float len
					case 0x07d0:
						this.sTID = s;
						break;
					// d2 07 00 00 	float len
					// 转信路径长		4 byte
					// 转信路径		float len
					case 0x07d2:
						this.sRoute = s;
						break;
					default:
						break;

				}
				iReaded += 4 + 4 + iItemLen;
			}
			return;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sString"></param>
		/// <param name="bInFrom"></param>
		/// <param name="bInTo"></param>
		/// <param name="bInSub"></param>
		/// <param name="bInText"></param>
		/// <param name="bCaseLess"></param>
		/// <param name="bRegule"></param>
		/// <returns></returns>
		public bool FindText(string sString, bool bInFrom, 
			bool bInTo, bool bInSub, bool bInText, bool bCaseLess, bool bRegule)
		{			
			string sFindText = bCaseLess ? sString.ToLower(): sString;			
			string s;
			if (bInFrom)
			{
				s = bCaseLess ? this.sFrom.ToLower(): this.sFrom;
				if (s.IndexOf(sFindText) != -1)
				{
					return true;
				}
			}
			if (bInTo)
			{				
				s = bCaseLess ? this.sTo.ToLower() : this.sTo;
				if (s.IndexOf(sFindText) != -1)
				{
					return true;
				}
			}
			if (bInSub)
			{
				s = bCaseLess ? this.sSubject.ToLower() : this.sSubject;
				if (s.IndexOf(sFindText) != -1)
				{
					return true;
				}
			}

			if (bInText)
			{	
				s = bCaseLess ? this.LoadText().ToLower() : this.LoadText();
				if (s.IndexOf(sFindText) != -1)
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public string LoadText()
		{
			byte [] buf = this.LoadBytes();
			Encoding en = Encoding.GetEncoding(936);
			StringBuilder sb = new StringBuilder(buf.Length);
			sb.Append(en.GetString(buf));
			//sb.Replace("\r", "\r\n");
				
			return sb.ToString();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public byte[] LoadBytes()
		{
			FileStream fs = null;
			try
			{			
				fs = new FileStream(this.sFileName + ".jdt", FileMode.Open, FileAccess.Read);
			}
			catch
			{
				Encoding en = Encoding.GetEncoding(936);
				return en.GetBytes("读文件时出错．信包文件可能已经被损坏．");
			}
			BinaryReader br = new BinaryReader(fs);
			fs.Seek(this.uStartOffset, SeekOrigin.Begin);
			byte [] buf = br.ReadBytes(this.uSize);
			br.Close();
			return buf;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public string GetInfoString()
		{
			StringBuilder sb = new StringBuilder(200);
			sb.Append ("发信人: ").Append(this.sFrom.PadRight(20, ' ')).Append("\t");
			sb.Append ("收信人: ").Append(this.sTo).Append("\r\n");
			sb.Append ("主  题: ").Append(this.sSubject).Append("\r\n");

			return sb.ToString();
		}
	}
}
