namespace TimerCalc
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Timers");
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.prescaler = new System.Windows.Forms.ComboBox();
            this.postscaler = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtFormattedCode = new System.Windows.Forms.TextBox();
            this.chckCalcScalers = new System.Windows.Forms.CheckBox();
            this.txtAccuracy = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDeviation = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtActualPeriod = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.ComboBox();
            this.txtScalerOverride = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCalc = new System.Windows.Forms.Button();
            this.txtPreload = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSteps = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnRemoveNode = new System.Windows.Forms.Button();
            this.btnAddPostscaler = new System.Windows.Forms.Button();
            this.btnAddPrescaler = new System.Windows.Forms.Button();
            this.btnAddTimer = new System.Windows.Forms.Button();
            this.txtSettingsAdd = new System.Windows.Forms.TextBox();
            this.treeView = new System.Windows.Forms.TreeView();
            this.txtFosc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timerCode = new System.Windows.Forms.ComboBox();
            this.txtTimerCode = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTarget
            // 
            this.txtTarget.Location = new System.Drawing.Point(6, 31);
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(100, 20);
            this.txtTarget.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Input";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(112, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Target Period [s]";
            // 
            // prescaler
            // 
            this.prescaler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.prescaler.FormattingEnabled = true;
            this.prescaler.Location = new System.Drawing.Point(6, 84);
            this.prescaler.Name = "prescaler";
            this.prescaler.Size = new System.Drawing.Size(100, 21);
            this.prescaler.TabIndex = 4;
            // 
            // postscaler
            // 
            this.postscaler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.postscaler.FormattingEnabled = true;
            this.postscaler.Location = new System.Drawing.Point(6, 111);
            this.postscaler.Name = "postscaler";
            this.postscaler.Size = new System.Drawing.Size(100, 21);
            this.postscaler.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(112, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Prescaler";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(112, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Postscaler";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(832, 526);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtFormattedCode);
            this.tabPage1.Controls.Add(this.chckCalcScalers);
            this.tabPage1.Controls.Add(this.txtAccuracy);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.txtDeviation);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.txtActualPeriod);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.timer);
            this.tabPage1.Controls.Add(this.txtScalerOverride);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.btnCalc);
            this.tabPage1.Controls.Add(this.txtPreload);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.txtSteps);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtTarget);
            this.tabPage1.Controls.Add(this.postscaler);
            this.tabPage1.Controls.Add(this.prescaler);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 424);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Input";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtFormattedCode
            // 
            this.txtFormattedCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFormattedCode.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtFormattedCode.Location = new System.Drawing.Point(487, 3);
            this.txtFormattedCode.Multiline = true;
            this.txtFormattedCode.Name = "txtFormattedCode";
            this.txtFormattedCode.ReadOnly = true;
            this.txtFormattedCode.Size = new System.Drawing.Size(302, 418);
            this.txtFormattedCode.TabIndex = 27;
            // 
            // chckCalcScalers
            // 
            this.chckCalcScalers.AutoSize = true;
            this.chckCalcScalers.Checked = true;
            this.chckCalcScalers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chckCalcScalers.Location = new System.Drawing.Point(202, 173);
            this.chckCalcScalers.Name = "chckCalcScalers";
            this.chckCalcScalers.Size = new System.Drawing.Size(108, 17);
            this.chckCalcScalers.TabIndex = 26;
            this.chckCalcScalers.Text = "Calculate Scalers";
            this.chckCalcScalers.UseVisualStyleBackColor = true;
            // 
            // txtAccuracy
            // 
            this.txtAccuracy.Location = new System.Drawing.Point(6, 327);
            this.txtAccuracy.Name = "txtAccuracy";
            this.txtAccuracy.ReadOnly = true;
            this.txtAccuracy.Size = new System.Drawing.Size(100, 20);
            this.txtAccuracy.TabIndex = 24;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(112, 331);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "Accuracy [%]";
            // 
            // txtDeviation
            // 
            this.txtDeviation.Location = new System.Drawing.Point(6, 301);
            this.txtDeviation.Name = "txtDeviation";
            this.txtDeviation.ReadOnly = true;
            this.txtDeviation.Size = new System.Drawing.Size(100, 20);
            this.txtDeviation.TabIndex = 22;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(112, 305);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Deviation [s]";
            // 
            // txtActualPeriod
            // 
            this.txtActualPeriod.Location = new System.Drawing.Point(6, 275);
            this.txtActualPeriod.Name = "txtActualPeriod";
            this.txtActualPeriod.ReadOnly = true;
            this.txtActualPeriod.Size = new System.Drawing.Size(100, 20);
            this.txtActualPeriod.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(112, 279);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Actual Period [s]";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(112, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Timer";
            // 
            // timer
            // 
            this.timer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timer.FormattingEnabled = true;
            this.timer.Location = new System.Drawing.Point(6, 57);
            this.timer.Name = "timer";
            this.timer.Size = new System.Drawing.Size(100, 21);
            this.timer.TabIndex = 2;
            this.timer.SelectedIndexChanged += new System.EventHandler(this.timer_SelectedIndexChanged);
            // 
            // txtScalerOverride
            // 
            this.txtScalerOverride.Location = new System.Drawing.Point(6, 140);
            this.txtScalerOverride.Name = "txtScalerOverride";
            this.txtScalerOverride.Size = new System.Drawing.Size(100, 20);
            this.txtScalerOverride.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(112, 143);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Scaler Override";
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(6, 169);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(190, 23);
            this.btnCalc.TabIndex = 3;
            this.btnCalc.Text = "Calculate";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // txtPreload
            // 
            this.txtPreload.Location = new System.Drawing.Point(6, 249);
            this.txtPreload.Name = "txtPreload";
            this.txtPreload.ReadOnly = true;
            this.txtPreload.Size = new System.Drawing.Size(100, 20);
            this.txtPreload.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(112, 253);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Start Value";
            // 
            // txtSteps
            // 
            this.txtSteps.Location = new System.Drawing.Point(6, 223);
            this.txtSteps.Name = "txtSteps";
            this.txtSteps.ReadOnly = true;
            this.txtSteps.Size = new System.Drawing.Size(100, 20);
            this.txtSteps.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(112, 227);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Ticks";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 25);
            this.label6.TabIndex = 10;
            this.label6.Text = "Output";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(824, 500);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnRemoveNode
            // 
            this.btnRemoveNode.Location = new System.Drawing.Point(367, 3);
            this.btnRemoveNode.Name = "btnRemoveNode";
            this.btnRemoveNode.Size = new System.Drawing.Size(75, 20);
            this.btnRemoveNode.TabIndex = 6;
            this.btnRemoveNode.Text = "Remove";
            this.btnRemoveNode.UseVisualStyleBackColor = true;
            this.btnRemoveNode.Click += new System.EventHandler(this.btnRemoveNode_Click);
            // 
            // btnAddPostscaler
            // 
            this.btnAddPostscaler.Location = new System.Drawing.Point(271, 3);
            this.btnAddPostscaler.Name = "btnAddPostscaler";
            this.btnAddPostscaler.Size = new System.Drawing.Size(90, 20);
            this.btnAddPostscaler.TabIndex = 5;
            this.btnAddPostscaler.Text = "Add Postscaler";
            this.btnAddPostscaler.UseVisualStyleBackColor = true;
            this.btnAddPostscaler.Click += new System.EventHandler(this.btnAddPostscaler_Click);
            // 
            // btnAddPrescaler
            // 
            this.btnAddPrescaler.Location = new System.Drawing.Point(175, 3);
            this.btnAddPrescaler.Name = "btnAddPrescaler";
            this.btnAddPrescaler.Size = new System.Drawing.Size(90, 20);
            this.btnAddPrescaler.TabIndex = 4;
            this.btnAddPrescaler.Text = "Add Prescaler";
            this.btnAddPrescaler.UseVisualStyleBackColor = true;
            this.btnAddPrescaler.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAddTimer
            // 
            this.btnAddTimer.Location = new System.Drawing.Point(94, 3);
            this.btnAddTimer.Name = "btnAddTimer";
            this.btnAddTimer.Size = new System.Drawing.Size(75, 20);
            this.btnAddTimer.TabIndex = 3;
            this.btnAddTimer.Text = "Add Timer";
            this.btnAddTimer.UseVisualStyleBackColor = true;
            this.btnAddTimer.Click += new System.EventHandler(this.btnAddTimer_Click);
            // 
            // txtSettingsAdd
            // 
            this.txtSettingsAdd.Location = new System.Drawing.Point(3, 3);
            this.txtSettingsAdd.Name = "txtSettingsAdd";
            this.txtSettingsAdd.Size = new System.Drawing.Size(85, 20);
            this.txtSettingsAdd.TabIndex = 2;
            this.txtSettingsAdd.Text = "Timer0";
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.HideSelection = false;
            this.treeView.Location = new System.Drawing.Point(0, 25);
            this.treeView.Name = "treeView";
            treeNode3.Name = "root";
            treeNode3.Text = "Timers";
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.treeView.Size = new System.Drawing.Size(465, 440);
            this.treeView.TabIndex = 7;
            this.treeView.Validated += new System.EventHandler(this.treeView_Validated);
            // 
            // txtFosc
            // 
            this.txtFosc.Location = new System.Drawing.Point(3, 4);
            this.txtFosc.Name = "txtFosc";
            this.txtFosc.Size = new System.Drawing.Size(100, 20);
            this.txtFosc.TabIndex = 1;
            this.txtFosc.Text = "8000000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "FOSC [Hz]";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtLog);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(792, 424);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Log";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(3, 3);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(786, 418);
            this.txtLog.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timerCode
            // 
            this.timerCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timerCode.FormattingEnabled = true;
            this.timerCode.Location = new System.Drawing.Point(3, 3);
            this.timerCode.Name = "timerCode";
            this.timerCode.Size = new System.Drawing.Size(90, 21);
            this.timerCode.TabIndex = 8;
            this.timerCode.SelectedIndexChanged += new System.EventHandler(this.timerCode_SelectedIndexChanged);
            // 
            // txtTimerCode
            // 
            this.txtTimerCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTimerCode.Location = new System.Drawing.Point(0, 25);
            this.txtTimerCode.Multiline = true;
            this.txtTimerCode.Name = "txtTimerCode";
            this.txtTimerCode.Size = new System.Drawing.Size(349, 440);
            this.txtTimerCode.TabIndex = 9;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 32);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtTimerCode);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Size = new System.Drawing.Size(818, 465);
            this.splitContainer1.SplitterDistance = 465;
            this.splitContainer1.TabIndex = 10;
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveConfig.Location = new System.Drawing.Point(740, 3);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(75, 20);
            this.btnSaveConfig.TabIndex = 11;
            this.btnSaveConfig.Text = "Save Config";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSaveConfig);
            this.panel1.Controls.Add(this.txtFosc);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(818, 29);
            this.panel1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtSettingsAdd);
            this.panel2.Controls.Add(this.btnAddPostscaler);
            this.panel2.Controls.Add(this.btnAddPrescaler);
            this.panel2.Controls.Add(this.btnAddTimer);
            this.panel2.Controls.Add(this.btnRemoveNode);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(465, 25);
            this.panel2.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.timerCode);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(349, 25);
            this.panel3.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 526);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "ScalerCalc";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtTarget;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox prescaler;
        private System.Windows.Forms.ComboBox postscaler;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtFosc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSteps;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.TextBox txtPreload;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.TextBox txtScalerOverride;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnAddPrescaler;
        private System.Windows.Forms.Button btnAddTimer;
        private System.Windows.Forms.TextBox txtSettingsAdd;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Button btnAddPostscaler;
        private System.Windows.Forms.Button btnRemoveNode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox timer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtActualPeriod;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDeviation;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtAccuracy;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox chckCalcScalers;
        private System.Windows.Forms.TextBox txtFormattedCode;
        private System.Windows.Forms.TextBox txtTimerCode;
        private System.Windows.Forms.ComboBox timerCode;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnSaveConfig;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}

