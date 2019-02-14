using System;
using System.Collections;
using System.Text;
using System.Drawing;

namespace JAMReader
{
	/// <summary>
	/// BWRtfCoder ��ժҪ˵����
	/// </summary>
	public class BWRtfCoder
	{
		StringBuilder sbRtf = null;

		public Color ForeColor;
		public Font DefaultFont;
		public BWRtfCoder(Font fontDefault, Color colorFore)
		{
			
			this.ForeColor = colorFore;
			this.DefaultFont = fontDefault;
		}
		// �����
		private ArrayList alFonts = new ArrayList(5);
		private Hashtable htFonts = new Hashtable(5);
		// ��ɫ��
		private ArrayList alColors = new ArrayList(5);
		private Hashtable htColors = new Hashtable(5);

		protected string GetColorMark(Color c)
		{
			if (this.htColors[c] == null)
			{
				this.alColors.Add(c);
				this.htColors.Add(c, this.htColors.Count + 1);
			}
			int i = (int)this.htColors[c];
			return "\\cf" + i.ToString();
		}

		protected string GetFontMark(Font f)
		{
			if (this.htFonts[f] == null)
			{
				this.alFonts.Add(f);
				this.htFonts.Add(f, this.htFonts.Count);
			}
			int i = (int)this.htFonts[f];
			return "\\f" + i.ToString() + "\\fs" + ((int)f.Size * 2).ToString();
		}

		public byte[] Bytes
		{
			set
			{
				this.alColors.Clear();
				this.alFonts.Clear();
				this.htColors.Clear();
				this.htFonts.Clear();
				this.GetFontMark(this.DefaultFont);
				this.GetColorMark(this.ForeColor);

				#region �����ı�
				StringBuilder sb = new StringBuilder(value.Length * 4);
				sb.Append(this.GetFontMark(this.DefaultFont));
				int iOffset = 0;				
				int iLine = 0;
				Encoding en  = Encoding.GetEncoding(936);
				int iNextIndex = 0;
				while (iOffset < value.Length)
				{
					// �ҳ�һ��
					int i;
					
					for(i = iOffset; i < value.Length; i ++)
					{
						if (value[i] == 0x0a || value[i] == 0x0d)
						{
							break;
						}
					}
					
					// ����Ĵ���������Ӧdos, unix, mac�ȸ�ʽ�Ļس����з�ʽ
					if (i < value.Length)
					{

						if (value[i] == 0x0a)
						{
							if (i + 1 < value.Length && value[i + 1] == 0x0d )
							{
								// ��һ����Ȼ��ͬһ�س���
								iNextIndex = i + 1;
							}
							else
							{
								// ��һ������
								iNextIndex = i;
							}						
						}
						else if ( value[i] == 0x0d)
						{
							if (i + 1 < value.Length && value[i + 1] == 0x0a )
							{
								// ��һ����Ȼ��ͬһ�س���
								iNextIndex = i + 1;
							}
							else
							{
								// ��һ������
								iNextIndex = i;
							}						
						}
						else
						{
							iNextIndex = i;
						}
					}
					else
					{
						iNextIndex = i;
					}
					string line = en.GetString(value, iOffset, i - iOffset);
					if (line.StartsWith("..."))
					{
						// tag line
						sb.Append(this.GetColorMark(Color.Pink));						
					}
					else if (line.StartsWith("---"))
					{
						// ��������
						sb.Append(this.GetColorMark(Color.Yellow));						
					}
					else if (line.IndexOf(">", 0, 
						(line.Length >= 10 ? 10:line.Length)) != -1)
					{
						// ����
						sb.Append(this.GetColorMark(Color.LightGreen));
					}
					else if (line.StartsWith(" * Origin:") )
					{
						// Origin line
						sb.Append(this.GetColorMark(Color.Green));
					}
					else
					{
						// ����
						sb.Append(this.GetColorMark(Color.White));						
					}
					sb.Append(' ').Append(BWRtfCoder.CodeBytes(value, iOffset, i-1));
					sb.Append("\\par\r\n");
					iOffset  = iNextIndex + 1;
					iLine ++;				
				}
				
				#endregion
				// װ��rtf
// {\rtf1\ansi\ansicpg936\deff0\deflang1033\deflangfe2052{\fonttbl{\f0\fnil\fcharset134 \'d0\'c2\'cb\'ce\'cc\'e5;}{\f1\fnil\fcharset0 Microsoft Sans Serif;}{\f2\fnil\fcharset134 \'cb\'ce\'cc\'e5;}}
// {\colortbl ;\red32\green54\blue22;\red32\green24\blue22;}
// \viewkind4\uc1\pard\lang2052\cf1\f0\fs28 1234567890\cf0\f1\fs24 1234567890\f2\fs18 1234567890\cf2 12345\cf0 6789012345678901234567890\par
// }
				this.sbRtf = new StringBuilder(
					sb.Length + 100 + this.alColors.Count * 30 + this.alFonts.Count * 50);
				// rtfͷ
				sbRtf.Append(@"{\rtf1\ansi\ansicpg936\deff0\deflang1033\deflangfe2052");
				// rtf font table
				sbRtf.Append(@"{\fonttbl");
				for(int i = 0; i < this.alFonts.Count; i ++)
				{
					Font f = (Font)this.alFonts[i];
					sbRtf.Append(@"{\f").Append(i.ToString());
					sbRtf.Append(BWRtfCoder.GetRtfFontDefString(f));
					sbRtf.Append(@"}");
				}
				sbRtf.Append("}\r\n");

				// rtf color table
				sbRtf.Append(@"{\colortbl ;");
				for(int i =0; i < this.alColors.Count; i ++)
				{
					Color c = (Color)this.alColors[i];
					sbRtf.Append(BWRtfCoder.GetRtfColorDefString(c));
				}
				sbRtf.Append("}\r\n");
				// text
				sbRtf.Append(@"\viewkind4\uc1\pard\lang2052");
				sbRtf.Append(sb.ToString());
				// foot
				sbRtf.Append("}\r\n\0");
			}
		}

		public static string GetRtfColorDefString(Color c)
		{
			StringBuilder sb = new StringBuilder(25);
			sb.Append("\\red").Append(c.R.ToString());
			sb.Append("\\green").Append(c.G.ToString());
			sb.Append("\\blue").Append(c.B.ToString());
			sb.Append(";");
			return sb.ToString();
		}

		public static string GetRtfFontDefString(Font f)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(@"\fnil\fcharset134 ");
			sb.Append(BWRtfCoder.CodeString(f.Name));
			sb.Append(";");
			return sb.ToString();
		}

		public static string CodeString(string s)
		{
			if (s == null)
				return "";
			Encoding en = System.Text.Encoding.GetEncoding(936);
			byte[] arBytes = en.GetBytes(s);
			return CodeBytes(arBytes);
		}

		public static String CodeBytes(byte[] arbytes)
		{
			return CodeBytes(arbytes, 0, arbytes.Length -1);
		}

		public static String CodeBytes(byte[] arbytes, int iStartIndex, int iEndIndex)
		{
			if (iStartIndex >= iEndIndex)
				return "";
			StringBuilder sb = new StringBuilder((iEndIndex - iStartIndex) * 4);
			for (int i = iStartIndex; i <= iEndIndex && i < arbytes.Length; i ++)
			{
				if (arbytes[i] < 127)
				{
					if (arbytes[i] == 0x5c)
						sb.Append("\\");
					else
						sb.Append((char)arbytes[i]);
				}
				else
				{
					sb.Append("\\'");
					sb.Append(arbytes[i].ToString("x2"));
				}
			}
			return sb.ToString();
		}

		public string Rtf
		{
			get
			{
				return this.sbRtf.ToString();
			}
		}
	}
}
