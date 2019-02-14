using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace JAMReader
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Label lbInfo;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.StatusBarPanel statusBarPanel3;
		private System.Windows.Forms.StatusBarPanel statusBarPanel4;
		private System.Windows.Forms.StatusBarPanel statusBarPanel5;
		private System.Windows.Forms.StatusBarPanel statusBarPanel6;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ListView lvArea;
		private System.Windows.Forms.ListView lvMail;
		private System.Windows.Forms.MenuItem mnExit;
		private System.Windows.Forms.MenuItem mnOpenJam;
		private System.Windows.Forms.MenuItem mnAbout;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem mnFind;
		private System.Windows.Forms.MenuItem mnFindNext;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem8;
		private JAMReader.BWRichText txtContent;
		private RegMan Settings = new RegMan("HaoXiaoBo", "JamReader", "1.0");
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem mnHighColor;
		private System.Windows.Forms.MenuItem mnHelp;
		private System.Windows.Forms.MenuItem mnReg;
		private System.Windows.Forms.MenuItem menuItem11;

		protected FrmFind frmFind = new FrmFind();
		protected int iFindRecord = 0;
		protected int iFindArea = 0;
		public int iCurrentArea = -1;
        public JamMail[] arCurrentMails = null;
        private IContainer components;

		public Form1()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel4 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel5 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel6 = new System.Windows.Forms.StatusBarPanel();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.mnOpenJam = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.mnExit = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.mnHighColor = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.mnFind = new System.Windows.Forms.MenuItem();
            this.mnFindNext = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.mnHelp = new System.Windows.Forms.MenuItem();
            this.mnReg = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.mnAbout = new System.Windows.Forms.MenuItem();
            this.lvArea = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.lvMail = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.lbInfo = new System.Windows.Forms.Label();
            this.txtContent = new JAMReader.BWRichText();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel6)).BeginInit();
            this.SuspendLayout();
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 355);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3,
            this.statusBarPanel4,
            this.statusBarPanel5,
            this.statusBarPanel6});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(712, 22);
            this.statusBar1.TabIndex = 6;
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 107;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Name = "statusBarPanel2";
            // 
            // statusBarPanel3
            // 
            this.statusBarPanel3.Name = "statusBarPanel3";
            // 
            // statusBarPanel4
            // 
            this.statusBarPanel4.Name = "statusBarPanel4";
            // 
            // statusBarPanel5
            // 
            this.statusBarPanel5.Name = "statusBarPanel5";
            // 
            // statusBarPanel6
            // 
            this.statusBarPanel6.Name = "statusBarPanel6";
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem9,
            this.menuItem4,
            this.menuItem3,
            this.menuItem2});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnOpenJam,
            this.menuItem5,
            this.mnExit});
            this.menuItem1.Text = "文件";
            // 
            // mnOpenJam
            // 
            this.mnOpenJam.Index = 0;
            this.mnOpenJam.Text = "打开信库...";
            this.mnOpenJam.Click += new System.EventHandler(this.mnOpenJam_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 1;
            this.menuItem5.Text = "-";
            // 
            // mnExit
            // 
            this.mnExit.Index = 2;
            this.mnExit.Text = "退出";
            this.mnExit.Click += new System.EventHandler(this.mnExit_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 1;
            this.menuItem9.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnHighColor});
            this.menuItem9.Text = "查看";
            // 
            // mnHighColor
            // 
            this.mnHighColor.Checked = true;
            this.mnHighColor.Index = 0;
            this.mnHighColor.Text = "使用配色方案";
            this.mnHighColor.Click += new System.EventHandler(this.mnHighColor_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 2;
            this.menuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem6,
            this.menuItem7,
            this.menuItem8});
            this.menuItem4.Text = "导出";
            // 
            // menuItem6
            // 
            this.menuItem6.Enabled = false;
            this.menuItem6.Index = 0;
            this.menuItem6.Text = "导出当前信到文本文件...";
            // 
            // menuItem7
            // 
            this.menuItem7.Enabled = false;
            this.menuItem7.Index = 1;
            this.menuItem7.Text = "导出当前信区到文本文件";
            // 
            // menuItem8
            // 
            this.menuItem8.Enabled = false;
            this.menuItem8.Index = 2;
            this.menuItem8.Text = "导出全部信区到文本文件";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 3;
            this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnFind,
            this.mnFindNext});
            this.menuItem3.Text = "查找";
            // 
            // mnFind
            // 
            this.mnFind.Index = 0;
            this.mnFind.Shortcut = System.Windows.Forms.Shortcut.CtrlF;
            this.mnFind.Text = "查找...";
            this.mnFind.Click += new System.EventHandler(this.mnFind_Click);
            // 
            // mnFindNext
            // 
            this.mnFindNext.Index = 1;
            this.mnFindNext.Shortcut = System.Windows.Forms.Shortcut.F3;
            this.mnFindNext.Text = "查找下一个";
            this.mnFindNext.Click += new System.EventHandler(this.mnFindNext_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 4;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnHelp,
            this.mnReg,
            this.menuItem11,
            this.mnAbout});
            this.menuItem2.Text = "帮助";
            // 
            // mnHelp
            // 
            this.mnHelp.Index = 0;
            this.mnHelp.Text = "使用说明...";
            this.mnHelp.Click += new System.EventHandler(this.mnHelp_Click);
            // 
            // mnReg
            // 
            this.mnReg.Index = 1;
            this.mnReg.Text = "注册说明...";
            this.mnReg.Click += new System.EventHandler(this.mnReg_Click);
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 2;
            this.menuItem11.Text = "-";
            // 
            // mnAbout
            // 
            this.mnAbout.Index = 3;
            this.mnAbout.Text = "关于...";
            this.mnAbout.Click += new System.EventHandler(this.mnAbout_Click);
            // 
            // lvArea
            // 
            this.lvArea.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader8});
            this.lvArea.Dock = System.Windows.Forms.DockStyle.Left;
            this.lvArea.FullRowSelect = true;
            this.lvArea.GridLines = true;
            this.lvArea.HideSelection = false;
            this.lvArea.Location = new System.Drawing.Point(0, 0);
            this.lvArea.MultiSelect = false;
            this.lvArea.Name = "lvArea";
            this.lvArea.Size = new System.Drawing.Size(250, 355);
            this.lvArea.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvArea.TabIndex = 1;
            this.lvArea.UseCompatibleStateImageBehavior = false;
            this.lvArea.View = System.Windows.Forms.View.Details;
            this.lvArea.DoubleClick += new System.EventHandler(this.lvArea_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "信区";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "说明";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "信数";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(250, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 355);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // lvMail
            // 
            this.lvMail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.lvMail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader9,
            this.columnHeader6,
            this.columnHeader7});
            this.lvMail.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvMail.FullRowSelect = true;
            this.lvMail.GridLines = true;
            this.lvMail.HideSelection = false;
            this.lvMail.Location = new System.Drawing.Point(253, 0);
            this.lvMail.Name = "lvMail";
            this.lvMail.Size = new System.Drawing.Size(459, 190);
            this.lvMail.TabIndex = 2;
            this.lvMail.UseCompatibleStateImageBehavior = false;
            this.lvMail.View = System.Windows.Forms.View.Details;
            this.lvMail.SelectedIndexChanged += new System.EventHandler(this.lvMail_SelectedIndexChanged);
            this.lvMail.Click += new System.EventHandler(this.lvMail_Click);
            this.lvMail.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lvMail_KeyUp);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "发信人";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "收信人";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "主题";
            this.columnHeader5.Width = 200;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "大小";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader9.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "发信时间";
            this.columnHeader6.Width = 140;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "接收时间";
            this.columnHeader7.Width = 140;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(253, 190);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(459, 3);
            this.splitter2.TabIndex = 9;
            this.splitter2.TabStop = false;
            // 
            // lbInfo
            // 
            this.lbInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lbInfo.Location = new System.Drawing.Point(253, 193);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(459, 27);
            this.lbInfo.TabIndex = 10;
            // 
            // txtContent
            // 
            this.txtContent.AcceptsTab = true;
            this.txtContent.BackColor = System.Drawing.Color.Navy;
            this.txtContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtContent.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtContent.ForeColor = System.Drawing.Color.White;
            this.txtContent.Location = new System.Drawing.Point(253, 220);
            this.txtContent.Name = "txtContent";
            this.txtContent.ReadOnly = true;
            this.txtContent.Size = new System.Drawing.Size(459, 135);
            this.txtContent.TabIndex = 12;
            this.txtContent.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(712, 377);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.lvMail);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.lvArea);
            this.Controls.Add(this.statusBar1);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JAM Reader";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel6)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.EnableVisualStyles();
			try
			{
				Application.Run(new Form1());
			}
			catch(Exception e)
			{
				MessageBox.Show(e.ToString());
			}			
		}

		private string GEchoFile
		{
			get
			{
				object o = this.Settings["GEchoFile"];
				if (o == null) 
					return null;
				else
					return (string)o;
			}
			set
			{
				this.Settings["GEchoFile"] = value;
			}
		}

		private string JamPath
		{
			get
			{
				object o = this.Settings["JamPath"];
				if (o == null)
				{
					return null;
				}
				else
				{
					return (string)o;
				}
			}
			set
			{
				this.Settings["JamPath"] = value;
			}
		}
		
		private bool IfHighColor
		{
			get
			{
				object o = this.Settings["IfHighColor"];
				if (o == null)
				{
					return false;
				}
				else
				{
					if (o.Equals("True"))
						return true;
					else
						return false;
				}
			}

			set
			{
				this.Settings["IfHighColor"] = value;
			}
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			this.mnHighColor.Checked = this.IfHighColor;
			this.txtContent.bIfHighColor = this.IfHighColor;
			if (this.GEchoFile == null || 
				this.JamPath == null)
			{
				this.mnOpenJam_Click(sender, e);
			}
			else
			{
				this.OpenJam();
			}
		}

		private void mnExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void mnExportTo_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("不好意思，俺还没有做这个功能．您再等等？");
		}

		private void OpenJam()
		{
			this.Cursor = Cursors.WaitCursor;
			MailArea[] Areas = MailArea.LoadAreasFromFile(this.GEchoFile);
			if (Areas == null)
			{
				MessageBox.Show("打不开你指出的GECHO设置文件! 请您再指定一下");
				this.mnOpenJam_Click(null, null);
				return;
			}

			this.lvArea.Items.Clear();
			for(int i = 0 ; i < Areas.Length; i ++)
			{
				Areas[i].ChangePath(this.JamPath);
				Areas[i].LoadAreaInfo();
				ListViewItem lvi =  this.lvArea.Items.Add(Areas[i].sAreaname);
				lvi.SubItems.Add(Areas[i].sDes);
				lvi.SubItems.Add(Areas[i].lMailCount.ToString("#,0"));
				lvi.Tag = Areas[i];
			}
			this.Cursor = Cursors.Default;

		}
		
		private void mnOpenJam_Click(object sender, System.EventArgs e)
		{			
			OpenFileDialog fd = new OpenFileDialog();
			fd.Title = "请选择GECHO信区设置文件";
			fd.FileName = "AREAFILE.GE";
			fd.Filter = "GECHO信区设置文件AREAFILE.GE|AREAFILE.GE";
			if (DialogResult.OK != fd.ShowDialog())
			{
				return;
			}
			// 打开信包
			MailArea[] Areas = MailArea.LoadAreasFromFile(fd.FileName);
			if (Areas == null || Areas.Length == 0)
			{
				MessageBox.Show("打开信区配置文件出错！或是没有配置任何信区．");
				return;
			}

			this.GEchoFile = fd.FileName;

			// 试着打开第一个文件
			if (!File.Exists(Areas[0].sFullPathName))
			{
				MessageBox.Show("没有找到信区配置里指定的文件，可能是因为计算机环境的改变引起的，您可以手工指定信包文件．");

				fd.Title = "请选择指定的信包文件";
				fd.FileName = Areas[0].sFileName + ".JHR";
				fd.Filter = "信包文件" + Areas[0].sFileName + ".JHR|" + Areas[0].sFileName + ".JHR";
				if (DialogResult.OK != fd.ShowDialog())
				{
					MessageBox.Show("由于没有打到信包文件，信区无法打开");
					return;
				}
				// 找出信包文件的路径
				string sPath = fd.FileName.Substring(0, fd.FileName.LastIndexOfAny(new char[]{'\\', ':'}) + 1);
				this.JamPath = sPath;
				this.OpenJam();
			}

			return;			
		}

		private void lvArea_DoubleClick(object sender, System.EventArgs e)
		{
			if (this.lvArea.SelectedItems.Count == 0)
			{
				return;				
			}
			this.ChangeCurrentAreaTo(this.lvArea.SelectedItems[0].Index);
		}

		/// <summary>
		/// 切换当前信区
		/// </summary>
		/// <param name="iIndex"></param>
		private void ChangeCurrentAreaTo(int iIndex)
		{
			if (this.iCurrentArea == iIndex)
				return;

			if (this.lvArea.Items.Count <= iIndex)
				return;

			if (this.lvArea.Items[iIndex].Tag == null)
				return;

			// 更新查找书签
			this.iFindRecord = 0;
			this.iFindArea = iIndex;
			this.iCurrentArea = iIndex;

			// 滚动ＬＩＳＴ
			this.lvArea.SelectedItems.Clear();
			this.lvArea.Items[iIndex].Selected = true;
			this.lvArea.EnsureVisible(this.iCurrentArea);

			this.Cursor = Cursors.WaitCursor;
			this.lvMail.Items.Clear();			
			MailArea m = (MailArea)this.lvArea.Items[iIndex].Tag;			
			this.arCurrentMails = m.LoadMails();

			if (this.arCurrentMails == null || this.arCurrentMails.Length == 0)
			{
				ListViewItem lvi = this.lvMail.Items.Add("空信区");
				this.Cursor = Cursors.Default;
				return;
			}

			for (int i = 0; i < this.arCurrentMails.Length; i ++)
			{
				JamMail jm = this.arCurrentMails[i];
				ListViewItem lvi = this.lvMail.Items.Add(jm.sFrom);
				lvi.SubItems.Add(jm.sTo);
				lvi.SubItems.Add(jm.sSubject);
				lvi.SubItems.Add(jm.uSize.ToString("#,0"));
				lvi.SubItems.Add(jm.dtSendTime.ToString());
				lvi.SubItems.Add(jm.dtReciveTime.ToString());
				lvi.Tag = jm;
			}
			this.Cursor = Cursors.Default;
		}

		private void lvMail_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			return;
		}

		private void mnAbout_Click(object sender, System.EventArgs e)
		{
			FrmRegister frm = new FrmRegister();
			frm.ShowDialog();
		}


		private void mnFind_Click(object sender, System.EventArgs e)
		{
			if (DialogResult.OK != this.frmFind.ShowDialog())
			{
				return;
			}
			this.iFindRecord = 0;
			if (this.frmFind.chkAllArea.Checked)
			{
				this.iFindArea = 0;
			}
			this.mnFindNext_Click(sender, e);			
		}

		private void mnFindNext_Click(object sender, System.EventArgs e)
		{			
			string sFindText = this.frmFind.txtFindText.Text;
			if (this.frmFind.chkNoCase.Checked)
			{
				sFindText = sFindText.ToLower();
			}
			bool bFound = false;
			int i = 0, j;			
			int iEndArea = this.frmFind.chkAllArea.Checked ? 
				this.lvArea.Items.Count - 1: this.iFindArea;

			for (j = this.iFindArea; j < iEndArea; j ++)
			{
				MailArea m = (MailArea)this.lvArea.Items[j].Tag;
				
				JamMail [] jms;
				// 如果是当前信区，那么不需要再读文件了．
				if (this.iCurrentArea != j)
				{				
					jms = m.LoadMails();
				}
				else
				{
					jms = this.arCurrentMails;
				}
				if (jms == null )
					continue;				

				#region look up a mail in a area
				for(i = this.iFindRecord; i < jms.Length; i ++)
				{			
					JamMail jm = (JamMail)jms[i];
					bFound = jm.FindText(
						this.frmFind.txtFindText.Text,
						this.frmFind.chkFrom.Checked,
						this.frmFind.chkTo.Checked,
						this.frmFind.chkSubject.Checked,
						this.frmFind.chkContent.Checked,
						this.frmFind.chkNoCase.Checked,
						false
						);
					if (bFound)
					{
						// 找到了．
						break;
					}
				}
				if (bFound)
				{
					break;
				}
				else
				{
					// 从下个区的开始找．
					this.iFindRecord = 0;
				}

#endregion
			}			
			if (!bFound)
			{
				MessageBox.Show("没有了．");
				return;
			}
			// 要切换到找到的信区和信里．
			if (j != this.iCurrentArea)
			{
				//不是当前区，要切换到Ｊ信区里
				this.ChangeCurrentAreaTo(j);				
			}			
			this.lvMail.SelectedItems.Clear();
			this.lvMail.Items[i].Selected = true;
			this.ShowCurrentMail();
			this.lvMail.Items[i].EnsureVisible();
			this.txtContent.Focus();
		}

		private void mnHighColor_Click(object sender, System.EventArgs e)
		{
			this.mnHighColor.Checked = !this.mnHighColor.Checked;
			this.IfHighColor = this.mnHighColor.Checked;
			this.txtContent.bIfHighColor = this.mnHighColor.Checked;
		}

		private void mnHelp_Click(object sender, System.EventArgs e)
		{
			
			string sHelpFile = System.IO.Directory.GetCurrentDirectory();
			if (!sHelpFile.EndsWith("\\"))
				sHelpFile += "\\";
			sHelpFile += "help.html";
			try
			{			
				//Process.Start(startInfo);
				Process.Start(sHelpFile);
			}
			catch
			{
				MessageBox.Show("没有找到帮助文件! 还是你没有装IE? 想不通.");
			}
			
		}

		private void mnReg_Click(object sender, System.EventArgs e)
		{
			FrmRegister frm = new FrmRegister();
			frm.ShowDialog();
		}

		private void ShowCurrentMail()
		{
			if (this.lvMail.SelectedItems.Count == 0)
				return;
			if (this.lvMail.SelectedItems[0].Tag == null)
				return;

			JamMail jm = (JamMail)this.lvMail.SelectedItems[0].Tag;
			this.lbInfo.Text = jm.GetInfoString();
			
			this.txtContent.Clear();
			this.txtContent.ClearUndo();
			this.txtContent.Text = jm.LoadText();

			// this.txtContent.Text = jm.LoadText();
			this.iFindRecord = this.lvMail.SelectedItems[0].Index + 1;
			this.iFindArea = this.lvArea.SelectedItems[0].Index;
		}

		private void lvMail_Click(object sender, System.EventArgs e)
		{
			this.ShowCurrentMail();
		}

		private void lvMail_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.ShowCurrentMail();
		}
	}
}
