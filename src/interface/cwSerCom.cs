// ---------------------------------------------------------------------------- //
//  Cwrstata || cw Serial Monitor
//      https://github.com/Cwrstata
//      https://github.com/Cwrstata/cw-Serial-Monitor
//
//      cwSerCom
//          -v0.1.3a
//      Settings can be now configured in an apporiate setting form.
//      Devices are automaticly detected.
//      Besides the port names, an icon appears indicating the device type.
// ---------------------------------------------------------------------------- //


using System.IO.Ports;


namespace Exp
{






    public partial class cwSerCom : Form
    {


        public static readonly string cwVersion = "v0.1.3a";

        //Rappresents the port indicator text, "Connected" = true;
        bool pOpen = false;
        string[]? ports_sr = null; //list of detected com ports.

        /// <summary>
        /// Pocesses Windows Messages
        /// Overrided to handle WM_DEVICECHANGE.
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                //WM_DEVICECHANGE
                case 537:

                    if (appSettings.list_auto_refresh)
                    {
                        CheckPort();


                        Port_Refresh();

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



        

        /// <summary>
        /// Called every time a new port is selected to retrieve all avaible informations.
        /// </summary>
        private void comPortList_SelectedIndexChanged(object? sender, EventArgs e)
        {

            //This happens only if approrpiate grid is visible.
            if (dGridInfo.Visible)
            {

                if (comPortsList.SelectedIndex != -1 && comPortsList.SelectedIndex < comPortsList.Items.Count)
                {

                    if (comPortsList.SelectedItem == null) { return; }


                    GetComPortDetails(comPortsList.SelectedItem.ToString());
                }

            }



        }



        private void Button_Connect(object? sender, EventArgs? e)
        {


            if (SPort != null && SPort.IsOpen)
            {
                Button_Disconnect(0, null);
            }

            Button_Refresh(0, null);
            CheckPort();

            if (comPortsList.SelectedIndex == -1) { return; }
            if (comPortsList.SelectedItem == null) { return; }
            ;
            SPort = new SerialPort(comPortsList.SelectedItem.ToString());


            if (cellBaudRates.Value == null || cellParityType.Value == null || cellStopBits.Value == null || cellDataBits.Value == null)
            {
                //no more warnigs now hehe
                return;
            }


            SPort.BaudRate = (int)cellBaudRates.Value;
            SPort.ReadTimeout = 500;
            SPort.WriteTimeout = 500;
            SPort.Parity = (Parity)cellParityType.Items.IndexOf((string)cellParityType.Value);
            SPort.StopBits = (StopBits)cellStopBits.Value;
            SPort.DataBits = (int)cellDataBits.Value;


            try { SPort.Open(); } catch { return; }

            if (SPort.IsOpen)
            {

                CheckPort();
                SPort.DataReceived += SPort_DataReceived;
                SPort.ErrorReceived += SPort_Error;



                if (SPort.BytesToRead != 0)
                {
                    SPort.DiscardInBuffer();
                }



                if (cellParityType.Value == null) { return; }
                if (cellParityType.Value.ToString() == null) { return; }

#pragma warning disable CS8602 
                label1.Text = "  " + SPort.PortName.ToString() + "    Baud rate: " + SPort.BaudRate.ToString()
                    + "     Type: " + SPort.DataBits + cellParityType.Value.ToString()[0] + (int)(StopBits)cellStopBits.Value;
#pragma warning restore CS8602 
                ;


            }
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
            using (cwSettings SettingsForm = new cwSettings()) { 


            SettingsForm.ShowDialog();



                SettingsForm.Dispose();
                applySettings();

        }
        }

        void applySettings() {

           
            if (appSettings.show_port_type_icon == true)
            {
                comPortsList.DrawMode = DrawMode.OwnerDrawFixed;
            }
            else {
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
            string ?itemText = comPortsList.Items[e.Index].ToString();
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
    }



}
