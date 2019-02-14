using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace JAMReader
{
	/// <summary>
	/// FrmFind 的摘要说明。
	/// </summary>
	public class FrmFind : System.Windows.Forms.Form
	{
		public System.Windows.Forms.CheckBox chkFrom;
		public System.Windows.Forms.CheckBox chkTo;
		public System.Windows.Forms.CheckBox chkSubject;
		public System.Windows.Forms.CheckBox chkContent;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btFind;
		private System.Windows.Forms.Button btCancle;
		public System.Windows.Forms.TextBox txtFindText;
		public System.Windows.Forms.CheckBox chkNoCase;
		public System.Windows.Forms.CheckBox chkAllArea;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmFind()
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
				if(components != null)
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
			this.chkFrom = new System.Windows.Forms.CheckBox();
			this.chkTo = new System.Windows.Forms.CheckBox();
			this.chkSubject = new System.Windows.Forms.CheckBox();
			this.chkContent = new System.Windows.Forms.CheckBox();
			this.txtFindText = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btFind = new System.Windows.Forms.Button();
			this.btCancle = new System.Windows.Forms.Button();
			this.chkNoCase = new System.Windows.Forms.CheckBox();
			this.chkAllArea = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// chkFrom
			// 
			this.chkFrom.Checked = true;
			this.chkFrom.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkFrom.Location = new System.Drawing.Point(10, 22);
			this.chkFrom.Name = "chkFrom";
			this.chkFrom.Size = new System.Drawing.Size(72, 20);
			this.chkFrom.TabIndex = 2;
			this.chkFrom.Text = "发信人";
			// 
			// chkTo
			// 
			this.chkTo.Checked = true;
			this.chkTo.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkTo.Location = new System.Drawing.Point(86, 22);
			this.chkTo.Name = "chkTo";
			this.chkTo.Size = new System.Drawing.Size(72, 20);
			this.chkTo.TabIndex = 3;
			this.chkTo.Text = "收信人";
			// 
			// chkSubject
			// 
			this.chkSubject.Checked = true;
			this.chkSubject.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkSubject.Location = new System.Drawing.Point(160, 22);
			this.chkSubject.Name = "chkSubject";
			this.chkSubject.Size = new System.Drawing.Size(72, 20);
			this.chkSubject.TabIndex = 4;
			this.chkSubject.Text = "主题";
			// 
			// chkContent
			// 
			this.chkContent.Location = new System.Drawing.Point(10, 44);
			this.chkContent.Name = "chkContent";
			this.chkContent.Size = new System.Drawing.Size(72, 20);
			this.chkContent.TabIndex = 5;
			this.chkContent.Text = "正文";
			// 
			// txtFindText
			// 
			this.txtFindText.Location = new System.Drawing.Point(48, 8);
			this.txtFindText.Name = "txtFindText";
			this.txtFindText.Size = new System.Drawing.Size(328, 21);
			this.txtFindText.TabIndex = 1;
			this.txtFindText.Text = "";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.chkFrom);
			this.groupBox1.Controls.Add(this.chkTo);
			this.groupBox1.Controls.Add(this.chkSubject);
			this.groupBox1.Controls.Add(this.chkContent);
			this.groupBox1.Location = new System.Drawing.Point(14, 36);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(262, 72);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "在以下信息中查找";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(30, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "查找";
			// 
			// btFind
			// 
			this.btFind.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btFind.Location = new System.Drawing.Point(292, 76);
			this.btFind.Name = "btFind";
			this.btFind.Size = new System.Drawing.Size(84, 23);
			this.btFind.TabIndex = 6;
			this.btFind.Text = "查找";
			// 
			// btCancle
			// 
			this.btCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btCancle.Location = new System.Drawing.Point(292, 110);
			this.btCancle.Name = "btCancle";
			this.btCancle.Size = new System.Drawing.Size(84, 23);
			this.btCancle.TabIndex = 7;
			this.btCancle.Text = "取消";
			// 
			// chkNoCase
			// 
			this.chkNoCase.Location = new System.Drawing.Point(24, 114);
			this.chkNoCase.Name = "chkNoCase";
			this.chkNoCase.Size = new System.Drawing.Size(102, 20);
			this.chkNoCase.TabIndex = 5;
			this.chkNoCase.Text = "不区分大小写";
			// 
			// chkAllArea
			// 
			this.chkAllArea.Location = new System.Drawing.Point(170, 114);
			this.chkAllArea.Name = "chkAllArea";
			this.chkAllArea.Size = new System.Drawing.Size(102, 20);
			this.chkAllArea.TabIndex = 5;
			this.chkAllArea.Text = "查找全部信区";
			// 
			// FrmFind
			// 
			this.AcceptButton = this.btFind;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.CancelButton = this.btCancle;
			this.ClientSize = new System.Drawing.Size(388, 145);
			this.Controls.Add(this.btFind);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.txtFindText);
			this.Controls.Add(this.btCancle);
			this.Controls.Add(this.chkNoCase);
			this.Controls.Add(this.chkAllArea);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FrmFind";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "查找";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

	}
}
