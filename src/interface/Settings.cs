// ---------------------------------------------------------------------------- //
//  Cwrstata || cw Serial Monitor
//      https://github.com/Cwrstata
//      https://github.com/Cwrstata/cw-Serial-Monitor
//
//      cwSerCom
//           -v1.0.0a
//      
// ---------------------------------------------------------------------------- //



using System.Windows.Forms;

namespace Exp
{
    public partial class cwSettings : Form
    {

        /// <summary>
        /// Global app settings manager referance
        /// </summary>
        static cwSettingsManager lSettings = cwSerCom.lSettings;

        /// <summary>
        /// Global app settings referance
        /// </summary>
        static cwAppSettings appSettings = cwSerCom.lSettings.appSettings;



      



        /// <summary>
        /// Previusly selected button in the tab selector
        /// </summary>
        Label previus_label;
        public cwSettings()
        {
            InitializeComponent();
            previus_label = tab_General;


        }


        private void tab_General_Click(object sender, EventArgs e)
        {

            previus_label.BorderStyle = BorderStyle.None;

            tabControl.SelectedIndex = 0;

            tab_General.BorderStyle = BorderStyle.Fixed3D;
            previus_label = tab_General;
        }
        public void tab_Serial_Click(object sender, EventArgs e)
        {

            previus_label.BorderStyle = BorderStyle.None;

            tabControl.SelectedIndex = 1;

            tab_Serial.BorderStyle = BorderStyle.Fixed3D;
            previus_label = tab_Serial;
        }



        private void cwSettings_Load(object sender, EventArgs e)
        {
          
            tabControl.ItemSize = new Size(0, 1);
           

            lSettings.read();
            //Set pointer
            appSettings = cwSerCom.lSettings.appSettings;
            settings_Load();

        }


        void settings_Load() {

            check_show_port_icon.Checked = appSettings.show_port_type_icon;
            check_list_auto_refresh.Checked = appSettings.list_auto_refresh;

            if (appSettings.Serial == null)
            {
                appSettings.Serial = new cwAppSettings_serial();


            }
            numericUpDown1.Value = appSettings.Serial.timeout_read;
            numericUpDown3.Value = appSettings.Serial.timeout_write;


  
            
        }
    

        private void resetall_Click(object sender, EventArgs e)
        {

            //Overrite pointer to new record
            appSettings = new cwAppSettings();


            //Reload settings
            //Uses te referance
            settings_Load();
            
            //Restore the referance to allow saving.
            appSettings = cwSerCom.lSettings.appSettings;
        }


        private void Save_Button_Click(object sender, EventArgs e)
        {
         
            appSettings.show_port_type_icon = check_show_port_icon.Checked;
           


            
            appSettings.list_auto_refresh = check_list_auto_refresh.Checked;

            if (appSettings.Serial == null)
            {
                //Never happens
                appSettings.Serial = new cwAppSettings_serial();
            }

            appSettings.Serial.timeout_read = numericUpDown1.Value;
            appSettings.Serial.timeout_write = numericUpDown3.Value;



            //if all values are standard save the whole record as null.
            //Saves space an improvese leggibility of settings.json
            if (appSettings.Serial.Equals(new cwAppSettings_serial()))
            {
                appSettings.Serial = null;
            }
           
            

           

            lSettings.write(appSettings);


            if (appSettings.Serial == null) {
                appSettings.Serial= new cwAppSettings_serial();
            }

            


            this.Close();
        }

        
    }
}
