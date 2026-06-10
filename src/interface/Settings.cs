// ---------------------------------------------------------------------------- //
//  Cwrstata || cw Serial Monitor
//      https://github.com/Cwrstata
//      https://github.com/Cwrstata/cw-Serial-Monitor
//
//      cwSerCom
//          -v0.1.3a
//      Settings Form!!
// ---------------------------------------------------------------------------- //



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
        private void tab_Serial_Click(object sender, EventArgs e)
        {

            previus_label.BorderStyle = BorderStyle.None;

            tabControl.SelectedIndex = 1;

            tab_Serial.BorderStyle = BorderStyle.Fixed3D;
            previus_label = tab_Serial;
        }

 

        private void cwSettings_Load(object sender, EventArgs e)
        {

            tabControl.ItemSize = new Size(0, 1);
            toolTip1.SetToolTip(label2, "The method by which the data is received and printed to the console\r\n" +
                "When \"Line by line\" is chosen, the program will wait for a new line character before printing to the console.");
            toolTip1.SetToolTip(comboBox2, "The method by which the data is received and printed to the console\r\n" +
                "When \"Line by line\" is chosen, the program will wait for a new line character before printing to the console.");

            lSettings.read();


            check_show_port_icon.Checked = appSettings.show_port_type_icon;
            check_list_auto_refresh.Checked = appSettings.list_auto_refresh;
        }

    

        private void resetall_Click(object sender, EventArgs e)
        {


            cwAppSettings copy = new cwAppSettings();

            check_show_port_icon.Checked = copy.show_port_type_icon;
            check_list_auto_refresh.Checked = copy.list_auto_refresh;
        }


        private void Save_Button_Click(object sender, EventArgs e)
        {
            appSettings.show_port_type_icon = check_show_port_icon.Checked;
            appSettings.list_auto_refresh = check_list_auto_refresh.Checked;
            lSettings.write(appSettings);
            this.Close();
        }

        
    }
}
