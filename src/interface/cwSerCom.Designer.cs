


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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cwSerCom));
            listBox1 = new ListBox();
            dGridInfo = new DataGridView();
            textBox1 = new TextBox();
            splitMain = new SplitContainer();
            splitContainer2 = new SplitContainer();
            flowLayoutPanel1 = new FlowLayoutPanel();
            Connect = new Button();
            Disconnect = new Button();
            Refresh = new Button();
            panel1 = new Panel();
            status = new Label();
            led = new Label();
            dGridSerial = new DataGridView();
            label1 = new Label();
            SerialSend = new TextBox();
            ClearSerial = new Button();
            menuStrip1 = new MenuStrip();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripMenuItem2 = new ToolStripMenuItem();
            serialSettingsToolStripMenuItem = new ToolStripMenuItem();
            serialMonitorToolStripMenuItem = new ToolStripMenuItem();
            serialInfoToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            repositoryToolStripMenuItem = new ToolStripMenuItem();
            infoToolStripMenuItem = new ToolStripMenuItem();
            folderBrowserDialog1 = new FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)dGridInfo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitMain).BeginInit();
            splitMain.Panel1.SuspendLayout();
            splitMain.Panel2.SuspendLayout();
            splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dGridSerial).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.Dock = DockStyle.Fill;
            listBox1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBox1.FormattingEnabled = true;
            listBox1.IntegralHeight = false;
            listBox1.Location = new Point(0, 0);
            listBox1.Margin = new Padding(4, 3, 4, 3);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(227, 152);
            listBox1.TabIndex = 0;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // dGridInfo
            // 
            dGridInfo.AllowUserToAddRows = false;
            dGridInfo.AllowUserToDeleteRows = false;
            dGridInfo.AllowUserToResizeColumns = false;
            dGridInfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlDark;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dGridInfo.DefaultCellStyle = dataGridViewCellStyle1;
            dGridInfo.Dock = DockStyle.Fill;
            dGridInfo.ImeMode = ImeMode.Off;
            dGridInfo.Location = new Point(0, 155);
            dGridInfo.Margin = new Padding(4, 3, 4, 3);
            dGridInfo.Name = "dGridInfo";
            dGridInfo.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = SystemColors.ControlLightLight;
            dGridInfo.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dGridInfo.RowTemplate.DefaultCellStyle.BackColor = SystemColors.ControlLightLight;
            dGridInfo.RowTemplate.ReadOnly = true;
            dGridInfo.ScrollBars = ScrollBars.Horizontal;
            dGridInfo.ShowEditingIcon = false;
            dGridInfo.Size = new Size(340, 179);
            dGridInfo.TabIndex = 3;
            dGridInfo.TabStop = false;
           
            dGridInfo.Move += dGridInfo_Move;
            dGridInfo.Resize += dGridInfo_Move;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.HideSelection = false;
            textBox1.Location = new Point(1, 29);
            textBox1.Margin = new Padding(4);
            textBox1.MaximumSize = new Size(11665, 11537);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(564, 430);
            textBox1.TabIndex = 3;
          
            // 
            // splitMain
            // 
            splitMain.BorderStyle = BorderStyle.FixedSingle;
            splitMain.Dock = DockStyle.Fill;
            splitMain.Location = new Point(0, 24);
            splitMain.Margin = new Padding(4, 3, 4, 3);
            splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            splitMain.Panel1.Controls.Add(splitContainer2);
            // 
            // splitMain.Panel2
            // 
            splitMain.Panel2.Controls.Add(label1);
            splitMain.Panel2.Controls.Add(SerialSend);
            splitMain.Panel2.Controls.Add(textBox1);
            splitMain.Panel2.Controls.Add(ClearSerial);
            splitMain.Panel2.Font = new Font("Segoe Fluent Icons", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            splitMain.Size = new Size(933, 495);
            splitMain.SplitterDistance = 342;
            splitMain.SplitterWidth = 5;
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
            splitContainer2.Panel1.Controls.Add(listBox1);
            splitContainer2.Panel1.Controls.Add(flowLayoutPanel1);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(dGridInfo);
            splitContainer2.Panel2.Controls.Add(dGridSerial);
            splitContainer2.Size = new Size(342, 495);
            splitContainer2.SplitterDistance = 154;
            splitContainer2.SplitterWidth = 5;
            splitContainer2.TabIndex = 5;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(Connect);
            flowLayoutPanel1.Controls.Add(Disconnect);
            flowLayoutPanel1.Controls.Add(Refresh);
            flowLayoutPanel1.Controls.Add(panel1);
            flowLayoutPanel1.Dock = DockStyle.Right;
            flowLayoutPanel1.Location = new Point(227, 0);
            flowLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(113, 152);
            flowLayoutPanel1.TabIndex = 2;
            
            // 
            // Connect
            // 
            Connect.Location = new Point(4, 3);
            Connect.Margin = new Padding(4, 3, 4, 3);
            Connect.Name = "Connect";
            Connect.Size = new Size(104, 27);
            Connect.TabIndex = 0;
            Connect.Text = "Connect";
            Connect.UseVisualStyleBackColor = true;
            // 
            // Disconnect
            // 
            Disconnect.Location = new Point(4, 36);
            Disconnect.Margin = new Padding(4, 3, 4, 3);
            Disconnect.Name = "Disconnect";
            Disconnect.Size = new Size(104, 27);
            Disconnect.TabIndex = 1;
            Disconnect.Text = "Disconnect";
            Disconnect.UseVisualStyleBackColor = true;
            // 
            // Refresh
            // 
            Refresh.Location = new Point(4, 69);
            Refresh.Margin = new Padding(4, 3, 4, 3);
            Refresh.Name = "Refresh";
            Refresh.Size = new Size(104, 27);
            Refresh.TabIndex = 5;
            Refresh.Text = "Refresh";
            Refresh.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(status);
            panel1.Controls.Add(led);
            panel1.Location = new Point(4, 102);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(103, 27);
            panel1.TabIndex = 4;
            // 
            // status
            // 
            status.AutoSize = true;
            status.BackColor = Color.Transparent;
            status.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            status.Location = new Point(18, 5);
            status.Margin = new Padding(4, 0, 4, 0);
            status.Name = "status";
            status.Size = new Size(73, 13);
            status.TabIndex = 3;
            status.Text = "Disconnected";
            status.TextAlign = ContentAlignment.MiddleRight;
            status.UseMnemonic = false;
           
            // 
            // led
            // 
            led.BackColor = Color.Transparent;
            led.Font = new Font("Segoe UI Emoji", 14F, FontStyle.Regular, GraphicsUnit.Point, 2);
            led.ForeColor = Color.Red;
            led.Location = new Point(-2, -2);
            led.Margin = new Padding(4, 0, 4, 0);
            led.Name = "led";
            led.Size = new Size(33, 28);
            led.TabIndex = 2;
            led.Text = "l";
            led.TextAlign = ContentAlignment.MiddleLeft;
            
            // 
            // dGridSerial
            // 
            dGridSerial.AllowUserToAddRows = false;
            dGridSerial.AllowUserToDeleteRows = false;
            dGridSerial.AllowUserToResizeColumns = false;
            dGridSerial.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.ControlLightLight;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.ControlDark;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dGridSerial.DefaultCellStyle = dataGridViewCellStyle3;
            dGridSerial.Dock = DockStyle.Top;
            dGridSerial.EditMode = DataGridViewEditMode.EditOnEnter;
            dGridSerial.ImeMode = ImeMode.Off;
            dGridSerial.Location = new Point(0, 0);
            dGridSerial.Margin = new Padding(4, 3, 4, 3);
            dGridSerial.Name = "dGridSerial";
            dGridSerial.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = SystemColors.ControlLightLight;
            dGridSerial.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dGridSerial.RowTemplate.DefaultCellStyle.BackColor = SystemColors.ControlLightLight;
            dGridSerial.RowTemplate.Height = 50;
            dGridSerial.ScrollBars = ScrollBars.Horizontal;
            dGridSerial.ShowEditingIcon = false;
            dGridSerial.Size = new Size(340, 155);
            dGridSerial.TabIndex = 2;
            dGridSerial.TabStop = false;
            
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.BackColor = SystemColors.ControlLight;
            label1.Font = new Font("Microsoft YaHei", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(1, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(564, 30);
            label1.TabIndex = 7;
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // SerialSend
            // 
            SerialSend.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SerialSend.Font = new Font("Microsoft Sans Serif", 8.9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SerialSend.Location = new Point(4, 466);
            SerialSend.Margin = new Padding(4, 3, 4, 3);
            SerialSend.Name = "SerialSend";
            SerialSend.Size = new Size(450, 21);
            SerialSend.TabIndex = 4;
            SerialSend.WordWrap = false;
          
            // 
            // ClearSerial
            // 
            ClearSerial.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ClearSerial.Font = new Font("Microsoft Sans Serif", 8.25F);
            ClearSerial.Location = new Point(461, 466);
            ClearSerial.Margin = new Padding(4, 3, 4, 3);
            ClearSerial.Name = "ClearSerial";
            ClearSerial.Size = new Size(104, 23);
            ClearSerial.TabIndex = 6;
            ClearSerial.Text = "Clear";
            ClearSerial.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem, viewToolStripMenuItem, aboutToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(933, 24);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(61, 20);
            settingsToolStripMenuItem.Text = "Settings";
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripSeparator1, toolStripMenuItem2, serialSettingsToolStripMenuItem, serialMonitorToolStripMenuItem, serialInfoToolStripMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(44, 20);
            viewToolStripMenuItem.Text = "View";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(145, 6);
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Checked = true;
            toolStripMenuItem2.CheckState = CheckState.Checked;
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(148, 22);
            toolStripMenuItem2.Text = "Port Selector";
            toolStripMenuItem2.Click += portSelectorMenuItem2_Click;
            // 
            // serialSettingsToolStripMenuItem
            // 
            serialSettingsToolStripMenuItem.Checked = true;
            serialSettingsToolStripMenuItem.CheckState = CheckState.Checked;
            serialSettingsToolStripMenuItem.Name = "serialSettingsToolStripMenuItem";
            serialSettingsToolStripMenuItem.Size = new Size(148, 22);
            serialSettingsToolStripMenuItem.Text = "Serial Settings";
            serialSettingsToolStripMenuItem.Click += serialSettingsToolStripMenuItem_Click;
            // 
            // serialMonitorToolStripMenuItem
            // 
            serialMonitorToolStripMenuItem.Checked = true;
            serialMonitorToolStripMenuItem.CheckState = CheckState.Checked;
            serialMonitorToolStripMenuItem.Name = "serialMonitorToolStripMenuItem";
            serialMonitorToolStripMenuItem.Size = new Size(148, 22);
            serialMonitorToolStripMenuItem.Text = "Serial Monitor";
            serialMonitorToolStripMenuItem.Click += serialMonitorToolStripMenuItem_Click;
            // 
            // serialInfoToolStripMenuItem
            // 
            serialInfoToolStripMenuItem.Checked = true;
            serialInfoToolStripMenuItem.CheckState = CheckState.Checked;
            serialInfoToolStripMenuItem.Name = "serialInfoToolStripMenuItem";
            serialInfoToolStripMenuItem.Size = new Size(148, 22);
            serialInfoToolStripMenuItem.Text = "Serial Info";
            serialInfoToolStripMenuItem.Click += serialInfoToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { repositoryToolStripMenuItem, infoToolStripMenuItem });
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(52, 20);
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
            Name = "cwSerCom";
            Text = "cwSerial";
            
            Shown += cwSerCom_Shown;
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
            flowLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dGridSerial).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.DataGridView dGridInfo;
        private System.IO.Ports.SerialPort SPort;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.Button Disconnect;
        private new System.Windows.Forms.Button Refresh;
        private System.Windows.Forms.Label led;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Panel panel1;
        
        private System.Windows.Forms.TextBox SerialSend;
        private System.Windows.Forms.Button ClearSerial;
        private System.Windows.Forms.DataGridView dGridSerial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serialSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serialMonitorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serialInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem repositoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private FolderBrowserDialog folderBrowserDialog1;
    }
}

