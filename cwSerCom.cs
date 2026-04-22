using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
namespace Exp
{

    

    



    public partial class cwSerCom : Form
    {
        bool pOpen = false;

        //Displays the status of the port in the interface
        public bool CheckPort()
        {
            if (SPort == null) { return false; }
            if (pOpen) { if (!SPort.IsOpen) {


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
        public void GetComPortDetails(string portn)
        {

          
            using (var searcher = new ManagementObjectSearcher($"SELECT * FROM Win32_PnPEntity WHERE Caption LIKE '%({portn}%)'"))
            {

                if (searcher.Get().Count == 0) { return; }
                var port = searcher.Get().Cast<ManagementObject>().First();
                
                    
                    
                    

                List<tabEn> PortInfo = new List<tabEn>();
                PortInfo.Add(new tabEn()
                {
                    Name = "Caption",
                    Data = port["Caption"]?.ToString()
                });

                PortInfo.Add(new tabEn()
                {
                    Name = "Manufacturer",
                    Data = port["Manufacturer"]?.ToString()
                });

                PortInfo.Add(new tabEn()
                {
                    Name = "Description",
                    Data = port["Description"]?.ToString()
                });

                PortInfo.Add(new tabEn()
                {
                    Name = "Present",
                    Data = port["Present"]?.ToString()
                });

                PortInfo.Add(new tabEn()
                {
                    Name = "Status",
                    Data = port["Status"]?.ToString()
                });

                PortInfo.Add(new tabEn()
                {
                    Name = "PNP ID",
                    Data = port["PNPDeviceID"]?.ToString()
                });

               

               
                BindingSource binding = new BindingSource();
                binding.DataSource = PortInfo;
                dataGridView1.DataSource = binding;
                dataGridView1.AutoResizeColumns();
                dataGridView1.Columns.GetLastColumn(DataGridViewElementStates.Visible,
                                    DataGridViewElementStates.None).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.SelectionMode = 0;
                dataGridView1.ClearSelection();

            }
        }



        //SerialPort SPort;
        public cwSerCom()
        {
            InitializeComponent();
            Refresh.Click += Button_Refresh;
            Connect.Click += Button_Connect;
            Disconnect.Click += Button_Disconnect;
      
            ClearSerial.Click += Button_Clear;
            Button_Refresh(0, null);


            SerialSend.KeyDown += SerialSend_KeyDown;



        }



        //Sends data to serial
        private void SerialSend_KeyDown(object sender, KeyEventArgs e)
        {

           
            
            if (e.KeyCode == Keys.Enter && SPort!=null)
            {

                try {
                    if (SPort.IsOpen)
                    {

                        SPort.Write(SerialSend.Text.ToString() + "\n");
                        SerialSend.Clear();
                        SPort_DataReceived(0, null);
                    } else { Port_Disconnect(); }
                } catch {
                    if (pOpen) { 
                    MessageBox.Show("Unable to send data to serial", "Serial Comunication Error",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);
                    }

                    Port_Disconnect();

                }
               


            }
        
        
          
        }
        //Recives data from serial
        private void SPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (SPort==null)
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
               
                string outP= SPort.ReadLine() + Environment.NewLine;
                if (textBox1.InvokeRequired)
                {
                    textBox1.Invoke(new Action(() => textBox1.AppendText(outP))

                    );
               
                } else
                {

                    textBox1.AppendText(outP);
                }

                }
                


            }
            catch
            {
                MessageBox.Show("An unxpected error occured while receaving data from Serial", "Serial Comunication Error",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);
            }
        }
        

        private void SPort_Error(object sender, SerialErrorReceivedEventArgs e)
        {

            Port_Disconnect();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            if (listBox1.SelectedIndex != -1 && listBox1.SelectedIndex< listBox1.Items.Count)
            {
                GetComPortDetails(listBox1.SelectedItem.ToString());

            }
          
            
        
        }

     
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void Button_Connect(object sender, EventArgs e)
        {
           
     
            if (SPort!= null && SPort.IsOpen)
            {
                Button_Disconnect(0, null);
            }

            Button_Refresh(0, null);
            CheckPort();

            if (listBox1.SelectedIndex==-1) { return; }
            SPort = new SerialPort(listBox1.SelectedItem.ToString());
            SPort.BaudRate = 115200;
            SPort.ReadTimeout = 500;
           // SPort.WriteTimeout = 500;
            SPort.Parity = Parity.None;
            SPort.StopBits = StopBits.One;
            SPort.DataBits = 8;
           

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

                //textBox1.Text += "Line 1";


            }
        }

        void Button_Disconnect(object sender, EventArgs e)
        {

            Port_Disconnect();

        }


        bool Port_Disconnect() {

            if (SPort != null)
            {
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

        void Button_Refresh(object sender, EventArgs e)
        {


            if (SPort != null && !SPort.IsOpen)
            {
                Port_Disconnect(); //Clean all previus connections
            }
               

            


            string lastPortName = " ";
            var lastPort = listBox1.SelectedIndex; //Saves the last selected port to reselect it after the refresh
            if (listBox1.Items.Count != 0 && listBox1.Items.Count > lastPort && lastPort != -1) { lastPortName = listBox1.SelectedItem.ToString(); } 
            else { lastPort = -1; } //Clear Selection

            listBox1.ClearSelected();
            listBox1.Items.Clear();

            //Fill the serial port list
            string[] ports = SerialPort.GetPortNames(); 
    
       
            foreach (string port in ports)
            {
                listBox1.Items.Add(port);
            }


            if (lastPort != -1 && listBox1.Items.Count > lastPort) {
                listBox1.SelectedIndex = lastPort;
                if (lastPortName != listBox1.SelectedItem.ToString()) {
                    
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


        void Button_Clear(object sender, EventArgs e)
        {

          textBox1.Clear();
       
        }

      
    }


    public class tabEn
    {
        public string Name { get; set; }
        public string Data { get; set; }
    }
}
