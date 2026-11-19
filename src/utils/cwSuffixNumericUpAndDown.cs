// ---------------------------------------------------------------------------- //
//  Cwrstata || cw Border Combo Box
//      https://github.com/Cwrstata
//      https://github.com/Cwrstata/cw-Serial-Monitor
//
//      cwNumericUpAndDown
//          
//      Custom Control that adds a suffix to the Numeric Up And Down control.
//      
//      
// ---------------------------------------------------------------------------- //


using System;
using System.Windows.Forms;


namespace Exp
{
    public class cwNumericUpAndDown : NumericUpDown
    {
        [System.ComponentModel.Category("Custom"),
        System.ComponentModel.Description("Suffix"),
        System.ComponentModel.DefaultValue("ms")]
        public string Suffix{ get; set; } = "ms";
        /// <summary>
        /// Suffix
        /// </summary>
        
     
        protected override void UpdateEditText()
        {

            this.ChangingText = true;


            this.Text = this.Value.ToString() + Suffix;
        }
    }

}