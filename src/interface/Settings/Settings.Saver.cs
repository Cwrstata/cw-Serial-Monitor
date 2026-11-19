// ---------------------------------------------------------------------------- //
//  Cwrstata || cw Serial Monitor
//      https://github.com/Cwrstata
//      https://github.com/Cwrstata/cw-Serial-Monitor
//
//      cwSettings.Saver
//           -v1.1.0a
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



        public cwSettings()
        {
            InitializeComponent();
            previus_label = tab_General;


        }





        private void cwSettings_Load(object sender, EventArgs e)
        {

            tabControl.ItemSize = new Size(0, 1);


            lSettings.read();
            //Set pointer
            appSettings = cwSerCom.lSettings.appSettings;
            settings_Load();
          

        }

 
        void settings_Load()
        {

            check_show_port_icon.Checked = appSettings.show_port_type_icon;
            check_list_auto_refresh.Checked = appSettings.list_auto_refresh;




            if (appSettings.Serial == null)
            {
                appSettings.Serial = new cwAppSettings_serial();


            }
            numericUpDown1.Value = appSettings.Serial.timeout_read;
            numericUpDown3.Value = appSettings.Serial.timeout_write;

            if (appSettings.Watcher == null)
            {
                appSettings.Watcher = new cwAppSettings_Watcher();


            }
            WatcherMainCheck.Checked        =   appSettings.Watcher.enabled;
            WatcherPath.Text                =    appSettings.Watcher.path;

            WatcherFileType.Text            =   appSettings.Watcher.file_type;
            WatcherSubDir.Checked           =   appSettings.Watcher.watch_sub_dir;

            WatcherDisconnectOnly.Checked   =   appSettings.Watcher.disconnect_only;

            WatcherFlashAfter.Value         =   appSettings.Watcher.assume_flashing_after;
            WatcherFlashAt.Value            =   appSettings.Watcher.assume_flashing_at;
            WatcherAbortAfter.Value         =   appSettings.Watcher.abort_after;
            WatcherCloseAt.Value            =   appSettings.Watcher.close_at;



            

        
          






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
            if (appSettings.Watcher == null)
            {
                //Never happens
                appSettings.Watcher = new cwAppSettings_Watcher();
            }


            appSettings.Serial.timeout_read = numericUpDown1.Value;
            appSettings.Serial.timeout_write = numericUpDown3.Value;



            //if all values are standard save the whole record as null.
            //Saves space an improvese leggibility of settings.json
            if (appSettings.Serial.Equals(new cwAppSettings_serial()))
            {
                appSettings.Serial = null;
            }


            

            appSettings.Watcher.enabled = WatcherMainCheck.Checked;
            appSettings.Watcher.path = WatcherPath.Text;

            appSettings.Watcher.file_type = WatcherFileType.Text;
            appSettings.Watcher.watch_sub_dir = WatcherSubDir.Checked;

            appSettings.Watcher.disconnect_only = WatcherDisconnectOnly.Checked;

            appSettings.Watcher.assume_flashing_after = (int)WatcherFlashAfter.Value;
            appSettings.Watcher.assume_flashing_at = WatcherFlashAt.Value;
            appSettings.Watcher.abort_after = (int)WatcherAbortAfter.Value;
            appSettings.Watcher.close_at = WatcherCloseAt.Value;

            if (appSettings.Watcher.Equals(new cwAppSettings_Watcher()))
            {
                appSettings.Watcher = null;
            }



            lSettings.write(appSettings);


          





            this.Close();
        }

    }
}
