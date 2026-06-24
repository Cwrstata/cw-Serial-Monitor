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
    public static class cwToggleControl
    {

        /// <summary>
        /// Basic function that automatically toggles the "visible" value in controls.
        /// Returns positive when the object is visible.
        /// </summary>
        public static bool Toggle(Control obj)
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
        public static void setCheck(bool value, ToolStripMenuItem obj)
        {

            obj.Checked = value;


        }

        /// <summary>
        /// Toggles the SplitContainer panel selected via "secondPanel".
        /// </summary>
        /// <returns>Returns positive when the panel is visible.</returns>
        public static bool SplitToggle(SplitContainer obj, bool secondPanel = false)
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


        /// <summary>
        /// Toggles the SplitContainer panel selected via "secondPanel".
        /// Hides the entire control if both panels are collapsed.
        /// </summary>
        /// <returns>Returns positive when the panel is visible.</returns>
        public static bool SplitToggleHide(SplitContainer obj, bool secondPanel = false)
        {


            if (secondPanel == true)
            {
                if (!obj.Visible)
                {
                    obj.Show();

                    obj.Panel2Collapsed = false;
                    //if control was invisble, collapses the other panel.
                    obj.Panel1Collapsed = true;
                    return true;
                }        
                
                if (obj.Panel2Collapsed)
                {
                    obj.Panel2Collapsed = false;
                    

                    return true;


                }


                if (obj.Panel1Collapsed)
                {
                    //Both can't be collapsed at the same time
                    //It doesen't matter witch one is collapsed

                    obj.Hide();

                    return false;
                } 

                obj.Panel2Collapsed = true;
                return false;

            }
            else
            {


                if (!obj.Visible)
                {
                    obj.Show();

                    obj.Panel1Collapsed = false;
                    obj.Panel2Collapsed = true;
                    return true;
                }




                if (obj.Panel1Collapsed)
                {
                    obj.Panel1Collapsed = false;
                    

                    return true;


                }


                if (obj.Panel2Collapsed)
                {
                    //Both can't be collapsed at the same time
                    //It doesen't matter witch one is collapsed

                    obj.Hide();

                    return false;
                }

                obj.Panel1Collapsed = true;
                return false;


            }
        }
    }
}






