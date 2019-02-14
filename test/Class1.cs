using System;
using System.Text;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
namespace test
{
	/// <summary>
	/// Class1 的摘要说明。
	/// </summary>
	class Class1
	{
		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			//
			// TODO: 在此处添加代码以启动应用程序
			//
			Font f = new Font("新宋体", 14);
			Color c = Color.FromArgb(123,32,54,22);
			Font f2 = new Font("楷体", 12);
			Color c2 = Color.FromArgb(123,32,24,22);
			Console.WriteLine(f.ToString());
			Console.WriteLine(c.ToString());

			Hashtable htFonts = new Hashtable();
			Hashtable htColors = new Hashtable();

			htFonts[f] = 1;
			htColors[c] = 2;
			if (htColors[c2] == null)
			{
				Console.WriteLine("NotFound!");
			}
			else
			{
				Console.WriteLine("Found!" + htColors[c2].ToString());
			}

			if (htFonts[f2] == null)
			{
				Console.WriteLine("NotFound!");
			}
			else
			{
				Console.WriteLine("Found!" + htFonts[f2].ToString());
			}

			byte b = 0x0d;
			Console.WriteLine(b.ToString());
			Console.WriteLine((char)b);
			Console.WriteLine(b.ToString("x2"));

			Console.ReadLine();
			

			RichTextBox r = new RichTextBox();
			r.Text = "123456789012345678901234567890123456789012345678901234567890";
			r.SelectionStart = 0;
			r.SelectionLength = 10;
			r.SelectionFont = f;
			r.SelectionColor = c;

			r.SelectionStart = 10;
			r.SelectionLength = 10;
			r.SelectionFont = f2;

			r.SelectionStart = 30;
			r.SelectionLength = 5;
			r.SelectionColor = c2;

			Console.WriteLine(r.Rtf);
			Console.ReadLine();

			ArrayList al = new ArrayList();
			al.Add(c);
			al.Add("1");
			//Console.WriteLine(al.IndexOf());

			Console.ReadLine();
		}
	}
}
