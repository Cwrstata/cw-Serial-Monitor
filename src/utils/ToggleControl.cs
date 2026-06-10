// ---------------------------------------------------------------------------- //
//  Cwrstata || cw Serial Monitor
//      https://github.com/Cwrstata
//      https://github.com/Cwrstata/cw-Serial-Monitor
//
//      cwToggleControl
// ---------------------------------------------------------------------------- //




namespace Exp
{



    /// <summary>
    /// Helps to toggle varius types of Controls
    /// </summary>
    public struct cwToggleControl
    {

        /// <summary>
        /// Basic function that automatically toggles the "visible" value in controls.
        /// Returns positive when the object is visible.
        /// </summary>
        public bool Toggle(Control obj)
        {

            if (obj.Visible)
            {
                obj.Hide();
                return false;

            }

            obj.Show();
            return true;


        }

        /// <summary>
        /// Sets ToolStripMenuItem.Checked to "value"
        /// Litteraly useles.
        /// </summary>
        public void setCheck(bool value, ToolStripMenuItem obj)
        {

            obj.Checked = value;


        }

        /// <summary>
        /// Toggles the SplitContainer panel selected via "secondPanel".
        /// Returns positive when the panel is visible.
        /// </summary>
        public bool SplitToggle(SplitContainer obj, bool secondPanel = false)
        {


            if (secondPanel == true)
            {
                if (obj.Panel2Collapsed)
                {

                    return !(obj.Panel2Collapsed = false);

                }


                return !(obj.Panel2Collapsed = true);

            }
            else
            {

                if (obj.Panel1Collapsed)
                {

                    return !(obj.Panel1Collapsed = false);

                }


                return !(obj.Panel1Collapsed = true);


            }
        }
    }
}






