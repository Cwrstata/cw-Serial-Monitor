// ---------------------------------------------------------------------------- //
//  Cwrstata || cw Serial Monitor
//      https://github.com/Cwrstata
//      https://github.com/Cwrstata/cw-Serial-Monitor
//
//      cwSerCom
//          -v0.1.2a
//      Unused Settings Form.
// ---------------------------------------------------------------------------- //
/*
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exp
{
    public partial class cwSettings : Form
    {
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

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            
        }

        private void cwSettings_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(label2, "The method by which the data is received and printed to the console\r\n" +
                "When \"Line by line\" is chosen, the program will wait for a new line character before printing to the console.");
            toolTip1.SetToolTip(comboBox2, "The method by which the data is received and printed to the console\r\n" +
                "When \"Line by line\" is chosen, the program will wait for a new line character before printing to the console.");
        }
    }
}
*/