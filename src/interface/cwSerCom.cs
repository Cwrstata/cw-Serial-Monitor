// ---------------------------------------------------------------------------- //
//  Cwrstata || cw Serial Monitor
//      https://github.com/Cwrstata
//      https://github.com/Cwrstata/cw-Serial-Monitor
//
//      cwSerCom
//          -v0.1.4a
//      Bux fixes.
//      Using SerialPortStream instead of IO.Ports.
//      Improved Error Handling.      
//
// ---------------------------------------------------------------------------- //


using RJCP.IO.Ports;
using System.Diagnostics;


namespace Exp
{






    public partial class cwSerCom : Form
    {


        public static readonly string cwVersion = "v0.1.4a";

        //Rappresents the port indicator text, "Connected" = true;
        bool pOpen = false;
        string[]? ports_sr = null; //list of detected com ports.

        /// <summary>
        /// Pocesses Windows Messages
        /// Overrided to handle WM_DEVICECHANGE.
        /// </summary>
        /// <param name="m"></param>
        /// 
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                //WM_DEVICECHANGE
                case 537:

                    if (appSettings.list_auto_refresh)
                    {

                        //DBT_DEVICEREMOVECOMPLETE && DBT_DEVICEARRIVAL
                        if (m.WParam.ToInt32() == 0x8004 || m.WParam.ToInt32() == 0x8000)
                        {

                            this.BeginInvoke(new Action(() =>
                            {

                                CheckPort();
                                Port_Refresh();

                            }));

                        }




                    }


                    break;
            }
            base.WndProc(ref m);
        }







        public cwSerCom()
        {
            InitializeComponent();



            Port_Refresh();


            SerialSend.KeyDown += SerialSend_KeyDown;
            cellSerial();


        }










        private void Button_Connect(object? sender, EventArgs? e)
        {








            Port_Refresh();
            CheckPort();

            if (comPortsList.SelectedIndex == -1) { return; }
            if (comPortsList.SelectedItem == null) { return; }



            Port_Connect(comPortsList.SelectedItem.ToString());



        }

        private void Button_Disconnect(object? sender, EventArgs? e)
        {

            Port_Disconnect();

        }



        void Button_Refresh(object? sender, EventArgs? e)
        {

            Port_Refresh();


        }






        void Button_Clear(object? sender, EventArgs? e)
        {
            textBox1.Clear();

        }






        private void cwSerCom_Shown(object sender, EventArgs e)
        {
            dGridSerial.ClearSelection();
        }

        private void dGridInfo_Move(object sender, EventArgs e)
        {

            var datagridview = sender as DataGridView;
            if (datagridview == null) { return; }
            if (datagridview.Rows.Count == 0) { return; }
            int cellsHeight = dGridInfo.ClientRectangle.Height - dGridInfo.ColumnHeadersHeight;
            int rowsHeight = cellsHeight / datagridview.Rows.Count;

            foreach (DataGridViewRow row in dGridInfo.Rows)
            {
                row.Height = rowsHeight;
            }

            DataGridViewColumn? lastColumn = datagridview.Columns.GetLastColumn(DataGridViewElementStates.Visible,
                                DataGridViewElementStates.None);

            datagridview.SelectionMode = 0;

            if (lastColumn == null) { return; }
            ;

            lastColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


        }



        private void cwSerCom_Load(object sender, EventArgs e)
        {
            //Sets the default newline to "\n";
            serialNewline.SelectedIndex = 0;


            lSettings.read();
            appSettings = lSettings.appSettings;
            applySettings();
        }


        /// <summary>
        /// Contains the newline character that is sent in "SerialSend_KeyDown".
        /// </summary>
        string serial_newLine_s = "";

        /// <summary>
        /// Updates the new line character when the combo box updates.
        /// </summary>
        private void serialNewline_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (serialNewline.SelectedIndex)
            {
                case 0: //Newline
                    serial_newLine_s = "\n";

                    break;
                case 1: //Carriage Return
                    serial_newLine_s = "\r";

                    break;

                case 2: //Carriage Return + Newline
                    serial_newLine_s = "\r\n";
                    break;

                default://None
                    serial_newLine_s = "";

                    break;
            }


        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (cwSettings SettingsForm = new cwSettings())
            {


                SettingsForm.ShowDialog();



                SettingsForm.Dispose();
                applySettings();

            }
        }



        void applySettings()
        {


            if (appSettings.show_port_type_icon == true)
            {
                comPortsList.DrawMode = DrawMode.OwnerDrawFixed;
            }
            else
            {
                comPortsList.DrawMode = DrawMode.Normal;
            }

            label3.Visible = !appSettings.list_auto_refresh;



        }




        public static cwSettingsManager lSettings = new cwSettingsManager();
        static cwAppSettings appSettings = lSettings.appSettings;
        private void comPortsList_DrawItem(object sender, DrawItemEventArgs e)
        {

            if (!appSettings.show_port_type_icon) { return; }

            //Check if the item is selected to draw the correct icon
            bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

            if (e.Index < 0) return;



            e.DrawBackground();


            Image icon;
            string? itemText = comPortsList.Items[e.Index].ToString();
            if (e.Index >= 0)
            {



                if (BluetoothList[e.Index])
                {
                    if (isSelected)
                    {
                        icon = imageList1.Images[1];
                    }
                    else
                    {
                        icon = imageList1.Images[0];
                    }

                }
                else
                {

                    if (isSelected)
                    {
                        icon = imageList1.Images[3];
                    }
                    else
                    {
                        icon = imageList1.Images[2];
                    }
                }

                Rectangle iconBounds = new Rectangle(e.Bounds.X + e.Bounds.Width - 25, e.Bounds.Y + (e.Bounds.Height - 18) / 2, 18, 18);

                Rectangle textBounds = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 35, e.Bounds.Height);



                e.Graphics.DrawImage(icon, iconBounds);


                TextRenderer.DrawText(e.Graphics, itemText, e.Font, textBounds, e.ForeColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);


                e.DrawFocusRectangle();
            }
        }

        private void comPortsList_Resize(object sender, EventArgs e)
        {
            comPortsList.Invalidate();
        }

        private void programFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe",@$"{AppDomain.CurrentDomain.BaseDirectory}");
        }
    }



}
