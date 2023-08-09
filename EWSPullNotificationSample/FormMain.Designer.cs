namespace EWSPullNotificationSample
{
    partial class FormMain
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxImpersonate = new System.Windows.Forms.CheckBox();
            this.radioButtonExchangeOnline = new System.Windows.Forms.RadioButton();
            this.checkBoxIgnoreCert = new System.Windows.Forms.CheckBox();
            this.radioButtonAutodiscover = new System.Windows.Forms.RadioButton();
            this.radioButtonEwsUrl = new System.Windows.Forms.RadioButton();
            this.textBoxEwsUrl = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxExchangeVersion = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxMailbox = new System.Windows.Forms.TextBox();
            this.buttonSubscribe = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonUnsubscribe = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.checkBoxIncludeSubfolders = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxWatermark = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.numericUpDownTimeout = new System.Windows.Forms.NumericUpDown();
            this.checkBoxSelectAll = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxSubscribeTo = new System.Windows.Forms.ComboBox();
            this.checkedListBoxEvents = new System.Windows.Forms.CheckedListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDownPollInterval = new System.Windows.Forms.NumericUpDown();
            this.checkBoxAutoPoll = new System.Windows.Forms.CheckBox();
            this.buttonPoll = new System.Windows.Forms.Button();
            this.timerPoll = new System.Windows.Forms.Timer(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxLastWatermark = new System.Windows.Forms.TextBox();
            this.listBoxEvents = new System.Windows.Forms.ListBox();
            this.checkBoxIncludeMime = new System.Windows.Forms.CheckBox();
            this.checkBoxQueryMore = new System.Windows.Forms.CheckBox();
            this.checkBoxShowFolderEvents = new System.Windows.Forms.CheckBox();
            this.checkBoxShowItemEvents = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBoxOAuthAuthMethod = new System.Windows.Forms.GroupBox();
            this.radioButtonAuthClientCredentials = new System.Windows.Forms.RadioButton();
            this.buttonSelectCertificate = new System.Windows.Forms.Button();
            this.radioButtonAuthWithClientSecret = new System.Windows.Forms.RadioButton();
            this.textBoxAuthCertificate = new System.Windows.Forms.TextBox();
            this.textBoxClientSecret = new System.Windows.Forms.TextBox();
            this.radioButtonAuthWithCertificate = new System.Windows.Forms.RadioButton();
            this.buttonLoadCertificate = new System.Windows.Forms.Button();
            this.textBoxTenantId = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxApplicationId = new System.Windows.Forms.TextBox();
            this.radioButtonAuthOAuth = new System.Windows.Forms.RadioButton();
            this.radioButtonAuthBasic = new System.Windows.Forms.RadioButton();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeout)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPollInterval)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBoxOAuthAuthMethod.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxImpersonate);
            this.groupBox1.Controls.Add(this.radioButtonExchangeOnline);
            this.groupBox1.Controls.Add(this.checkBoxIgnoreCert);
            this.groupBox1.Controls.Add(this.radioButtonAutodiscover);
            this.groupBox1.Controls.Add(this.radioButtonEwsUrl);
            this.groupBox1.Controls.Add(this.textBoxEwsUrl);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.comboBoxExchangeVersion);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxMailbox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(759, 79);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "EWS Configuration";
            // 
            // checkBoxImpersonate
            // 
            this.checkBoxImpersonate.AutoSize = true;
            this.checkBoxImpersonate.Location = new System.Drawing.Point(282, 46);
            this.checkBoxImpersonate.Name = "checkBoxImpersonate";
            this.checkBoxImpersonate.Size = new System.Drawing.Size(84, 17);
            this.checkBoxImpersonate.TabIndex = 13;
            this.checkBoxImpersonate.Text = "Impersonate";
            this.checkBoxImpersonate.UseVisualStyleBackColor = true;
            // 
            // radioButtonExchangeOnline
            // 
            this.radioButtonExchangeOnline.AutoSize = true;
            this.radioButtonExchangeOnline.Checked = true;
            this.radioButtonExchangeOnline.Location = new System.Drawing.Point(102, 19);
            this.radioButtonExchangeOnline.Name = "radioButtonExchangeOnline";
            this.radioButtonExchangeOnline.Size = new System.Drawing.Size(106, 17);
            this.radioButtonExchangeOnline.TabIndex = 12;
            this.radioButtonExchangeOnline.TabStop = true;
            this.radioButtonExchangeOnline.Text = "Exchange Online";
            this.radioButtonExchangeOnline.UseVisualStyleBackColor = true;
            // 
            // checkBoxIgnoreCert
            // 
            this.checkBoxIgnoreCert.AutoSize = true;
            this.checkBoxIgnoreCert.Location = new System.Drawing.Point(640, 20);
            this.checkBoxIgnoreCert.Name = "checkBoxIgnoreCert";
            this.checkBoxIgnoreCert.Size = new System.Drawing.Size(105, 17);
            this.checkBoxIgnoreCert.TabIndex = 11;
            this.checkBoxIgnoreCert.Text = "Ignore certificate";
            this.checkBoxIgnoreCert.UseVisualStyleBackColor = true;
            // 
            // radioButtonAutodiscover
            // 
            this.radioButtonAutodiscover.AutoSize = true;
            this.radioButtonAutodiscover.Location = new System.Drawing.Point(9, 19);
            this.radioButtonAutodiscover.Name = "radioButtonAutodiscover";
            this.radioButtonAutodiscover.Size = new System.Drawing.Size(87, 17);
            this.radioButtonAutodiscover.TabIndex = 10;
            this.radioButtonAutodiscover.Text = "Autodiscover";
            this.radioButtonAutodiscover.UseVisualStyleBackColor = true;
            this.radioButtonAutodiscover.CheckedChanged += new System.EventHandler(this.radioButtonAutodiscover_CheckedChanged);
            // 
            // radioButtonEwsUrl
            // 
            this.radioButtonEwsUrl.AutoSize = true;
            this.radioButtonEwsUrl.Location = new System.Drawing.Point(214, 19);
            this.radioButtonEwsUrl.Name = "radioButtonEwsUrl";
            this.radioButtonEwsUrl.Size = new System.Drawing.Size(79, 17);
            this.radioButtonEwsUrl.TabIndex = 9;
            this.radioButtonEwsUrl.Text = "Custom Url:";
            this.radioButtonEwsUrl.UseVisualStyleBackColor = true;
            this.radioButtonEwsUrl.CheckedChanged += new System.EventHandler(this.radioButtonEwsUrl_CheckedChanged);
            // 
            // textBoxEwsUrl
            // 
            this.textBoxEwsUrl.Location = new System.Drawing.Point(299, 18);
            this.textBoxEwsUrl.Name = "textBoxEwsUrl";
            this.textBoxEwsUrl.Size = new System.Drawing.Size(335, 20);
            this.textBoxEwsUrl.TabIndex = 8;
            this.textBoxEwsUrl.Text = "https://<server>/EWS/Exchange.asmx";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(429, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Exchange version:";
            // 
            // comboBoxExchangeVersion
            // 
            this.comboBoxExchangeVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxExchangeVersion.FormattingEnabled = true;
            this.comboBoxExchangeVersion.Items.AddRange(new object[] {
            "Exchange2007_SP1",
            "Exchange2010",
            "Exchange2010_SP1",
            "Exchange2010_SP2",
            "Exchange2013",
            "Exchange2013_SP1"});
            this.comboBoxExchangeVersion.Location = new System.Drawing.Point(530, 44);
            this.comboBoxExchangeVersion.Name = "comboBoxExchangeVersion";
            this.comboBoxExchangeVersion.Size = new System.Drawing.Size(215, 21);
            this.comboBoxExchangeVersion.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Mailbox:";
            // 
            // textBoxMailbox
            // 
            this.textBoxMailbox.Location = new System.Drawing.Point(58, 44);
            this.textBoxMailbox.Name = "textBoxMailbox";
            this.textBoxMailbox.Size = new System.Drawing.Size(218, 20);
            this.textBoxMailbox.TabIndex = 4;
            // 
            // buttonSubscribe
            // 
            this.buttonSubscribe.Location = new System.Drawing.Point(158, 182);
            this.buttonSubscribe.Name = "buttonSubscribe";
            this.buttonSubscribe.Size = new System.Drawing.Size(75, 23);
            this.buttonSubscribe.TabIndex = 3;
            this.buttonSubscribe.Text = "Subscribe";
            this.buttonSubscribe.UseVisualStyleBackColor = true;
            this.buttonSubscribe.Click += new System.EventHandler(this.buttonSubscribe_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonUnsubscribe);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.checkBoxIncludeSubfolders);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBoxWatermark);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.numericUpDownTimeout);
            this.groupBox2.Controls.Add(this.checkBoxSelectAll);
            this.groupBox2.Controls.Add(this.buttonSubscribe);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.comboBoxSubscribeTo);
            this.groupBox2.Controls.Add(this.checkedListBoxEvents);
            this.groupBox2.Location = new System.Drawing.Point(443, 97);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(328, 217);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Subscription Information";
            // 
            // buttonUnsubscribe
            // 
            this.buttonUnsubscribe.Location = new System.Drawing.Point(239, 182);
            this.buttonUnsubscribe.Name = "buttonUnsubscribe";
            this.buttonUnsubscribe.Size = new System.Drawing.Size(75, 23);
            this.buttonUnsubscribe.TabIndex = 25;
            this.buttonUnsubscribe.Text = "Unsubscribe";
            this.buttonUnsubscribe.UseVisualStyleBackColor = true;
            this.buttonUnsubscribe.Click += new System.EventHandler(this.buttonUnsubscribe_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(133, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "(mins)";
            // 
            // checkBoxIncludeSubfolders
            // 
            this.checkBoxIncludeSubfolders.AutoSize = true;
            this.checkBoxIncludeSubfolders.Location = new System.Drawing.Point(209, 44);
            this.checkBoxIncludeSubfolders.Name = "checkBoxIncludeSubfolders";
            this.checkBoxIncludeSubfolders.Size = new System.Drawing.Size(112, 17);
            this.checkBoxIncludeSubfolders.TabIndex = 23;
            this.checkBoxIncludeSubfolders.Text = "Include subfolders";
            this.checkBoxIncludeSubfolders.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Watermark:";
            // 
            // textBoxWatermark
            // 
            this.textBoxWatermark.Location = new System.Drawing.Point(74, 72);
            this.textBoxWatermark.Name = "textBoxWatermark";
            this.textBoxWatermark.Size = new System.Drawing.Size(240, 20);
            this.textBoxWatermark.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Timeout:";
            // 
            // numericUpDownTimeout
            // 
            this.numericUpDownTimeout.Location = new System.Drawing.Point(60, 46);
            this.numericUpDownTimeout.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.numericUpDownTimeout.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTimeout.Name = "numericUpDownTimeout";
            this.numericUpDownTimeout.Size = new System.Drawing.Size(67, 20);
            this.numericUpDownTimeout.TabIndex = 18;
            this.numericUpDownTimeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownTimeout.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // checkBoxSelectAll
            // 
            this.checkBoxSelectAll.AutoSize = true;
            this.checkBoxSelectAll.Checked = true;
            this.checkBoxSelectAll.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.checkBoxSelectAll.Location = new System.Drawing.Point(245, 153);
            this.checkBoxSelectAll.Name = "checkBoxSelectAll";
            this.checkBoxSelectAll.Size = new System.Drawing.Size(69, 17);
            this.checkBoxSelectAll.TabIndex = 16;
            this.checkBoxSelectAll.Text = "Select all";
            this.checkBoxSelectAll.ThreeState = true;
            this.checkBoxSelectAll.UseVisualStyleBackColor = true;
            this.checkBoxSelectAll.CheckedChanged += new System.EventHandler(this.checkBoxSelectAll_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Events:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Folder:";
            // 
            // comboBoxSubscribeTo
            // 
            this.comboBoxSubscribeTo.FormattingEnabled = true;
            this.comboBoxSubscribeTo.Items.AddRange(new object[] {
            "All Folders",
            "Calendar",
            "Contacts",
            "DeletedItems",
            "Drafts",
            "Inbox",
            "Journal",
            "Notes",
            "Outbox",
            "SentItems",
            "Tasks",
            "MsgFolderRoot"});
            this.comboBoxSubscribeTo.Location = new System.Drawing.Point(51, 19);
            this.comboBoxSubscribeTo.Name = "comboBoxSubscribeTo";
            this.comboBoxSubscribeTo.Size = new System.Drawing.Size(263, 21);
            this.comboBoxSubscribeTo.TabIndex = 10;
            this.comboBoxSubscribeTo.SelectedIndexChanged += new System.EventHandler(this.comboBoxSubscribeTo_SelectedIndexChanged);
            // 
            // checkedListBoxEvents
            // 
            this.checkedListBoxEvents.CheckOnClick = true;
            this.checkedListBoxEvents.FormattingEnabled = true;
            this.checkedListBoxEvents.Items.AddRange(new object[] {
            "NewMail",
            "Deleted",
            "Modified",
            "Moved",
            "Copied",
            "Created",
            "FreeBusyChanged"});
            this.checkedListBoxEvents.Location = new System.Drawing.Point(55, 98);
            this.checkedListBoxEvents.Name = "checkedListBoxEvents";
            this.checkedListBoxEvents.Size = new System.Drawing.Size(259, 49);
            this.checkedListBoxEvents.TabIndex = 9;
            this.checkedListBoxEvents.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxEvents_ItemCheck);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.numericUpDownPollInterval);
            this.groupBox3.Controls.Add(this.checkBoxAutoPoll);
            this.groupBox3.Controls.Add(this.buttonPoll);
            this.groupBox3.Location = new System.Drawing.Point(629, 333);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(142, 132);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Polling";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(81, 107);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "seconds";
            // 
            // numericUpDownPollInterval
            // 
            this.numericUpDownPollInterval.Location = new System.Drawing.Point(44, 84);
            this.numericUpDownPollInterval.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDownPollInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPollInterval.Name = "numericUpDownPollInterval";
            this.numericUpDownPollInterval.Size = new System.Drawing.Size(84, 20);
            this.numericUpDownPollInterval.TabIndex = 2;
            this.numericUpDownPollInterval.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDownPollInterval.ValueChanged += new System.EventHandler(this.numericUpDownPollInterval_ValueChanged);
            // 
            // checkBoxAutoPoll
            // 
            this.checkBoxAutoPoll.AutoSize = true;
            this.checkBoxAutoPoll.Location = new System.Drawing.Point(6, 48);
            this.checkBoxAutoPoll.Name = "checkBoxAutoPoll";
            this.checkBoxAutoPoll.Size = new System.Drawing.Size(119, 30);
            this.checkBoxAutoPoll.TabIndex = 1;
            this.checkBoxAutoPoll.Text = "Automatically poll at\r\nthis interval:";
            this.checkBoxAutoPoll.UseVisualStyleBackColor = true;
            this.checkBoxAutoPoll.CheckedChanged += new System.EventHandler(this.checkBoxAutoPoll_CheckedChanged);
            // 
            // buttonPoll
            // 
            this.buttonPoll.Location = new System.Drawing.Point(6, 19);
            this.buttonPoll.Name = "buttonPoll";
            this.buttonPoll.Size = new System.Drawing.Size(103, 23);
            this.buttonPoll.TabIndex = 0;
            this.buttonPoll.Text = "Poll for events";
            this.buttonPoll.UseVisualStyleBackColor = true;
            this.buttonPoll.Click += new System.EventHandler(this.buttonPoll_Click);
            // 
            // timerPoll
            // 
            this.timerPoll.Interval = 1000;
            this.timerPoll.Tick += new System.EventHandler(this.timerPoll_Tick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.textBoxLastWatermark);
            this.groupBox4.Controls.Add(this.listBoxEvents);
            this.groupBox4.Controls.Add(this.checkBoxIncludeMime);
            this.groupBox4.Controls.Add(this.checkBoxQueryMore);
            this.groupBox4.Controls.Add(this.checkBoxShowFolderEvents);
            this.groupBox4.Controls.Add(this.checkBoxShowItemEvents);
            this.groupBox4.Location = new System.Drawing.Point(12, 333);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(611, 225);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Received Events";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 198);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Last watermark received:";
            // 
            // textBoxLastWatermark
            // 
            this.textBoxLastWatermark.Location = new System.Drawing.Point(138, 195);
            this.textBoxLastWatermark.Name = "textBoxLastWatermark";
            this.textBoxLastWatermark.ReadOnly = true;
            this.textBoxLastWatermark.Size = new System.Drawing.Size(467, 20);
            this.textBoxLastWatermark.TabIndex = 23;
            // 
            // listBoxEvents
            // 
            this.listBoxEvents.FormattingEnabled = true;
            this.listBoxEvents.Location = new System.Drawing.Point(6, 42);
            this.listBoxEvents.Name = "listBoxEvents";
            this.listBoxEvents.Size = new System.Drawing.Size(599, 147);
            this.listBoxEvents.TabIndex = 22;
            this.listBoxEvents.DoubleClick += new System.EventHandler(this.listBoxEvents_DoubleClick);
            // 
            // checkBoxIncludeMime
            // 
            this.checkBoxIncludeMime.AutoSize = true;
            this.checkBoxIncludeMime.Checked = true;
            this.checkBoxIncludeMime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIncludeMime.Location = new System.Drawing.Point(295, 19);
            this.checkBoxIncludeMime.Name = "checkBoxIncludeMime";
            this.checkBoxIncludeMime.Size = new System.Drawing.Size(92, 17);
            this.checkBoxIncludeMime.TabIndex = 21;
            this.checkBoxIncludeMime.Text = "Include MIME";
            this.checkBoxIncludeMime.UseVisualStyleBackColor = true;
            // 
            // checkBoxQueryMore
            // 
            this.checkBoxQueryMore.AutoSize = true;
            this.checkBoxQueryMore.Checked = true;
            this.checkBoxQueryMore.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxQueryMore.Location = new System.Drawing.Point(189, 19);
            this.checkBoxQueryMore.Name = "checkBoxQueryMore";
            this.checkBoxQueryMore.Size = new System.Drawing.Size(100, 17);
            this.checkBoxQueryMore.TabIndex = 18;
            this.checkBoxQueryMore.Text = "Query extra info";
            this.checkBoxQueryMore.UseVisualStyleBackColor = true;
            this.checkBoxQueryMore.CheckedChanged += new System.EventHandler(this.checkBoxQueryMore_CheckedChanged);
            // 
            // checkBoxShowFolderEvents
            // 
            this.checkBoxShowFolderEvents.AutoSize = true;
            this.checkBoxShowFolderEvents.Location = new System.Drawing.Point(93, 19);
            this.checkBoxShowFolderEvents.Name = "checkBoxShowFolderEvents";
            this.checkBoxShowFolderEvents.Size = new System.Drawing.Size(90, 17);
            this.checkBoxShowFolderEvents.TabIndex = 20;
            this.checkBoxShowFolderEvents.Text = "Folder events";
            this.checkBoxShowFolderEvents.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowItemEvents
            // 
            this.checkBoxShowItemEvents.AutoSize = true;
            this.checkBoxShowItemEvents.Checked = true;
            this.checkBoxShowItemEvents.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowItemEvents.Location = new System.Drawing.Point(6, 19);
            this.checkBoxShowItemEvents.Name = "checkBoxShowItemEvents";
            this.checkBoxShowItemEvents.Size = new System.Drawing.Size(81, 17);
            this.checkBoxShowItemEvents.TabIndex = 19;
            this.checkBoxShowItemEvents.Text = "Item events";
            this.checkBoxShowItemEvents.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBoxOAuthAuthMethod);
            this.groupBox5.Controls.Add(this.buttonLoadCertificate);
            this.groupBox5.Controls.Add(this.textBoxTenantId);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.textBoxApplicationId);
            this.groupBox5.Controls.Add(this.radioButtonAuthOAuth);
            this.groupBox5.Controls.Add(this.radioButtonAuthBasic);
            this.groupBox5.Controls.Add(this.textBoxUsername);
            this.groupBox5.Controls.Add(this.textBoxPassword);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Location = new System.Drawing.Point(12, 97);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(425, 230);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Authentication";
            // 
            // groupBoxOAuthAuthMethod
            // 
            this.groupBoxOAuthAuthMethod.Controls.Add(this.radioButtonAuthClientCredentials);
            this.groupBoxOAuthAuthMethod.Controls.Add(this.buttonSelectCertificate);
            this.groupBoxOAuthAuthMethod.Controls.Add(this.radioButtonAuthWithClientSecret);
            this.groupBoxOAuthAuthMethod.Controls.Add(this.textBoxAuthCertificate);
            this.groupBoxOAuthAuthMethod.Controls.Add(this.textBoxClientSecret);
            this.groupBoxOAuthAuthMethod.Controls.Add(this.radioButtonAuthWithCertificate);
            this.groupBoxOAuthAuthMethod.Location = new System.Drawing.Point(34, 142);
            this.groupBoxOAuthAuthMethod.Name = "groupBoxOAuthAuthMethod";
            this.groupBoxOAuthAuthMethod.Size = new System.Drawing.Size(324, 80);
            this.groupBoxOAuthAuthMethod.TabIndex = 37;
            this.groupBoxOAuthAuthMethod.TabStop = false;
            this.groupBoxOAuthAuthMethod.Text = "Auth method";
            // 
            // radioButtonAuthClientCredentials
            // 
            this.radioButtonAuthClientCredentials.AutoSize = true;
            this.radioButtonAuthClientCredentials.Checked = true;
            this.radioButtonAuthClientCredentials.Location = new System.Drawing.Point(5, 59);
            this.radioButtonAuthClientCredentials.Name = "radioButtonAuthClientCredentials";
            this.radioButtonAuthClientCredentials.Size = new System.Drawing.Size(106, 17);
            this.radioButtonAuthClientCredentials.TabIndex = 38;
            this.radioButtonAuthClientCredentials.TabStop = true;
            this.radioButtonAuthClientCredentials.Text = "Client Credentials";
            this.radioButtonAuthClientCredentials.UseVisualStyleBackColor = true;
            this.radioButtonAuthClientCredentials.CheckedChanged += new System.EventHandler(this.radioButtonAuthClientCredentials_CheckedChanged);
            // 
            // buttonSelectCertificate
            // 
            this.buttonSelectCertificate.Location = new System.Drawing.Point(257, 38);
            this.buttonSelectCertificate.Name = "buttonSelectCertificate";
            this.buttonSelectCertificate.Size = new System.Drawing.Size(52, 20);
            this.buttonSelectCertificate.TabIndex = 37;
            this.buttonSelectCertificate.Text = "Select...";
            this.buttonSelectCertificate.UseVisualStyleBackColor = true;
            this.buttonSelectCertificate.Click += new System.EventHandler(this.buttonSelectCertificate_Click);
            // 
            // radioButtonAuthWithClientSecret
            // 
            this.radioButtonAuthWithClientSecret.AutoSize = true;
            this.radioButtonAuthWithClientSecret.Location = new System.Drawing.Point(5, 19);
            this.radioButtonAuthWithClientSecret.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.radioButtonAuthWithClientSecret.Name = "radioButtonAuthWithClientSecret";
            this.radioButtonAuthWithClientSecret.Size = new System.Drawing.Size(86, 17);
            this.radioButtonAuthWithClientSecret.TabIndex = 32;
            this.radioButtonAuthWithClientSecret.Tag = "NoTextSave";
            this.radioButtonAuthWithClientSecret.Text = "Client secret:";
            this.radioButtonAuthWithClientSecret.UseVisualStyleBackColor = true;
            this.radioButtonAuthWithClientSecret.CheckedChanged += new System.EventHandler(this.radioButtonAuthWithClientSecret_CheckedChanged);
            // 
            // textBoxAuthCertificate
            // 
            this.textBoxAuthCertificate.Location = new System.Drawing.Point(94, 38);
            this.textBoxAuthCertificate.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.textBoxAuthCertificate.Name = "textBoxAuthCertificate";
            this.textBoxAuthCertificate.Size = new System.Drawing.Size(162, 20);
            this.textBoxAuthCertificate.TabIndex = 36;
            // 
            // textBoxClientSecret
            // 
            this.textBoxClientSecret.Location = new System.Drawing.Point(94, 16);
            this.textBoxClientSecret.Name = "textBoxClientSecret";
            this.textBoxClientSecret.Size = new System.Drawing.Size(215, 20);
            this.textBoxClientSecret.TabIndex = 33;
            this.textBoxClientSecret.UseSystemPasswordChar = true;
            // 
            // radioButtonAuthWithCertificate
            // 
            this.radioButtonAuthWithCertificate.AutoSize = true;
            this.radioButtonAuthWithCertificate.Location = new System.Drawing.Point(5, 38);
            this.radioButtonAuthWithCertificate.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.radioButtonAuthWithCertificate.Name = "radioButtonAuthWithCertificate";
            this.radioButtonAuthWithCertificate.Size = new System.Drawing.Size(75, 17);
            this.radioButtonAuthWithCertificate.TabIndex = 34;
            this.radioButtonAuthWithCertificate.Tag = "NoTextSave";
            this.radioButtonAuthWithCertificate.Text = "Certificate:";
            this.radioButtonAuthWithCertificate.UseVisualStyleBackColor = true;
            this.radioButtonAuthWithCertificate.CheckedChanged += new System.EventHandler(this.radioButtonAuthWithCertificate_CheckedChanged);
            // 
            // buttonLoadCertificate
            // 
            this.buttonLoadCertificate.Location = new System.Drawing.Point(497, 196);
            this.buttonLoadCertificate.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonLoadCertificate.Name = "buttonLoadCertificate";
            this.buttonLoadCertificate.Size = new System.Drawing.Size(50, 21);
            this.buttonLoadCertificate.TabIndex = 35;
            this.buttonLoadCertificate.Text = "Select...";
            this.buttonLoadCertificate.UseVisualStyleBackColor = true;
            // 
            // textBoxTenantId
            // 
            this.textBoxTenantId.Location = new System.Drawing.Point(119, 92);
            this.textBoxTenantId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxTenantId.Name = "textBoxTenantId";
            this.textBoxTenantId.Size = new System.Drawing.Size(215, 20);
            this.textBoxTenantId.TabIndex = 24;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(31, 117);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Application ID*:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(31, 95);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 13);
            this.label13.TabIndex = 23;
            this.label13.Tag = "";
            this.label13.Text = "Tenant ID*:";
            // 
            // textBoxApplicationId
            // 
            this.textBoxApplicationId.Location = new System.Drawing.Point(119, 114);
            this.textBoxApplicationId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxApplicationId.Name = "textBoxApplicationId";
            this.textBoxApplicationId.Size = new System.Drawing.Size(215, 20);
            this.textBoxApplicationId.TabIndex = 25;
            // 
            // radioButtonAuthOAuth
            // 
            this.radioButtonAuthOAuth.AutoSize = true;
            this.radioButtonAuthOAuth.Checked = true;
            this.radioButtonAuthOAuth.Location = new System.Drawing.Point(14, 75);
            this.radioButtonAuthOAuth.Name = "radioButtonAuthOAuth";
            this.radioButtonAuthOAuth.Size = new System.Drawing.Size(55, 17);
            this.radioButtonAuthOAuth.TabIndex = 1;
            this.radioButtonAuthOAuth.TabStop = true;
            this.radioButtonAuthOAuth.Text = "OAuth";
            this.radioButtonAuthOAuth.UseVisualStyleBackColor = true;
            this.radioButtonAuthOAuth.CheckedChanged += new System.EventHandler(this.radioButtonAuthOAuth_CheckedChanged);
            // 
            // radioButtonAuthBasic
            // 
            this.radioButtonAuthBasic.AutoSize = true;
            this.radioButtonAuthBasic.Location = new System.Drawing.Point(14, 24);
            this.radioButtonAuthBasic.Name = "radioButtonAuthBasic";
            this.radioButtonAuthBasic.Size = new System.Drawing.Size(182, 17);
            this.radioButtonAuthBasic.TabIndex = 0;
            this.radioButtonAuthBasic.Text = "Basic auth (inc. NTLM, Kerberos)";
            this.radioButtonAuthBasic.UseVisualStyleBackColor = true;
            this.radioButtonAuthBasic.CheckedChanged += new System.EventHandler(this.radioButtonAuthBasic_CheckedChanged);
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(95, 47);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(128, 20);
            this.textBoxUsername.TabIndex = 0;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(291, 47);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(117, 20);
            this.textBoxPassword.TabIndex = 1;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(31, 50);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "Username:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(229, 50);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 13);
            this.label15.TabIndex = 3;
            this.label15.Text = "Password:";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 566);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.Text = "EWS Pull Notification Sample Application";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeout)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPollInterval)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBoxOAuthAuthMethod.ResumeLayout(false);
            this.groupBoxOAuthAuthMethod.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxMailbox;
        private System.Windows.Forms.Button buttonSubscribe;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxExchangeVersion;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxSubscribeTo;
        private System.Windows.Forms.CheckedListBox checkedListBoxEvents;
        private System.Windows.Forms.CheckBox checkBoxSelectAll;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDownTimeout;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDownPollInterval;
        private System.Windows.Forms.CheckBox checkBoxAutoPoll;
        private System.Windows.Forms.Button buttonPoll;
        private System.Windows.Forms.Timer timerPoll;
        private System.Windows.Forms.RadioButton radioButtonAutodiscover;
        private System.Windows.Forms.RadioButton radioButtonEwsUrl;
        private System.Windows.Forms.TextBox textBoxEwsUrl;
        private System.Windows.Forms.CheckBox checkBoxIgnoreCert;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxWatermark;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxLastWatermark;
        private System.Windows.Forms.ListBox listBoxEvents;
        private System.Windows.Forms.CheckBox checkBoxIncludeMime;
        private System.Windows.Forms.CheckBox checkBoxQueryMore;
        private System.Windows.Forms.CheckBox checkBoxShowFolderEvents;
        private System.Windows.Forms.CheckBox checkBoxShowItemEvents;
        private System.Windows.Forms.CheckBox checkBoxIncludeSubfolders;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton radioButtonExchangeOnline;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBoxOAuthAuthMethod;
        private System.Windows.Forms.Button buttonSelectCertificate;
        private System.Windows.Forms.RadioButton radioButtonAuthWithClientSecret;
        private System.Windows.Forms.TextBox textBoxAuthCertificate;
        private System.Windows.Forms.TextBox textBoxClientSecret;
        private System.Windows.Forms.RadioButton radioButtonAuthWithCertificate;
        private System.Windows.Forms.Button buttonLoadCertificate;
        private System.Windows.Forms.TextBox textBoxTenantId;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxApplicationId;
        private System.Windows.Forms.RadioButton radioButtonAuthOAuth;
        private System.Windows.Forms.RadioButton radioButtonAuthBasic;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button buttonUnsubscribe;
        private System.Windows.Forms.RadioButton radioButtonAuthClientCredentials;
        private System.Windows.Forms.CheckBox checkBoxImpersonate;
    }
}

