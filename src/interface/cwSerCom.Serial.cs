// ---------------------------------------------------------------------------- //
//  Cwrstata || cw Serial Monitor
//      https://github.com/Cwrstata
//      https://github.com/Cwrstata/cw-Serial-Monitor
//
//      cwSerial
//           -v0.1.3a
//      
// ---------------------------------------------------------------------------- //

//Contains most of the methods related to the comunication aspect.
//At least for now, this was not wrapped in a separate class because most of the methods strictly interact with the main form.


using System.IO.Ports;
using System.Management;


namespace Exp
{
    
    partial class cwSerCom
    {


        private System.IO.Ports.SerialPort ? SPort;

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
                    Port_Disconnect(); //Prevents ghost ports, helpfull with the automatic ports detection.

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

        //Sends data to serial
        public void GetComBluetoothList()
        {

            BluetoothList.Clear();
            using (var searcher = new ManagementObjectSearcher($"SELECT PNPDeviceID FROM Win32_PnPEntity WHERE Caption LIKE '%(COM%'"))
            {
                // cellBaudRates.DetachEditingControl();


                foreach (var item in searcher.Get())
                {
                   
                    if (item["PNPDeviceID"]?.ToString()[0] == 'B')
                    {

                        BluetoothList.Add(true);


                    }
                    else { BluetoothList.Add(false); }



                }





            }
        }

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


        void Port_Refresh()
        {


            if (SPort != null && !SPort.IsOpen)
            {
                Port_Disconnect(); //Clean all previus connections
            }

            string[]? tempPorts = SerialPort.GetPortNames();

            if (ports_sr != null)
            {





                if (ports_sr.SequenceEqual(tempPorts))
                {
                    return;
                }



            }

            ports_sr = tempPorts;



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
            ports_sr = SerialPort.GetPortNames();




            comPortsList.BeginUpdate();
            foreach (string port in ports_sr)
            {
                comPortsList.Items.Add(port);
            }
            if (appSettings.show_port_type_icon) { GetComBluetoothList(); }



            comPortsList.EndUpdate();
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
    }
}

        
