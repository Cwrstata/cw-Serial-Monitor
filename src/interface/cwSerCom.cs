// ---------------------------------------------------------------------------- //
//  Cwrstata || cw Serial Monitor
//      https://github.com/Cwrstata
//      https://github.com/Cwrstata/cw-Serial-Monitor
//
//      cwSerCom
//          -v0.1.2a
//      Added a newline configuration combobox.
// ---------------------------------------------------------------------------- //


using Exp2.src.utils;

using System.IO.Ports;
using System.Text.RegularExpressions;


//Ported from .NET 4.7 to 8.0

namespace Exp
{






    public partial class cwSerCom : Form
    {


        const string cwVersion = "v0.1.2a";

        //Rappresents the port indicator text, "Connected" = true;
        bool pOpen = false;





        /// <summary>
        /// Displays the status of the port in the interface in the appropriate label.
        /// </summary>
        /// <returns>Returns true if the port is connected, in any other case it returns false.</returns>
        public bool CheckPort()
        {


            if (SPort == null) { return false; }
            if (pOpen)
            {
                if (!SPort.IsOpen)
                {


                    led.ForeColor = Color.Red;
                    led.TextAlign = ContentAlignment.MiddleLeft;
                    status.Text = "Disconnected";
                    status.Left -= 6;
                    pOpen = false;

                }
                return pOpen;
            }

            if (SPort.IsOpen)
            {
                pOpen = true;

                led.ForeColor = Color.LimeGreen;
                led.TextAlign = ContentAlignment.MiddleRight;
                status.Text = "Connected";
                status.Left += 6;


            }
            return pOpen;
        }



        public cwSerCom()
        {
            InitializeComponent();
            

            
            Button_Refresh(0, null);


            SerialSend.KeyDown += SerialSend_KeyDown;
            cellSerial();


        }



        //Sends data to serial


        /// <summary>
        /// Called when a key is pressed on the serial console.
        /// When the enter key is pressed, and the port is in a working condition, prints all contained text to serial.
        /// </summary>
        private void SerialSend_KeyDown(object? sender, KeyEventArgs e)
        {



            if (e.KeyCode == Keys.Enter)
            {

                if (SPort == null)
                {
                    e.SuppressKeyPress = true;
                    return;
                }

                try
                {
                    if (SPort.IsOpen)
                    {

                        SPort.Write(SerialSend.Text.ToString() + serial_newLine_s);
                        SerialSend.Clear();
                        e.SuppressKeyPress = true;
                    }
                    else { Port_Disconnect(); }
                }
                catch
                {
                    if (pOpen)
                    {
                        MessageBox.Show("Unable to send data to serial", "Serial Comunication Error",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }

                    Port_Disconnect();

                }



            }



        }

        /// <summary>
        /// Called when any data is received trough serial.
        /// Reads the raw data and prints it to the console.
        /// </summary>
        private void SPort_DataReceived(object? sender, SerialDataReceivedEventArgs? e)
        {


            if (SPort == null)
            {
                return;
            }

            if (!SPort.IsOpen)
            {
                Port_Disconnect();
                return;
            }

            try
            {
                while (SPort.BytesToRead != 0)
                {

                    string outP = SPort.ReadExisting();
                    if (textBox1.InvokeRequired)
                    {
                        textBox1.Invoke(new Action(() => textBox1.AppendText(outP))

                        );

                    }
                    else
                    {

                        textBox1.AppendText(outP);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unxpected error occured while receiving data from Serial\n" + ex.ToString(), "Serial Comunication Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
            }

            //The previus loop had a line by line based approach.
            //In the future, you will be able to choose how the data is read and printed on the settings panel.
            /*
            try
            {
                while (SPort.BytesToRead != 0)
                {

                    string outP = SPort.ReadLine() + Environment.NewLine;
                    if (textBox1.InvokeRequired)
                    {
                        textBox1.Invoke(new Action(() => textBox1.AppendText(outP))

                        );

                    }
                    else
                    {

                        textBox1.AppendText(outP);
                    }

                }



            }
            catch (InvalidOperationException err)
            {

                MessageBox.Show("An unxpected error occured while receiving data from Serial\n" + err.ToString(), "Serial Comunication Error",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);
            }
            catch
            {

                try
                {
                    string outP = SPort.ReadExisting();
                    if (textBox1.InvokeRequired)
                    {
                        textBox1.Invoke(new Action(() => textBox1.AppendText(outP))

                        );

                    }
                    else
                    {

                        textBox1.AppendText(outP);
                    }

                }
                catch
                {

                    MessageBox.Show("An unxpected error occured while receiving data from Serial\n", "Serial Comunication Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                }

            }
            ;*/
        }

        private void SPort_Error(object? sender, SerialErrorReceivedEventArgs e)
        {

            Port_Disconnect();
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

            
            if (cellBaudRates.Value==null || cellParityType.Value==null || cellStopBits.Value==null || cellDataBits.Value==null)
            {
                //no more warnigs now hehe
                return;
            }


            SPort.BaudRate = (int)cellBaudRates.Value;
            SPort.ReadTimeout = 500;
            // SPort.WriteTimeout = 500;
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

        /// <summary>
        /// Used to conclude the serial connection.
        /// </summary>
        /// <returns>Returns false if there was no connection to begin with.</returns>
        private bool Port_Disconnect()
        {

            if (SPort != null)
            {
                if (SPort.IsOpen)
                { // fixed bug 0x0001! 
                    SPort.DiscardInBuffer();
                    SPort.DiscardOutBuffer();
                }



                SPort.Close();

                CheckPort(); //Update status display
                SPort = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
                //If SPort is not cleared a ghost port may be detected
                return true;
            }

            return false;
        }

        void Button_Refresh(object? sender, EventArgs? e)
        {


            if (SPort != null && !SPort.IsOpen)
            {
                Port_Disconnect(); //Clean all previus connections
            }





            string? lastPortName = " ";
            var lastPort = comPortsList.SelectedIndex; //Saves the last selected port to reselect it after the refresh

            if (comPortsList.Items.Count != 0 && comPortsList.Items.Count > lastPort && lastPort != -1)
            {

                if (comPortsList.SelectedItem == null) { return; }
                lastPortName = comPortsList.SelectedItem.ToString();
            }
            else { lastPort = -1; } //Clear Selection

            comPortsList.ClearSelected();
            comPortsList.Items.Clear();

            //Fill the serial port list
            string[] ports = SerialPort.GetPortNames();


            foreach (string port in ports)
            {
                comPortsList.Items.Add(port);
            }


            if (lastPort != -1 && comPortsList.Items.Count > lastPort)
            {
                comPortsList.SelectedIndex = lastPort;
                if (comPortsList.SelectedItem == null) { return; }
                if (lastPortName != comPortsList.SelectedItem.ToString())
                {

                    comPortsList.SelectedIndex = -1;

                }
                return;
            }
            comPortsList.SelectedIndex = -1;

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

            if (lastColumn==null) { return; };

            lastColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
           

        }



        private void cwSerCom_Load(object sender, EventArgs e)
        {
            //Sets the default newline to "\n";
            serialNewline.SelectedIndex = 0; 
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
            //cwSettings SettingsForm = new cwSettings();
            //SettingsForm.ShowDialog();


            //The settings form is currently being developed; 

        }

        
    }



}
