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
		// ������			4 byte			�ǹ̶����εĳ���.
		// 0				4 byte
		// δ֪            4 BYTE
		// δ֪            4 BYTE
		// 0				8 byte
		// 0				4 byte
		// ������(C)		4 byte
		// 0				4 byte
		// ������(C)		4 byte
		// ���ں�			4 byte
		// 00000001		4 byte
		// 0				4 byte
		// �ı���ʼ		4 byte
		// �ı�����		4 byte
		// -1				4 byte
		// 0				4 byte
		// 
		// 02 00 00 00		4 byte
		// �����˳�		4 byte
		// ������			float len
		// 03 00 00 00 	4 byte
		// �����˳�    	4 byte
		// ������			float len
		// 06 00 00 00 	4 byte
		// ���ⳤ			4 byte
		// ����			float len
		// 04 00 00 00		4 byte
		// ����վ����		4 byte
		// ����վ			float len
		// 05 00 00 00		4 byte
		// ����վ����		4 byte
		// ����վ			float len
		// 07 00 00 00		4 byte
		// д������		4 byte
		// д����			float len
		// d0 07 00 00 	float len
		// TID��			4 byte
		// TID				float len
		// d2 07 00 00 	float len
		// ת��·����		4 byte
		// ת��·��		float len

		public JamMail()
		{
			// 
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		public void LoadInfoFromStream(BinaryReader br)
		{
			// JAM...			4 byte
			br.ReadBytes(4);

			// 01 00 00 00		4 byte
			br.ReadInt32();

			// �ǹ̶����εĳ���	4 byte.
			int len = br.ReadInt32();
			
			// 0				4 byte
			br.ReadInt32();

			// δ֪            4 BYTE
			br.ReadInt32();

			// δ֪            4 BYTE
			br.ReadInt32();

			// 0				8 byte
			br.ReadBytes(8);
			// 0				4 byte
			br.ReadBytes(4);

			// ������(C)		4 byte
			this.dtSendTime = new CDateTime(br.ReadUInt32());

			// 0				4 byte
			br.ReadInt32();
			// ������(C)		4 byte
			this.dtReciveTime = new CDateTime(br.ReadUInt32());

			// ���ں�			4 byte
			this.iIndex = br.ReadUInt32();

			// 00000001		4 byte
			br.ReadInt32();
			// 0				4 byte
			br.ReadInt32();

			// �ı���ʼ		4 byte
			this.uStartOffset = br.ReadInt32();
			// �ı�����		4 byte
			this.uSize = br.ReadInt32();
			// -1				4 byte
			br.ReadInt32();
			// 0				4 byte
			br.ReadInt32();

			int iReaded = 0;
			Encoding en = Encoding.GetEncoding(936);
			while(iReaded < len)
			{				
				// �ֶ����
				int iItemType = br.ReadInt32();
				// �ֶγ���
				int iItemLen = br.ReadInt32();
				
				byte [] buf = br.ReadBytes(iItemLen);
				string s = en.GetString(buf).Trim('\0', ' ');
				switch(iItemType)
				{
					// 02 00 00 00	4 byte
					// �����˳�		4 byte
					// ������		float len
					case 2:
						this.sFrom = s;
						break;

					// 03 00 00 00 	4 byte
					// �����˳�    	4 byte
					// ������			float len
					case 3:
						this.sTo = s;
						break;
					// 06 00 00 00 	4 byte
					// ���ⳤ			4 byte
					// ����			float len
					case 6:
						this.sSubject = s;
						break;
					// 04 00 00 00		4 byte
					// sMsgID����		4 byte
					// sMsgID			float len
					case 4:
						this.sMsgID = s;
						break;
					// 05 00 00 00		4 byte
					// MSGID����		4 byte
					// ����վ			float len
					case 5:
						this.sSendSite = s;
						break;
					// 07 00 00 00		4 byte
					// д������		4 byte
					// д����			float len
					case 7:
						this.sWriter = s;
						break;
					// d0 07 00 00 	float len
					// TID��			4 byte
					// TID				float len
					case 0x07d0:
						this.sTID = s;
						break;
					// d2 07 00 00 	float len
					// ת��·����		4 byte
					// ת��·��		float len
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
				return en.GetBytes("���ļ�ʱ�����Ű��ļ������Ѿ����𻵣�");
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
			sb.Append ("������: ").Append(this.sFrom.PadRight(20, ' ')).Append("\t");
			sb.Append ("������: ").Append(this.sTo).Append("\r\n");
			sb.Append ("��  ��: ").Append(this.sSubject).Append("\r\n");

			return sb.ToString();
		}
	}
}
