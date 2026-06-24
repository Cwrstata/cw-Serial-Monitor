// ---------------------------------------------------------------------------- //
//  Cwrstata || cw Serial Monitor
//      https://github.com/Cwrstata
//      https://github.com/Cwrstata/cw-Serial-Monitor
//
//      cwSerial
//           -v0.1.4a
//      Bux fixes.
//      Using SerialPortStream instead of IO.Ports.
//      Improved Error Handling.      
//
// ---------------------------------------------------------------------------- //

//Contains most of the methods related to the comunication aspect.
//At least for now, this was not wrapped in a separate class because most of the methods strictly interact with the main form.


using RJCP.IO.Ports;
using System.Management;


namespace Exp
{
    
    partial class cwSerCom
    {


        private SerialPortStream ? SPort = null;


        
        /// <summary>
        /// Displays the status of the port in the interface in the appropriate label.
        /// </summary>
        /// <returns>Returns true if the port is connected, in any other case it returns false.</returns>
        public bool CheckPort()
        {

            if (pOpen==true) {

                if (SPort != null)
                {
                    return true;

                }
               

                led.ForeColor = Color.Red;
                led.TextAlign = ContentAlignment.MiddleLeft;
                status.Text = "Disconnected";
                status.Left -= 6;
                pOpen = false;


            } else
            {
                if (SPort == null)
                {
                    return true;

                }

                led.ForeColor = Color.LimeGreen;
                led.TextAlign = ContentAlignment.MiddleRight;
                status.Text = "Connected";
                status.Left += 6;
                pOpen = true;

            }
            return pOpen;
        }

        //Sends data to serial
        public void GetComBluetoothList()
        {

            BluetoothList.Clear();
            using (var searcher = new ManagementObjectSearcher($"SELECT PNPDeviceID FROM Win32_PnPEntity WHERE Caption LIKE '%(COM%'"))
            {

                // fixed bug 0x0003

                
                    foreach (var item in searcher.Get())
                    {

                        if (item["PNPDeviceID"]?.ToString()[0] == 'B')
                        {

                            BluetoothList.Add(true);


                        }
                        else
                        {
                            BluetoothList.Add(false);

                        }


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
                catch (Exception ex)
                {
                    if (pOpen)
                    {

                        cwError.ErrorInfo(ex, "Serial Out (4xCw)", "Unable to send data to serial",this);
                      
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

                cwError.ErrorInfo(ex, "Serial In (3xCw)", "An unxpected error occured while receiving data from Serial", this);
               
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
              






              

                    SPort.Close();
                    SPort.Dispose();


                    SPort = null;

                    CheckPort();




                return true;
            }

            return false;
        }

        private bool Port_Connect(string? port)
        {
            


            Port_Refresh();

            if (port == null) { return false; }

            if (SPort != null && SPort.IsOpen)
            {
                Port_Disconnect();
            }



            if (cellBaudRates.Value == null || cellParityType.Value == null || cellStopBits.Value == null || cellDataBits.Value == null)
            {
                //no more warnigs now hehe
                return false;
            }
            SPort = new SerialPortStream(port);

            SPort.BaudRate = (int)cellBaudRates.Value;
            SPort.ReadTimeout = 500;
            SPort.WriteTimeout = 500;
            SPort.Parity = (Parity)cellParityType.Items.IndexOf((string)cellParityType.Value);
            SPort.StopBits = (StopBits)cellStopBits.Value;
            SPort.DataBits = (int)cellDataBits.Value;

            SPort.DtrEnable = false;
            SPort.RtsEnable = false;

            SPort.Handshake = Handshake.None;


            this.Cursor = Cursors.WaitCursor;
            try { SPort.Open(); }
            catch (Exception ex)
            {

                this.Cursor = Cursors.Default;
                Port_Disconnect();


                cwError.ErrorInfo(ex, "Serial (1xCw)", "Port connection error", this);

                return false;
            }
            this.Cursor = Cursors.Default;

            if (SPort.IsOpen)
            {
                try
                {
                    CheckPort();
                    SPort.DataReceived += SPort_DataReceived;

                    SPort.ErrorReceived += SPort_Error;




                    if (SPort.BytesToRead != 0)
                    {
                        SPort.DiscardInBuffer();
                    }
                }
                catch (Exception ex)
                {

                    cwError.ErrorInfo(ex, "Serial (2xCw)", "Port connection error", this);

                }


                if (cellParityType.Value == null) { return true; } //Retruns True no indicator si displayed
                if (cellParityType.Value.ToString() == null) { return true; }

                

#pragma warning disable CS8602 
                label1.Text = "  " + SPort.PortName.ToString() + "    Baud rate: " + SPort.BaudRate.ToString()
                    + "     Type: " + SPort.DataBits + cellParityType.Value.ToString()[0] + (int)(StopBits)cellStopBits.Value;
#pragma warning restore CS8602 
                ;

                if (SPort.BaudRate != (int)cellBaudRates.Value) { label1.Text += "    USB-CDC"; }


            }


            return true;
        }

        //string? riconnectTo_s = null;
        void Port_Refresh()
        {

       
            if (SPort != null && !SPort.IsOpen)
            {
                //riconnectTo_s = SPort.PortName;
                Port_Disconnect(); //Clean all previus connections
            }
            CheckPort();


            string[]? tempPorts = SerialPortStream.GetPortNames();

            if (ports_sr != null)
            {
                /*

                if (tempPorts.Contains(riconnectTo_s)) {



                   //Port_Connect(riconnectTo_s);     //Auto-Riconnect post refresh
                   //riconnectTo_s = null;

                } ;
                */

                if (ports_sr.SequenceEqual(tempPorts))
                {
                    return;
                }



            }

            ports_sr = tempPorts;


            comPortsList.BeginUpdate();

            var lastPortName = comPortsList.SelectedItem;


            

            comPortsList.ClearSelected();
            comPortsList.Items.Clear();

            //Fill the serial port list
            ports_sr = SerialPortStream.GetPortNames();




            
            foreach (string port in ports_sr)
            {
                comPortsList.Items.Add(port);
            }
            if (appSettings.show_port_type_icon) { 
                GetComBluetoothList(); }



            
            if (lastPortName != null && comPortsList.Items.Contains(lastPortName)) {
                comPortsList.SelectedItem = lastPortName;
            }

            comPortsList.EndUpdate();


        }
    }
}

        
