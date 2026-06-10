
namespace Exp
{
    partial class cwSettings
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
            components = new System.ComponentModel.Container();
            splitContainer1 = new SplitContainer();
            tab_Serial = new Label();
            tab_General = new Label();
            panel1 = new Panel();
            button1 = new Button();
            Save_Button = new Button();
            tabControl = new TabControl();
            tabPanel_General = new TabPage();
            check_list_auto_refresh = new CheckBox();
            label3 = new Label();
            separator = new Label();
            label1 = new Label();
            check_show_port_icon = new CheckBox();
            tabPanel_Serial = new TabPage();
            comboBox2 = new ComboBox();
            label2 = new Label();
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
            tabControl.SuspendLayout();
            tabPanel_General.SuspendLayout();
            tabPanel_Serial.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.BorderStyle = BorderStyle.FixedSingle;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tab_Serial);
            splitContainer1.Panel1.Controls.Add(tab_General);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Panel2.Controls.Add(tabControl);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 181;
            splitContainer1.TabIndex = 0;
            // 
            // tab_Serial
            // 
            tab_Serial.Dock = DockStyle.Top;
            tab_Serial.Enabled = false;
            tab_Serial.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tab_Serial.Location = new Point(0, 25);
            tab_Serial.Name = "tab_Serial";
            tab_Serial.Size = new Size(179, 25);
            tab_Serial.TabIndex = 1;
            tab_Serial.Text = "Serial";
            tab_Serial.TextAlign = ContentAlignment.MiddleCenter;
            tab_Serial.Click += tab_Serial_Click;
            // 
            // tab_General
            // 
            tab_General.BackColor = SystemColors.Control;
            tab_General.BorderStyle = BorderStyle.Fixed3D;
            tab_General.Dock = DockStyle.Top;
            tab_General.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tab_General.Location = new Point(0, 0);
            tab_General.Name = "tab_General";
            tab_General.Size = new Size(179, 25);
            tab_General.TabIndex = 0;
            tab_General.Text = "General";
            tab_General.TextAlign = ContentAlignment.MiddleCenter;
            tab_General.Click += tab_General_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(Save_Button);
            panel1.Location = new Point(-8, 414);
            panel1.Name = "panel1";
            panel1.Size = new Size(629, 36);
            panel1.TabIndex = 8;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.Location = new Point(10, 5);
            button1.Name = "button1";
            button1.Size = new Size(83, 26);
            button1.TabIndex = 6;
            button1.Text = "Reset all";
            button1.UseVisualStyleBackColor = true;
            button1.Click += resetall_Click;
            // 
            // Save_Button
            // 
            Save_Button.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Save_Button.Location = new Point(533, 4);
            Save_Button.Name = "Save_Button";
            Save_Button.Size = new Size(83, 26);
            Save_Button.TabIndex = 7;
            Save_Button.Text = "Save";
            Save_Button.UseVisualStyleBackColor = true;
            Save_Button.Click += Save_Button_Click;
            // 
            // tabControl
            // 
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.Controls.Add(tabPanel_General);
            tabControl.Controls.Add(tabPanel_Serial);
            tabControl.Dock = DockStyle.Top;
            tabControl.ItemSize = new Size(20, 20);
            tabControl.Location = new Point(0, 0);
            tabControl.Margin = new Padding(0);
            tabControl.Name = "tabControl";
            tabControl.Padding = new Point(0, 0);
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(613, 411);
            tabControl.SizeMode = TabSizeMode.Fixed;
            tabControl.TabIndex = 0;
            // 
            // tabPanel_General
            // 
            tabPanel_General.Controls.Add(check_list_auto_refresh);
            tabPanel_General.Controls.Add(label3);
            tabPanel_General.Controls.Add(separator);
            tabPanel_General.Controls.Add(label1);
            tabPanel_General.Controls.Add(check_show_port_icon);
            tabPanel_General.Location = new Point(4, 24);
            tabPanel_General.Margin = new Padding(3, 3, 3, 0);
            tabPanel_General.Name = "tabPanel_General";
            tabPanel_General.Padding = new Padding(3, 3, 3, 0);
            tabPanel_General.Size = new Size(605, 383);
            tabPanel_General.TabIndex = 1;
            tabPanel_General.Text = "tabPage2";
            tabPanel_General.UseVisualStyleBackColor = true;
            // 
            // check_list_auto_refresh
            // 
            check_list_auto_refresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            check_list_auto_refresh.AutoSize = true;
            check_list_auto_refresh.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            check_list_auto_refresh.Location = new Point(43, 67);
            check_list_auto_refresh.Name = "check_list_auto_refresh";
            check_list_auto_refresh.Size = new Size(99, 21);
            check_list_auto_refresh.TabIndex = 5;
            check_list_auto_refresh.Text = "Auto refresh";
            check_list_auto_refresh.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.BackColor = SystemColors.ControlDark;
            label3.Enabled = false;
            label3.Font = new Font("Segoe UI", 2.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(26, 4);
            label3.Name = "label3";
            label3.Size = new Size(553, 1);
            label3.TabIndex = 4;
            // 
            // separator
            // 
            separator.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            separator.BackColor = SystemColors.ControlDark;
            separator.Enabled = false;
            separator.Font = new Font("Segoe UI", 2.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            separator.Location = new Point(26, 98);
            separator.Name = "separator";
            separator.Size = new Size(553, 1);
            separator.TabIndex = 3;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.BackColor = SystemColors.Control;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(27, 12);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 1;
            label1.Text = "Port list";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // check_show_port_icon
            // 
            check_show_port_icon.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            check_show_port_icon.AutoSize = true;
            check_show_port_icon.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            check_show_port_icon.Location = new Point(43, 40);
            check_show_port_icon.Name = "check_show_port_icon";
            check_show_port_icon.Size = new Size(144, 21);
            check_show_port_icon.TabIndex = 0;
            check_show_port_icon.Text = "Show port type icon";
            check_show_port_icon.UseVisualStyleBackColor = true;
            // 
            // tabPanel_Serial
            // 
            tabPanel_Serial.Controls.Add(comboBox2);
            tabPanel_Serial.Controls.Add(label2);
            tabPanel_Serial.Location = new Point(4, 24);
            tabPanel_Serial.Name = "tabPanel_Serial";
            tabPanel_Serial.Padding = new Padding(3);
            tabPanel_Serial.Size = new Size(605, 383);
            tabPanel_Serial.TabIndex = 2;
            tabPanel_Serial.Text = "tabPage1";
            tabPanel_Serial.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Raw data", "Line by line" });
            comboBox2.Location = new Point(109, 14);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 3;
            // 
            // label2
            // 
            label2.Location = new Point(6, 13);
            label2.Name = "label2";
            label2.Size = new Size(97, 23);
            label2.TabIndex = 2;
            label2.Text = "Read method:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cwSettings
            // 
            AcceptButton = Save_Button;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            MinimumSize = new Size(300, 300);
            Name = "cwSettings";
            Text = "form";
            Load += cwSettings_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tabPanel_General.ResumeLayout(false);
            tabPanel_General.PerformLayout();
            tabPanel_Serial.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private TabControl tabControl;
        private TabPage tabPanel_General;

        private TabPage tabPanel_Serial;
        private Label tab_General;
        private Label tab_Serial;
        private ComboBox comboBox2;
        private Label label2;
        private ToolTip toolTip1;
        private Label label1;
        private CheckBox check_show_port_icon;
        private Label label3;
        private Label separator;
        private CheckBox check_list_auto_refresh;
        private Button button1;
        private Button Save_Button;
        private Panel panel1;
    }
}