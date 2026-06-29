// ---------------------------------------------------------------------------- //
//  Cwrstata || cw Serial Monitor
//      https://github.com/Cwrstata
//      https://github.com/Cwrstata/cw-Serial-Monitor
//
//      cwSerial
//           -v1.0.0a
//      Clicking on the monitor's header will display some additional informations.
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
            // fixed bug 0x0007
            if (pOpen==true) {

                if (SPort != null)
                {
                    return false;

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
                    return false;

                }

                led.ForeColor = Color.LimeGreen;
                led.TextAlign = ContentAlignment.MiddleRight;
                status.Text = "Connected";
                status.Left += 6;
                pOpen = true;

            }
            return pOpen;
        }


        /// <summary>
        /// Updates the internal list of Bluetooth devices.
        /// Used to display icons.
        /// </summary>
        public void GetComBluetoothList()
        {

            
            using (var searcher = new ManagementObjectSearcher($"SELECT PNPDeviceID FROM Win32_PnPEntity WHERE Caption LIKE '%(COM%'"))
            {


                    BluetoothList.Clear();  
                    foreach (var item in searcher.Get())
                    {

                      
                        if ((item["PNPDeviceID"]?.ToString() ?? "").StartsWith("B"))
                        {   // fixed bug 0x0006

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
        /// Called when a key is pressed on the serial "Send" textbox. 
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
                        e.SuppressKeyPress = true;
              

                        SPort.Write(SerialSend.Text.ToString() + serial_newLine_s);

                        SerialSend.Clear();
                        
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
        /// Reads the raw data and prints it to the terminal.
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
                    if (textBoxMonitor.InvokeRequired)
                    {
                        textBoxMonitor.Invoke(new Action(() => textBoxMonitor.AppendText(outP)));

                    }
                    else
                    {

                        textBoxMonitor.AppendText(outP);
                    }

                }
            }
            catch (Exception ex)
            {

                cwError.ErrorInfo(ex, "Serial In (3xCw)", "An unxpected error occured while receiving data from Serial", this);
               
            }
        }

        private void SPort_Error(object? sender, SerialErrorReceivedEventArgs e)
        {

            Port_Disconnect();
        }

        /// <summary>
        /// Used to terminate the serial connection.
        /// </summary>
        /// <returns>Returns false if there was no connection to begin with.</returns>
        private bool Port_Disconnect()
        {

            if (SPort != null)
            {
                label_Info.Text = "";









                    SPort.Close();
                    SPort.Dispose();


                    SPort = null;

                    CheckPort();




                return true;
            }

            return false;
        }

        /// <summary>
        /// Establishes a connection with the port named in the string paramenter.
        /// </summary>
        /// <param name="port"></param>
        /// <returns>True if the port is opened correctly.</returns>
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

            if (appSettings.Serial != null)
            {
                SPort.ReadTimeout = (int)(appSettings.Serial).timeout_read;
                SPort.WriteTimeout = (int)appSettings.Serial.timeout_write;
            }
            else { 
                SPort.ReadTimeout = 500;
                SPort.WriteTimeout = 500;
            }
                   

            SPort.Parity = (Parity)cellParityType.Items.IndexOf((string)cellParityType.Value);
            SPort.StopBits = (StopBits)cellStopBits.Items.IndexOf((decimal)cellStopBits.Value);  // fixed bug 0x0005 
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
                    Port_Disconnect();
                    return true;

                }


                if (cellParityType.Value == null) { return true; } //Retruns True no indicator si displayed
                if (cellParityType.Value.ToString() == null) { return true; }

                

#pragma warning disable CS8602 
                label_Info.Text = "  " + SPort.PortName.ToString() + "    Baud rate: " + SPort.BaudRate.ToString()
                    + "     Type: " + SPort.DataBits + cellParityType.Value.ToString()[0] + (decimal)cellStopBits.Value;
#pragma warning restore CS8602 
                ;

                if (SPort.BaudRate != (int)cellBaudRates.Value) { label_Info.Text += "    USB-CDC"; }


            }


            return true;
        }

        /// <summary>
        /// Checks available ports and updates the ui accordingly.
        /// Checks also the status of the current connection.
        /// </summary>
        void Port_Refresh()
        {

       
            if (SPort != null && !SPort.IsOpen)
            {
                Port_Disconnect(); //Clear broken connections
            }
            CheckPort();


            string[]? tempPorts = SerialPortStream.GetPortNames();

            if (ports_sr != null)
            {
             

                if (ports_sr.SequenceEqual(tempPorts))
                {
                    //Nothing changed, do not refresh
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



            //Clear Menu strip
            foreach (ToolStripItem item in connectToolStripMenuItem.DropDownItems)
            {
                
                item.Click -= connectToolStripMenuItem_Click;
            }
            connectToolStripMenuItem.DropDownItems.Clear();



            foreach (string port in ports_sr)
            {
                //Adds Items to menu strip >port > connect
                ToolStripItem tempToolStripItem = new ToolStripMenuItem();
                
                tempToolStripItem.Text = port;

                tempToolStripItem.Click += new EventHandler(connectToolStripMenuItem_Click);

                connectToolStripMenuItem.DropDownItems.Add(tempToolStripItem);



                //Adds Items to port list
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