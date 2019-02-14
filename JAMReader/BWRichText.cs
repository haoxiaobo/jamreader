//#define BLK	 //直接处理的代码．
//#define VER10  //多线程代码
//#define VER11　//加行方式代码
//#define VER12  //双组件处理
#define BWRTF	// BWRTF编码

using System;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace JAMReader
{
	/// <summary>
	/// BWRichText 的摘要说明。
	/// </summary>
	public class BWRichText : System.Windows.Forms.RichTextBox
	{
		public bool bIfHighColor = true;
		public BWRichText()
		{
		}
#if VER10
		#region VER1.0 code
		private Thread thread = null;

		public void ProcessHighColor()
		{
			try
			{
				int iOffset = 0;
				string [] Lines = (string[])this.Lines.Clone();

				StringBuilder sb = new StringBuilder(this.Lines.Length * 30);

				for (int i = 0; i < Lines.Length; i ++)
				{
#if DEBUG
					DateTime dtStart = DateTime.Now;	
#endif
					this.SelectionLength = 	Lines[i].Length;
					this.SelectionStart = iOffset;

					if (Lines[i].StartsWith("..."))
					{
						// tag line
						this.SelectionColor = Color.Pink;
					}
					else if (Lines[i].StartsWith("---"))
					{
						// 高亮部分
						this.SelectionColor = Color.Yellow;
					}
					else if (Lines[i].IndexOf(">", 0, 
						(Lines[i].Length >= 10 ? 10:Lines[i].Length)) != -1)
					{
						// 引文
						this.SelectionColor = Color.LightGreen;
					}
					else if (Lines[i].StartsWith(" * Origin:") )
					{
						// Origin line
						this.SelectionColor = Color.Green;
					}
					else
					{
						// 正文
						this.SelectionColor = Color.White;
					}

					iOffset += Lines[i].Length + 1;
#if DEBUG
					TimeSpan ts = DateTime.Now - dtStart;
					sb.Append("Line[").Append(i.ToString()).Append("]:").Append(ts.TotalMilliseconds.ToString()+"\r\n");	
#endif
				}
#if DEBUG
				Trace.WriteLine(sb.ToString());
#endif
				
			}
			catch(ThreadAbortException tae)
			{
				return;	
			}
			catch(Exception e)
			{
				return;
			}
		}
		#endregion
#endif
#if VER12
		#region VER1.2 code
		private Thread thread = null;
		
		public void ProcessHighColor()
		{
			RichTextBox bk = null;
			try
			{
				lock(this)
				{
					bk = new RichTextBox();
					bk.ForeColor = this.ForeColor;
					bk.BackColor = this.BackColor;			
					bk.Font = this.Font;

					bk.Text = this.Text;

				}
				int iOffset = 0;
				string [] Lines = (string[])bk.Lines.Clone();

				StringBuilder sb = new StringBuilder(bk.Lines.Length * 30);

				for (int i = 0; i < Lines.Length; i ++)
				{
					bk.SelectionLength = Lines[i].Length;
					bk.SelectionStart = iOffset;

					if (Lines[i].StartsWith("..."))
					{
						// tag line
						bk.SelectionColor = Color.Pink;
					}
					else if (Lines[i].StartsWith("---"))
					{
						// 高亮部分
						bk.SelectionColor = Color.Yellow;
					}
					else if (Lines[i].IndexOf(">", 0, 
						(Lines[i].Length >= 10 ? 10:Lines[i].Length)) != -1)
					{
						// 引文
						bk.SelectionColor = Color.LightGreen;
					}
					else if (Lines[i].StartsWith(" * Origin:") )
					{
						// Origin line
						bk.SelectionColor = Color.Green;
					}
					else
					{
						// 正文
						bk.SelectionColor = Color.White;
					}

					iOffset += Lines[i].Length + 1;
				}

				lock(this)
				{
					int iSelectStart = this.SelectionStart;
					int iSelectLength = this.SelectionLength;
					this.Rtf = bk.Rtf;					
					this.SelectionStart = iSelectStart;
					this.SelectionLength = iSelectLength;
				}
				return;
			}
			catch(ThreadAbortException tae)
			{
				if (bk != null)
					bk.Dispose();
				return;	
			}
			catch(Exception e)
			{
				if (bk != null)
					bk.Dispose();
				return;
			}
			
		}
		#endregion
#endif
#if BWRTF
		private BWRtfCoder bwrtfcoder = null; 
#endif
		public override string Text
		{
			get
			{
				// TODO:  添加 BWRichText.Text getter 实现
				return base.Text;
			}
			set
			{
#if BWRTF
				
				if (this.bIfHighColor)
				{				
					bwrtfcoder = new BWRtfCoder(this.Font, this.ForeColor);
					if (value == null)
					{
						bwrtfcoder.Bytes = Encoding.GetEncoding(936).GetBytes("");
					}
					else
					{
						bwrtfcoder.Bytes = Encoding.GetEncoding(936).GetBytes(value);
					}					
					this.Rtf = bwrtfcoder.Rtf;
				}
				else
				{
					base.Text = value;
				}
#elif BLK
				#region Block Code
				base.Text = value;
				int iOffset = 0;
				string [] Lines = (string[])this.Lines.Clone();
#if DEBUG
				StringBuilder sb = new StringBuilder(this.Lines.Length * 30);
#endif
				for (int i = 0; i < Lines.Length; i ++)
				{
#if DEBUG
					DateTime dtStart = DateTime.Now;
#endif
					this.SelectionLength = Lines[i].Length;
					this.SelectionStart = iOffset;

					if (Lines[i].StartsWith("..."))
					{
						// tag line
						this.SelectionColor = Color.Pink;
					}
					else if (Lines[i].StartsWith("---"))
					{
						// 高亮部分
						this.SelectionColor = Color.Yellow;
					}
					else if (Lines[i].IndexOf(">", 0, 
						(Lines[i].Length >= 10 ? 10:Lines[i].Length)) != -1)
					{
						// 引文
						this.SelectionColor = Color.LightGreen;
					}
					else if (Lines[i].StartsWith(" * Origin:") )
					{
						// Origin line
						this.SelectionColor = Color.Green;
					}
					else
					{
						// 正文
						this.SelectionColor = Color.White;
					}

					iOffset += Lines[i].Length + 1;
					this.ClearUndo();
#if DEBUG
					TimeSpan ts = DateTime.Now - dtStart;
					sb.Append("Line[").Append(i.ToString()).Append("]:").Append(ts.TotalMilliseconds.ToString()+"\r\n");
#endif
				}
#if DEBUG
				Trace.WriteLine(sb.ToString());
#endif
				#endregion
#elif VER10 || VER12
				#region VER10 CODE
				// 如果线程没有停止，那么设法停止他
				lock(this)
				{
					if (this.thread != null 
//						&&
//						this.thread.ThreadState != System.Threading.ThreadState.Aborted &&					 
//						this.thread.ThreadState != System.Threading.ThreadState.Stopped && 
//						this.thread.ThreadState != System.Threading.ThreadState.Unstarted
						)
					{
						this.thread.Abort();
						this.thread.Join();
					}
				}
				
				if (value == null || value.Length == 0)
				{					
					base.Text = value;
					return;
				}
				lock(this)
				{
					base.Text = value;

					if (this.bIfHighColor )
					{
						this.thread = new Thread(new ThreadStart(this.ProcessHighColor));
						this.thread.Start();
						//this.ProcessHighColor();
					}
					else
					{
						this.SelectionStart = 0;
						this.SelectionLength = this.Text.Length;
						this.SelectionColor = this.ForeColor;
					}
				}
				#endregion
#elif VER11
				#region VER11 Code
				if(this.bIfHighColor)
				{
					base.Text = "";
				
					int iOffset = 0;
					int iNextOffset = 0;
					int iLine = 0;
					while (iOffset < value.Length)
					{
						DateTime dtStart = DateTime.Now;	

						this.SelectionStart = iOffset;
						this.SelectionLength = 0;
						iNextOffset = value.IndexOf('\n', iOffset, value.Length - iOffset);
						if (iNextOffset == -1)
							break;
						string line = value.Substring(iOffset, iNextOffset - iOffset);
						if (line.StartsWith("..."))
						{
							// tag line
							this.SelectionColor = Color.Pink;
						}
						else if (line.StartsWith("---"))
						{
							// 高亮部分
							this.SelectionColor = Color.Yellow;
						}
						else if (line.IndexOf(">", 0, 
							(line.Length >= 10 ? 10:line.Length)) != -1)
						{
							// 引文
							this.SelectionColor = Color.LightGreen;
						}
						else if (line.StartsWith(" * Origin:") )
						{
							// Origin line
							this.SelectionColor = Color.Green;
						}
						else
						{
							// 正文
							this.SelectionColor = Color.White;
						}
						iOffset  = iNextOffset + 1;
						iLine ++;
						this.AppendText(line);
						TimeSpan ts = DateTime.Now - dtStart;
						sb.Append("Line[").Append(iLine.ToString()).Append("]:").Append(ts.TotalMilliseconds.ToString()+"\r\n");	
					
					}
#if DEBUG
				Trace.WriteLine(sb.ToString());
#endif
				}
				else
				{
					base.Text=value;
				}
				#endregion
#endif				
				
				this.SelectionStart = 0;
				this.SelectionLength = 0;
				return;
			}
		}
	
		protected override void OnLinkClicked(LinkClickedEventArgs e)
		{
			// TODO:  添加 BWRichText.OnLinkClicked 实现
			// base.OnLinkClicked (e);
			Process.Start(e.LinkText);
		}
	}
}
