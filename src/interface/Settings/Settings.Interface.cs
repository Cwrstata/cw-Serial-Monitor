// ---------------------------------------------------------------------------- //
//  Cwrstata || cw Serial Monitor
//      https://github.com/Cwrstata
//      https://github.com/Cwrstata/cw-Serial-Monitor
//
//      cwSettings.Interface
//           -v1.1.0a
//      
// ---------------------------------------------------------------------------- //



using System.Windows.Forms;

namespace Exp
{
    public partial class cwSettings : Form
    {

        /// <summary>
        /// Previusly selected button in the tab selector
        /// </summary>
        Label previus_label;
        private void tab_General_Click(object sender, EventArgs e)
        {

            previus_label.BorderStyle = BorderStyle.None;

            tabControl.SelectedIndex = ((Label)sender).TabIndex;

            ((Label)sender).BorderStyle = BorderStyle.Fixed3D;
            previus_label = ((Label)sender);
        }
       

    }
}
