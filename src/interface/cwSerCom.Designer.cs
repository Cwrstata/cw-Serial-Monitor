


namespace Exp
{
   
    partial class cwSerCom
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            ToolStripSeparator toolStripSeparator2;
            ToolStripMenuItem programFolderToolStripMenuItem;
            Button Disconnect;
            Button Refresh;
            ToolStripMenuItem settingsToolStripMenuItem;
            ToolStripMenuItem aboutToolStripMenuItem;
            ToolStripMenuItem repositoryToolStripMenuItem;
            ToolStripMenuItem infoToolStripMenuItem;
            Button Connect;
            Label label2;
            FlowLayoutPanel flowLayoutPanel1;
            Button button_Settings2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cwSerCom));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            panel1 = new Panel();
            status = new Label();
            led = new Label();
            label3 = new Label();
            viewToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            portSelectorToolStripMenuItem = new ToolStripMenuItem();
            serialSettingsToolStripMenuItem = new ToolStripMenuItem();
            serialMonitorToolStripMenuItem = new ToolStripMenuItem();
            serialInfoToolStripMenuItem = new ToolStripMenuItem();
            label_Info = new Label();
            dGridSerial = new DataGridView();
            comPortsList = new ListBox();
            dGridInfo = new DataGridView();
            textBoxMonitor = new RichTextBox();
            splitMain = new SplitContainer();
            splitContainer2 = new SplitContainer();
            Check_Pin = new CheckBox();
            serialNewline = new cwBorderComboBox();
            SerialSend = new TextBox();
            ClearSerial = new Button();
            menuStrip1 = new MenuStrip();
            portToolStripMenuItem = new ToolStripMenuItem();
            connectToolStripMenuItem = new ToolStripMenuItem();
            disconnectToolStripMenuItem = new ToolStripMenuItem();
            folderBrowserDialog1 = new FolderBrowserDialog();
            imageList1 = new ImageList(components);
            toolStripSeparator2 = new ToolStripSeparator();
            programFolderToolStripMenuItem = new ToolStripMenuItem();
            Disconnect = new Button();
            Refresh = new Button();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            repositoryToolStripMenuItem = new ToolStripMenuItem();
            infoToolStripMenuItem = new ToolStripMenuItem();
            Connect = new Button();
            label2 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            button_Settings2 = new Button();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dGridSerial).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dGridInfo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitMain).BeginInit();
            splitMain.Panel1.SuspendLayout();
            splitMain.Panel2.SuspendLayout();
            splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(153, 6);
            // 
            // programFolderToolStripMenuItem
            // 
            programFolderToolStripMenuItem.Name = "programFolderToolStripMenuItem";
            programFolderToolStripMenuItem.Size = new Size(156, 22);
            programFolderToolStripMenuItem.Text = "Program Folder";
            programFolderToolStripMenuItem.Click += programFolderToolStripMenuItem_Click;
            // 
            // Disconnect
            // 
            Disconnect.Location = new Point(4, 34);
            Disconnect.Margin = new Padding(4, 3, 4, 3);
            Disconnect.Name = "Disconnect";
            Disconnect.Size = new Size(104, 25);
            Disconnect.TabIndex = 1;
            Disconnect.Text = "Disconnect";
            Disconnect.UseVisualStyleBackColor = true;
            Disconnect.Click += Button_Disconnect;
            // 
            // Refresh
            // 
            Refresh.Location = new Point(4, 65);
            Refresh.Margin = new Padding(4, 3, 4, 3);
            Refresh.Name = "Refresh";
            Refresh.Size = new Size(104, 25);
            Refresh.TabIndex = 5;
            Refresh.Text = "Refresh";
            Refresh.UseVisualStyleBackColor = true;
            Refresh.Click += Button_Refresh;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Padding = new Padding(6, 0, 6, 0);
            settingsToolStripMenuItem.Size = new Size(65, 20);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { repositoryToolStripMenuItem, infoToolStripMenuItem });
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Padding = new Padding(6, 0, 6, 0);
            aboutToolStripMenuItem.Size = new Size(56, 20);
            aboutToolStripMenuItem.Text = "About";
            // 
            // repositoryToolStripMenuItem
            // 
            repositoryToolStripMenuItem.BackColor = SystemColors.ButtonHighlight;
            repositoryToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            repositoryToolStripMenuItem.Name = "repositoryToolStripMenuItem";
            repositoryToolStripMenuItem.Size = new Size(130, 22);
            repositoryToolStripMenuItem.Text = "Repository";
            repositoryToolStripMenuItem.Click += repositoryToolStripMenuItem_Click;
            repositoryToolStripMenuItem.MouseLeave += CursorToArrow;
            repositoryToolStripMenuItem.MouseHover += CursorToHand;
            // 
            // infoToolStripMenuItem
            // 
            infoToolStripMenuItem.BackColor = SystemColors.Control;
            infoToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            infoToolStripMenuItem.Size = new Size(130, 22);
            infoToolStripMenuItem.Text = "Info";
            infoToolStripMenuItem.TextDirection = ToolStripTextDirection.Horizontal;
            infoToolStripMenuItem.Click += infoToolStripMenuItem_Click;
            // 
            // Connect
            // 
            Connect.Location = new Point(4, 3);
            Connect.Margin = new Padding(4, 3, 4, 3);
            Connect.Name = "Connect";
            Connect.Size = new Size(104, 25);
            Connect.TabIndex = 0;
            Connect.Text = "Connect";
            Connect.UseVisualStyleBackColor = true;
            Connect.Click += Button_Connect;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.BackColor = SystemColors.ControlLight;
            label2.FlatStyle = FlatStyle.Flat;
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(403, 0);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(183, 28);
            label2.TabIndex = 9;
            label2.Text = "New line:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(Connect);
            flowLayoutPanel1.Controls.Add(Disconnect);
            flowLayoutPanel1.Controls.Add(Refresh);
            flowLayoutPanel1.Controls.Add(panel1);
            flowLayoutPanel1.Controls.Add(label3);
            flowLayoutPanel1.Dock = DockStyle.Right;
            flowLayoutPanel1.Location = new Point(227, 0);
            flowLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(113, 152);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(status);
            panel1.Controls.Add(led);
            panel1.Location = new Point(4, 96);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(103, 25);
            panel1.TabIndex = 4;
            // 
            // status
            // 
            status.AutoSize = true;
            status.BackColor = Color.Transparent;
            status.Font = new Font("Segoe UI", 9F);
            status.Location = new Point(19, 3);
            status.Margin = new Padding(4, 0, 4, 0);
            status.Name = "status";
            status.Size = new Size(79, 15);
            status.TabIndex = 3;
            status.Text = "Disconnected";
            status.TextAlign = ContentAlignment.MiddleRight;
            status.UseMnemonic = false;
            // 
            // led
            // 
            led.BackColor = Color.Transparent;
            led.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 2);
            led.ForeColor = Color.Red;
            led.Location = new Point(-1, -4);
            led.Margin = new Padding(4, 0, 4, 0);
            led.Name = "led";
            led.Size = new Size(33, 28);
            led.TabIndex = 2;
            led.Text = "l";
            led.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlDarkDark;
            label3.Location = new Point(3, 124);
            label3.Name = "label3";
            label3.Size = new Size(105, 16);
            label3.TabIndex = 6;
            label3.Text = "Auto-refresh is disabled";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button_Settings2
            // 
            button_Settings2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_Settings2.BackColor = SystemColors.ControlLight;
            button_Settings2.FlatStyle = FlatStyle.Popup;
            button_Settings2.Image = (Image)resources.GetObject("button_Settings2.Image");
            button_Settings2.Location = new Point(302, 1);
            button_Settings2.Name = "button_Settings2";
            button_Settings2.Size = new Size(38, 23);
            button_Settings2.TabIndex = 4;
            button_Settings2.UseVisualStyleBackColor = false;
            button_Settings2.Click += button1_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripSeparator1, portSelectorToolStripMenuItem, serialSettingsToolStripMenuItem, serialMonitorToolStripMenuItem, serialInfoToolStripMenuItem, toolStripSeparator2, programFolderToolStripMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Padding = new Padding(6, 0, 6, 0);
            viewToolStripMenuItem.Size = new Size(48, 20);
            viewToolStripMenuItem.Text = "View";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(153, 6);
            // 
            // portSelectorToolStripMenuItem
            // 
            portSelectorToolStripMenuItem.Checked = true;
            portSelectorToolStripMenuItem.CheckState = CheckState.Checked;
            portSelectorToolStripMenuItem.Name = "portSelectorToolStripMenuItem";
            portSelectorToolStripMenuItem.Size = new Size(156, 22);
            portSelectorToolStripMenuItem.Text = "Port Selector";
            portSelectorToolStripMenuItem.Click += portSelectorMenuItem2_Click;
            // 
            // serialSettingsToolStripMenuItem
            // 
            serialSettingsToolStripMenuItem.Checked = true;
            serialSettingsToolStripMenuItem.CheckState = CheckState.Checked;
            serialSettingsToolStripMenuItem.Name = "serialSettingsToolStripMenuItem";
            serialSettingsToolStripMenuItem.Size = new Size(156, 22);
            serialSettingsToolStripMenuItem.Text = "Serial Settings";
            serialSettingsToolStripMenuItem.Click += serialSettingsToolStripMenuItem_Click;
            // 
            // serialMonitorToolStripMenuItem
            // 
            serialMonitorToolStripMenuItem.Checked = true;
            serialMonitorToolStripMenuItem.CheckState = CheckState.Checked;
            serialMonitorToolStripMenuItem.Name = "serialMonitorToolStripMenuItem";
            serialMonitorToolStripMenuItem.Size = new Size(156, 22);
            serialMonitorToolStripMenuItem.Text = "Serial Monitor";
            serialMonitorToolStripMenuItem.Click += serialMonitorToolStripMenuItem_Click;
            // 
            // serialInfoToolStripMenuItem
            // 
            serialInfoToolStripMenuItem.Checked = true;
            serialInfoToolStripMenuItem.CheckState = CheckState.Checked;
            serialInfoToolStripMenuItem.Name = "serialInfoToolStripMenuItem";
            serialInfoToolStripMenuItem.Size = new Size(156, 22);
            serialInfoToolStripMenuItem.Text = "Serial Info";
            serialInfoToolStripMenuItem.Click += serialInfoToolStripMenuItem_Click;
            // 
            // label_Info
            // 
            label_Info.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label_Info.BackColor = SystemColors.ControlLight;
            label_Info.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Info.ForeColor = SystemColors.ControlDarkDark;
            label_Info.Location = new Point(0, 0);
            label_Info.Margin = new Padding(0);
            label_Info.Name = "label_Info";
            label_Info.Size = new Size(401, 28);
            label_Info.TabIndex = 7;
            label_Info.TextAlign = ContentAlignment.MiddleLeft;
            label_Info.Click += label1_Click;
            // 
            // dGridSerial
            // 
            dGridSerial.AllowUserToAddRows = false;
            dGridSerial.AllowUserToDeleteRows = false;
            dGridSerial.AllowUserToResizeColumns = false;
            dGridSerial.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = SystemColors.ControlDarkDark;
            dGridSerial.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dGridSerial.BackgroundColor = SystemColors.Control;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlDark;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dGridSerial.DefaultCellStyle = dataGridViewCellStyle2;
            dGridSerial.Dock = DockStyle.Top;
            dGridSerial.EditMode = DataGridViewEditMode.EditOnEnter;
            dGridSerial.GridColor = SystemColors.ControlLight;
            dGridSerial.ImeMode = ImeMode.Off;
            dGridSerial.Location = new Point(0, 0);
            dGridSerial.Margin = new Padding(4, 3, 4, 3);
            dGridSerial.MultiSelect = false;
            dGridSerial.Name = "dGridSerial";
            dGridSerial.RowHeadersVisible = false;
            dGridSerial.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.BackColor = SystemColors.ButtonShadow;
            dGridSerial.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dGridSerial.RowTemplate.DefaultCellStyle.BackColor = SystemColors.Control;
            dGridSerial.RowTemplate.Height = 50;
            dGridSerial.ScrollBars = ScrollBars.None;
            dGridSerial.ShowEditingIcon = false;
            dGridSerial.Size = new Size(340, 159);
            dGridSerial.TabIndex = 2;
            dGridSerial.TabStop = false;
            dGridSerial.CellClick += dGridSerial_CellClick;
            // 
            // comPortsList
            // 
            comPortsList.Dock = DockStyle.Fill;
            comPortsList.DrawMode = DrawMode.OwnerDrawVariable;
            comPortsList.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comPortsList.FormattingEnabled = true;
            comPortsList.IntegralHeight = false;
            comPortsList.ItemHeight = 24;
            comPortsList.Location = new Point(0, 0);
            comPortsList.Margin = new Padding(4, 3, 4, 3);
            comPortsList.Name = "comPortsList";
            comPortsList.Size = new Size(227, 152);
            comPortsList.TabIndex = 0;
            comPortsList.DrawItem += comPortsList_DrawItem;
            comPortsList.SelectedIndexChanged += comPortList_SelectedIndexChanged;
            comPortsList.Resize += comPortsList_Resize;
            // 
            // dGridInfo
            // 
            dGridInfo.AllowUserToAddRows = false;
            dGridInfo.AllowUserToDeleteRows = false;
            dGridInfo.AllowUserToResizeColumns = false;
            dGridInfo.AllowUserToResizeRows = false;
            dGridInfo.BackgroundColor = SystemColors.Control;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.ControlLightLight;
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.ControlDark;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dGridInfo.DefaultCellStyle = dataGridViewCellStyle4;
            dGridInfo.Dock = DockStyle.Fill;
            dGridInfo.GridColor = SystemColors.ControlLight;
            dGridInfo.ImeMode = ImeMode.Off;
            dGridInfo.Location = new Point(0, 159);
            dGridInfo.Margin = new Padding(4, 3, 4, 3);
            dGridInfo.Name = "dGridInfo";
            dGridInfo.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = SystemColors.ControlLightLight;
            dGridInfo.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dGridInfo.RowTemplate.DefaultCellStyle.BackColor = SystemColors.ControlLightLight;
            dGridInfo.RowTemplate.ReadOnly = true;
            dGridInfo.ScrollBars = ScrollBars.Horizontal;
            dGridInfo.ShowEditingIcon = false;
            dGridInfo.Size = new Size(340, 175);
            dGridInfo.TabIndex = 3;
            dGridInfo.TabStop = false;
            dGridInfo.Resize += dGridInfo_Move;
            // 
            // textBoxMonitor
            // 
            textBoxMonitor.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxMonitor.BorderStyle = BorderStyle.None;
            textBoxMonitor.DetectUrls = false;
            textBoxMonitor.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxMonitor.HideSelection = false;
            textBoxMonitor.Location = new Point(17, 29);
            textBoxMonitor.Margin = new Padding(5);
            textBoxMonitor.MaximumSize = new Size(11665, 11537);
            textBoxMonitor.MaxLength = 500000;
            textBoxMonitor.Name = "textBoxMonitor";
            textBoxMonitor.ReadOnly = true;
            textBoxMonitor.ScrollBars = RichTextBoxScrollBars.Vertical;
            textBoxMonitor.ShortcutsEnabled = false;
            textBoxMonitor.Size = new Size(569, 424);
            textBoxMonitor.TabIndex = 3;
            textBoxMonitor.TabStop = false;
            textBoxMonitor.Text = "";
            textBoxMonitor.KeyPress += textBox1_KeyPress;
            // 
            // splitMain
            // 
            splitMain.BorderStyle = BorderStyle.FixedSingle;
            splitMain.Dock = DockStyle.Fill;
            splitMain.Location = new Point(0, 24);
            splitMain.Margin = new Padding(0);
            splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            splitMain.Panel1.Controls.Add(splitContainer2);
            splitMain.Panel1.RightToLeft = RightToLeft.No;
            // 
            // splitMain.Panel2
            // 
            splitMain.Panel2.BackgroundImageLayout = ImageLayout.None;
            splitMain.Panel2.Controls.Add(Check_Pin);
            splitMain.Panel2.Controls.Add(serialNewline);
            splitMain.Panel2.Controls.Add(label2);
            splitMain.Panel2.Controls.Add(label_Info);
            splitMain.Panel2.Controls.Add(SerialSend);
            splitMain.Panel2.Controls.Add(textBoxMonitor);
            splitMain.Panel2.Controls.Add(ClearSerial);
            splitMain.Panel2.RightToLeft = RightToLeft.No;
            splitMain.Size = new Size(933, 495);
            splitMain.SplitterDistance = 342;
            splitMain.TabIndex = 4;
            // 
            // splitContainer2
            // 
            splitContainer2.BorderStyle = BorderStyle.FixedSingle;
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Margin = new Padding(4, 3, 4, 3);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(comPortsList);
            splitContainer2.Panel1.Controls.Add(flowLayoutPanel1);
            splitContainer2.Panel1.RightToLeft = RightToLeft.No;
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(button_Settings2);
            splitContainer2.Panel2.Controls.Add(dGridInfo);
            splitContainer2.Panel2.Controls.Add(dGridSerial);
            splitContainer2.Panel2.RightToLeft = RightToLeft.No;
            splitContainer2.Size = new Size(342, 495);
            splitContainer2.SplitterDistance = 154;
            splitContainer2.SplitterWidth = 5;
            splitContainer2.TabIndex = 5;
            // 
            // Check_Pin
            // 
            Check_Pin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Check_Pin.Appearance = Appearance.Button;
            Check_Pin.FlatStyle = FlatStyle.Popup;
            Check_Pin.Image = (Image)resources.GetObject("Check_Pin.Image");
            Check_Pin.Location = new Point(544, 3);
            Check_Pin.Name = "Check_Pin";
            Check_Pin.Size = new Size(35, 23);
            Check_Pin.TabIndex = 10;
            Check_Pin.UseVisualStyleBackColor = true;
            Check_Pin.CheckedChanged += Check_Pin_CheckedChanged;
            // 
            // serialNewline
            // 
            serialNewline.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            serialNewline.BackColor = SystemColors.ControlLight;
            serialNewline.Borders = ScrollBars.Horizontal;
            serialNewline.BorderStyle = Color.DarkGray;
            serialNewline.DropDownStyle = ComboBoxStyle.DropDownList;
            serialNewline.FlatStyle = FlatStyle.Popup;
            serialNewline.Font = new Font("Microsoft YaHei", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            serialNewline.ForeColor = SystemColors.ControlDarkDark;
            serialNewline.Items.AddRange(new object[] { "\\n", "\\r", "\\r\\n", "none" });
            serialNewline.Location = new Point(463, 2);
            serialNewline.Name = "serialNewline";
            serialNewline.Size = new Size(58, 24);
            serialNewline.TabIndex = 8;
            serialNewline.SelectedIndexChanged += serialNewline_SelectedIndexChanged;
            // 
            // SerialSend
            // 
            SerialSend.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SerialSend.Font = new Font("Microsoft Sans Serif", 8.9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SerialSend.Location = new Point(9, 461);
            SerialSend.Margin = new Padding(4, 3, 4, 3);
            SerialSend.Name = "SerialSend";
            SerialSend.Size = new Size(457, 21);
            SerialSend.TabIndex = 4;
            SerialSend.WordWrap = false;
            SerialSend.KeyDown += SerialSend_KeyDown;
            // 
            // ClearSerial
            // 
            ClearSerial.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ClearSerial.Font = new Font("Microsoft Sans Serif", 8.25F);
            ClearSerial.Location = new Point(474, 460);
            ClearSerial.Margin = new Padding(4, 0, 4, 0);
            ClearSerial.Name = "ClearSerial";
            ClearSerial.Size = new Size(99, 22);
            ClearSerial.TabIndex = 6;
            ClearSerial.Text = "Clear";
            ClearSerial.UseVisualStyleBackColor = true;
            ClearSerial.Click += Button_Clear;
            // 
            // menuStrip1
            // 
            menuStrip1.GripMargin = new Padding(2);
            menuStrip1.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem, viewToolStripMenuItem, portToolStripMenuItem, aboutToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(933, 24);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // portToolStripMenuItem
            // 
            portToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { connectToolStripMenuItem, disconnectToolStripMenuItem });
            portToolStripMenuItem.Name = "portToolStripMenuItem";
            portToolStripMenuItem.Padding = new Padding(6, 0, 6, 0);
            portToolStripMenuItem.Size = new Size(45, 20);
            portToolStripMenuItem.Text = "Port";
            // 
            // connectToolStripMenuItem
            // 
            connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            connectToolStripMenuItem.Size = new Size(133, 22);
            connectToolStripMenuItem.Text = "Connect";
            // 
            // disconnectToolStripMenuItem
            // 
            disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            disconnectToolStripMenuItem.Size = new Size(133, 22);
            disconnectToolStripMenuItem.Text = "Disconnect";
            disconnectToolStripMenuItem.Click += Button_Disconnect;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "bhl.png");
            imageList1.Images.SetKeyName(1, "bhl_sel.png");
            imageList1.Images.SetKeyName(2, "usb.png");
            imageList1.Images.SetKeyName(3, "usb_sel.png");
            // 
            // cwSerCom
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 519);
            Controls.Add(splitMain);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(600, 400);
            Name = "cwSerCom";
            Text = "cwSerialMonitor";
            Load += cwSerCom_Load;
            Shown += cwSerCom_Shown;
            flowLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dGridSerial).EndInit();
            ((System.ComponentModel.ISupportInitialize)dGridInfo).EndInit();
            splitMain.Panel1.ResumeLayout(false);
            splitMain.Panel2.ResumeLayout(false);
            splitMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitMain).EndInit();
            splitMain.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox comPortsList;
        private System.Windows.Forms.DataGridView dGridInfo;
        
        private System.Windows.Forms.RichTextBox textBoxMonitor;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.SplitContainer splitContainer2;
        
        
        

        private System.Windows.Forms.Label led;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Panel panel1;
        
        private System.Windows.Forms.TextBox SerialSend;
        private System.Windows.Forms.Button ClearSerial;
        private System.Windows.Forms.DataGridView dGridSerial;
        private System.Windows.Forms.Label label_Info;
        private System.Windows.Forms.MenuStrip menuStrip1;

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem portSelectorToolStripMenuItem;
        
        private System.Windows.Forms.ToolStripMenuItem serialSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serialMonitorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serialInfoToolStripMenuItem;

        private FolderBrowserDialog folderBrowserDialog1;
        private cwBorderComboBox serialNewline;

      
        private Label label3;
        private ToolStripMenuItem viewToolStripMenuItem;
        private CheckBox Check_Pin;
        private ToolStripMenuItem portToolStripMenuItem;
        private ToolStripMenuItem disconnectToolStripMenuItem;
        private ToolStripMenuItem connectToolStripMenuItem;
        private ImageList imageList1;
    }
}

