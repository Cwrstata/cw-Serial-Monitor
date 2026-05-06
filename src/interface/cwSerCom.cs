// ---------------------------------------------------------------------------- //
//  Cwrstata || cw Serial Monitor
//      https://github.com/Cwrstata
//      https://github.com/Cwrstata/cw-Serial-Monitor
//
//      cwSerCom
//          -v0.1.0a
// ---------------------------------------------------------------------------- //


using Exp2.src.utils;
using System.Diagnostics;
using System.IO.Ports;


//Ported from .NET 4.7 to 8.0

namespace Exp
{






    public partial class cwSerCom : Form
    {


        const string cwVersion = "v0.1.0a";


        bool pOpen = false;

        //Displays the status of the port in the interface
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

        //Updates the port information grid




        //SerialPort SPort;
        public cwSerCom()
        {
            InitializeComponent();
            Refresh.Click += new System.EventHandler(this.Button_Refresh);
            Connect.Click += Button_Connect;
            Disconnect.Click += Button_Disconnect;

            ClearSerial.Click += Button_Clear;
            Button_Refresh(0, null);


            SerialSend.KeyDown += SerialSend_KeyDown;
            cellSerial();


        }



        //Sends data to serial
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

                        SPort.Write(SerialSend.Text.ToString() + "\n");
                        SerialSend.Clear();
                        SPort_DataReceived(0, null);
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
        //Recives data from serial
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
                
                MessageBox.Show("An unxpected error occured while receaving data from Serial\n"+ err.ToString(), "Serial Comunication Error",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);
            } catch {

                try { 
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

                } catch {

                    MessageBox.Show("An unxpected error occured while receaving data from Serial\n", "Serial Comunication Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                }

            }
            ;
        }


        private void SPort_Error(object? sender, SerialErrorReceivedEventArgs e)
        {

            Port_Disconnect();
        }
        private void listBox1_SelectedIndexChanged(object? sender, EventArgs e)
        {


            if (listBox1.SelectedIndex != -1 && listBox1.SelectedIndex < listBox1.Items.Count)
            {

                if (listBox1.SelectedItem == null) { return; }
                ;
                GetComPortDetails(listBox1.SelectedItem.ToString());

            }



        }


        private void dataGridView1_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button_Connect(object? sender, EventArgs? e)
        {


            if (SPort != null && SPort.IsOpen)
            {
                Button_Disconnect(0, null);
            }

            Button_Refresh(0, null);
            CheckPort();

            if (listBox1.SelectedIndex == -1) { return; }
            if (listBox1.SelectedItem == null) { return; }
            ;
            SPort = new SerialPort(listBox1.SelectedItem.ToString());
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
                label1.Text = "  " + SPort.PortName.ToString() + "    Baud rate: " + SPort.BaudRate.ToString()
                    + "     Type: " + SPort.DataBits + cellParityType.Value.ToString()[0] + (int)(StopBits)cellStopBits.Value;
                ;


            }
        }

        private void Button_Disconnect(object? sender, EventArgs? e)
        {

            Port_Disconnect();

        }


        private bool Port_Disconnect()
        {
          
            if (SPort != null)
            {
                SPort.DiscardInBuffer();
                SPort.DiscardOutBuffer();
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





            string ?lastPortName = " ";
            var lastPort = listBox1.SelectedIndex; //Saves the last selected port to reselect it after the refresh

            if (listBox1.Items.Count != 0 && listBox1.Items.Count > lastPort && lastPort != -1)
            {

                if (listBox1.SelectedItem == null) { return; }
                lastPortName = listBox1.SelectedItem.ToString();
            }
            else { lastPort = -1; } //Clear Selection

            listBox1.ClearSelected();
            listBox1.Items.Clear();

            //Fill the serial port list
            string[] ports = SerialPort.GetPortNames();


            foreach (string port in ports)
            {
                listBox1.Items.Add(port);
            }


            if (lastPort != -1 && listBox1.Items.Count > lastPort)
            {
                listBox1.SelectedIndex = lastPort;
                if (listBox1.SelectedItem == null) { return; }
                if (lastPortName != listBox1.SelectedItem.ToString())
                {

                    listBox1.SelectedIndex = -1;

                }
                return;
            }
            listBox1.SelectedIndex = -1;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }



        private void SerialSend_TextChanged(object sender, EventArgs e)
        {

        }


        void Button_Clear(object? sender, EventArgs? e)
        {

            textBox1.Clear();

        }

    


        private void dGridSerial_Validated(object sender, EventArgs e)
        {

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

            datagridview.Columns.GetLastColumn(DataGridViewElementStates.Visible,
                                DataGridViewElementStates.None).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            datagridview.SelectionMode = 0;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }



}
