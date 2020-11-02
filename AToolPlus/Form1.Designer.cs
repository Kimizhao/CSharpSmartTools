namespace AToolPlus
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.退出 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.发送区设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSendAppendRN = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSendATString = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSendHex = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSendCycle = new System.Windows.Forms.ToolStripMenuItem();
            this.接收区设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRecvShowTime = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRecvAutoLine = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRecvShowHex = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRecvSaveLog = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripCmbPort = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripCmbBaud = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripBtnOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnMore = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnUp = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnLoad = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnSave = new System.Windows.Forms.ToolStripButton();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.BtnSend = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelCom = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(62, 28);
            this.toolStripMenuItem1.Text = "开始";
            // 
            // 退出
            // 
            this.退出.Name = "退出";
            this.退出.Size = new System.Drawing.Size(146, 34);
            this.退出.Text = "退出";
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.发送区设置ToolStripMenuItem,
            this.接收区设置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1153, 32);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 发送区设置ToolStripMenuItem
            // 
            this.发送区设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuSendAppendRN,
            this.MenuSendATString,
            this.MenuSendHex,
            this.MenuSendCycle});
            this.发送区设置ToolStripMenuItem.Name = "发送区设置ToolStripMenuItem";
            this.发送区设置ToolStripMenuItem.Size = new System.Drawing.Size(98, 28);
            this.发送区设置ToolStripMenuItem.Text = "发送设置";
            // 
            // MenuSendAppendRN
            // 
            this.MenuSendAppendRN.Name = "MenuSendAppendRN";
            this.MenuSendAppendRN.Size = new System.Drawing.Size(200, 34);
            this.MenuSendAppendRN.Text = "加回车换行";
            this.MenuSendAppendRN.Click += new System.EventHandler(this.MenuSendAppendRN_Click);
            // 
            // MenuSendATString
            // 
            this.MenuSendATString.Name = "MenuSendATString";
            this.MenuSendATString.Size = new System.Drawing.Size(200, 34);
            this.MenuSendATString.Text = "字符串发送";
            this.MenuSendATString.Click += new System.EventHandler(this.MenuSendATString_Click);
            // 
            // MenuSendHex
            // 
            this.MenuSendHex.Name = "MenuSendHex";
            this.MenuSendHex.Size = new System.Drawing.Size(200, 34);
            this.MenuSendHex.Text = "HEX发送";
            this.MenuSendHex.Click += new System.EventHandler(this.MenuSendHex_Click);
            // 
            // MenuSendCycle
            // 
            this.MenuSendCycle.Name = "MenuSendCycle";
            this.MenuSendCycle.Size = new System.Drawing.Size(200, 34);
            this.MenuSendCycle.Text = "循环发送";
            this.MenuSendCycle.Click += new System.EventHandler(this.MenuSendCycle_Click);
            // 
            // 接收区设置ToolStripMenuItem
            // 
            this.接收区设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuRecvShowTime,
            this.MenuRecvAutoLine,
            this.MenuRecvShowHex,
            this.MenuRecvSaveLog});
            this.接收区设置ToolStripMenuItem.Name = "接收区设置ToolStripMenuItem";
            this.接收区设置ToolStripMenuItem.Size = new System.Drawing.Size(98, 28);
            this.接收区设置ToolStripMenuItem.Text = "接收设置";
            // 
            // MenuRecvShowTime
            // 
            this.MenuRecvShowTime.Checked = true;
            this.MenuRecvShowTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuRecvShowTime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MenuRecvShowTime.Name = "MenuRecvShowTime";
            this.MenuRecvShowTime.Size = new System.Drawing.Size(236, 34);
            this.MenuRecvShowTime.Text = "显示接收时间";
            this.MenuRecvShowTime.Click += new System.EventHandler(this.MenuRecvShowTime_Click);
            // 
            // MenuRecvAutoLine
            // 
            this.MenuRecvAutoLine.Name = "MenuRecvAutoLine";
            this.MenuRecvAutoLine.Size = new System.Drawing.Size(236, 34);
            this.MenuRecvAutoLine.Text = "自动换行";
            this.MenuRecvAutoLine.Click += new System.EventHandler(this.MenuRecvAutoLine_Click);
            // 
            // MenuRecvShowHex
            // 
            this.MenuRecvShowHex.Name = "MenuRecvShowHex";
            this.MenuRecvShowHex.Size = new System.Drawing.Size(236, 34);
            this.MenuRecvShowHex.Text = "十六进制显示";
            this.MenuRecvShowHex.Click += new System.EventHandler(this.MenuRecvShowHex_Click);
            // 
            // MenuRecvSaveLog
            // 
            this.MenuRecvSaveLog.Name = "MenuRecvSaveLog";
            this.MenuRecvSaveLog.Size = new System.Drawing.Size(236, 34);
            this.MenuRecvSaveLog.Text = "数据保存到文件";
            this.MenuRecvSaveLog.Click += new System.EventHandler(this.MenuRecvSaveLog_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(554, 556);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripCmbPort,
            this.toolStripCmbBaud,
            this.toolStripBtnOpen,
            this.toolStripBtnMore,
            this.toolStripSeparator1,
            this.toolStripBtnAdd,
            this.toolStripBtnUp,
            this.toolStripButton2,
            this.toolStripBtnLoad,
            this.toolStripBtnSave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 32);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1153, 33);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(64, 28);
            this.toolStripLabel1.Text = "端口号";
            // 
            // toolStripCmbPort
            // 
            this.toolStripCmbPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripCmbPort.Name = "toolStripCmbPort";
            this.toolStripCmbPort.Size = new System.Drawing.Size(121, 33);
            // 
            // toolStripCmbBaud
            // 
            this.toolStripCmbBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripCmbBaud.Items.AddRange(new object[] {
            "9600",
            "14400",
            "19200",
            "38400",
            "56000",
            "57600",
            "115200"});
            this.toolStripCmbBaud.Name = "toolStripCmbBaud";
            this.toolStripCmbBaud.Size = new System.Drawing.Size(121, 33);
            // 
            // toolStripBtnOpen
            // 
            this.toolStripBtnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripBtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnOpen.Name = "toolStripBtnOpen";
            this.toolStripBtnOpen.Size = new System.Drawing.Size(50, 28);
            this.toolStripBtnOpen.Text = "打开";
            this.toolStripBtnOpen.ToolTipText = "打开";
            this.toolStripBtnOpen.Click += new System.EventHandler(this.toolStripBtnOpen_Click);
            // 
            // toolStripBtnMore
            // 
            this.toolStripBtnMore.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripBtnMore.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnMore.Name = "toolStripBtnMore";
            this.toolStripBtnMore.Size = new System.Drawing.Size(50, 28);
            this.toolStripBtnMore.Text = "更多";
            this.toolStripBtnMore.ToolTipText = "打开";
            this.toolStripBtnMore.Click += new System.EventHandler(this.toolStripBtnMore_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 33);
            // 
            // toolStripBtnAdd
            // 
            this.toolStripBtnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripBtnAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnAdd.Image")));
            this.toolStripBtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnAdd.Name = "toolStripBtnAdd";
            this.toolStripBtnAdd.Size = new System.Drawing.Size(50, 28);
            this.toolStripBtnAdd.Text = "新增";
            this.toolStripBtnAdd.Click += new System.EventHandler(this.toolStripBtnAdd_Click);
            // 
            // toolStripBtnUp
            // 
            this.toolStripBtnUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripBtnUp.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnUp.Image")));
            this.toolStripBtnUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnUp.Name = "toolStripBtnUp";
            this.toolStripBtnUp.Size = new System.Drawing.Size(50, 28);
            this.toolStripBtnUp.Text = "上移";
            this.toolStripBtnUp.Click += new System.EventHandler(this.toolStripBtnUp_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(50, 28);
            this.toolStripButton2.Text = "下移";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripBtnDown_Click);
            // 
            // toolStripBtnLoad
            // 
            this.toolStripBtnLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripBtnLoad.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnLoad.Image")));
            this.toolStripBtnLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnLoad.Name = "toolStripBtnLoad";
            this.toolStripBtnLoad.Size = new System.Drawing.Size(50, 28);
            this.toolStripBtnLoad.Text = "加载";
            this.toolStripBtnLoad.Click += new System.EventHandler(this.toolStripBtnLoad_Click);
            // 
            // toolStripBtnSave
            // 
            this.toolStripBtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripBtnSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnSave.Image")));
            this.toolStripBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnSave.Name = "toolStripBtnSave";
            this.toolStripBtnSave.Size = new System.Drawing.Size(50, 28);
            this.toolStripBtnSave.Text = "保存";
            this.toolStripBtnSave.Click += new System.EventHandler(this.toolStripBtnSave_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(562, 524);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "字符串发送";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(556, 518);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listView1_ItemChecked);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(570, 556);
            this.tabControl1.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 70);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.richTextBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1128, 556);
            this.splitContainer1.SplitterDistance = 554;
            this.splitContainer1.TabIndex = 3;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(12, 633);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.BtnSend);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.richTextBox2);
            this.splitContainer2.Size = new System.Drawing.Size(1128, 171);
            this.splitContainer2.SplitterDistance = 292;
            this.splitContainer2.SplitterWidth = 6;
            this.splitContainer2.TabIndex = 4;
            // 
            // BtnSend
            // 
            this.BtnSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnSend.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnSend.ForeColor = System.Drawing.Color.Black;
            this.BtnSend.Location = new System.Drawing.Point(0, 0);
            this.BtnSend.Margin = new System.Windows.Forms.Padding(4);
            this.BtnSend.Name = "BtnSend";
            this.BtnSend.Size = new System.Drawing.Size(292, 171);
            this.BtnSend.TabIndex = 0;
            this.BtnSend.Text = "发  送";
            this.BtnSend.UseVisualStyleBackColor = true;
            this.BtnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox2.Location = new System.Drawing.Point(0, 0);
            this.richTextBox2.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(830, 171);
            this.richTextBox2.TabIndex = 0;
            this.richTextBox2.Text = "";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabelCom});
            this.statusStrip1.Location = new System.Drawing.Point(0, 813);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1153, 31);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(180, 24);
            this.toolStripStatusLabel1.Text = "版本号：v1.0.2.1102";
            // 
            // toolStripStatusLabelCom
            // 
            this.toolStripStatusLabelCom.Name = "toolStripStatusLabelCom";
            this.toolStripStatusLabelCom.Size = new System.Drawing.Size(75, 24);
            this.toolStripStatusLabelCom.Text = "             ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1153, 844);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.splitContainer1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "AToolPlus小工具";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 退出;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox toolStripCmbPort;
        private System.Windows.Forms.ToolStripButton toolStripBtnMore;
        private System.Windows.Forms.ToolStripComboBox toolStripCmbBaud;
        private System.Windows.Forms.ToolStripButton toolStripBtnOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripButton toolStripBtnSave;
        private System.Windows.Forms.ToolStripButton toolStripBtnUp;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripBtnLoad;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem 发送区设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 接收区设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuRecvShowTime;
        private System.Windows.Forms.ToolStripMenuItem MenuRecvAutoLine;
        private System.Windows.Forms.ToolStripMenuItem MenuRecvShowHex;
        private System.Windows.Forms.ToolStripMenuItem MenuSendAppendRN;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.ToolStripMenuItem MenuSendATString;
        private System.Windows.Forms.ToolStripMenuItem MenuSendHex;
        private System.Windows.Forms.ToolStripButton toolStripBtnAdd;
        private System.Windows.Forms.ToolStripMenuItem MenuSendCycle;
        private System.Windows.Forms.ToolStripMenuItem MenuRecvSaveLog;
        private System.Windows.Forms.Button BtnSend;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCom;
    }
}

