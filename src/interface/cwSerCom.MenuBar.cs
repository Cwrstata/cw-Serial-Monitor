// ---------------------------------------------------------------------------- //
//  Cwrstata || cw Serial Monitor
//      https://github.com/Cwrstata
//      https://github.com/Cwrstata/cw-Serial-Monitor
//
//      cwMenuBar
//          -v1.0.0
//      You can now connect to ports using only the menubar.
// ---------------------------------------------------------------------------- //




//Contains menu items and interactions.
//Also, most interface management is done here (such as showing or hiding a panel).

using System.Diagnostics;

namespace Exp
{

    partial class cwSerCom {




        /// <summary>
        /// Checks if the left container is empty, if so hides it.
        /// </summary>
        private void splitLeftCheck()
        {

            // fixed bug 0x0004
            if (!splitMain.Visible)
            {

                cwToggleControl.SplitToggleHide(splitMain, false);
                return;
            }
            if (splitContainer2.Panel1Collapsed == true && !dGridInfo.Visible && !dGridSerial.Visible)
            {

                //Automatically hides both if none of them are visible.
                cwToggleControl.SplitToggleHide(splitMain, false);


                return;
            }
            

        }


        //View
                //Port Selector
        private void portSelectorMenuItem2_Click(object sender, EventArgs e)
        {
            cwToggleControl.setCheck(
                cwToggleControl.SplitToggle(splitContainer2, false),
                (ToolStripMenuItem)sender);

            splitLeftCheck();
        }
                //Serial Settings
        private void serialSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            splitMain.Panel1Collapsed = false;

            cwToggleControl.setCheck(
                cwToggleControl.Toggle(dGridSerial),
                (ToolStripMenuItem)sender);

            splitLeftCheck();
        }
                //Serial Info
        private void serialInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitMain.Panel1Collapsed = false;
            cwToggleControl.setCheck(
               cwToggleControl.Toggle(dGridInfo),
               (ToolStripMenuItem)sender);

            splitLeftCheck();
        }
                //Serial Monitor
        private void serialMonitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cwToggleControl.setCheck(
                cwToggleControl.SplitToggleHide(splitMain, true),
                (ToolStripMenuItem)sender);
        }



        //About
        private void repositoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/Cwrstata/cw-Serial-Monitor/tree/main") { UseShellExecute = true });
        }





     

        private void Check_Pin_CheckedChanged(object sender, EventArgs e)
        {



            if (((CheckBox)sender).Checked)
            {
                lastShow = splitMain.Visible;
                splitMain.Show();


                lastPanel1Collapsed = splitMain.Panel1Collapsed;

                viewToolStripMenuItem.Enabled = false;
                splitMain.Panel1Collapsed = false;
                splitMain.Panel2Collapsed = false;
                splitMain.Panel1Collapsed = true;
                this.MaximizeBox = false;

                lastWindowState = this.WindowState;

                this.WindowState = FormWindowState.Normal;

                lastTopMost = this.TopMost;
                this.TopMost = true;
                this.FormBorderStyle = FormBorderStyle.FixedDialog;

                lastSize = this.Size;


                this.Size = this.MinimumSize;


            } else
            {

                splitMain.Visible= lastShow;
            


                splitMain.Panel1Collapsed= lastPanel1Collapsed;

                viewToolStripMenuItem.Enabled = true;
    
                this.MaximizeBox = true;

                this.WindowState= lastWindowState;



                this.TopMost=lastTopMost;

                this.FormBorderStyle = FormBorderStyle.Sizable;

                this.Size = lastSize;



            }
        }




       bool lastShow;
       Size lastSize;
       bool lastTopMost;
       FormWindowState lastWindowState;
       bool lastPanel1Collapsed;

        





        private void CursorToArrow(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void CursorToHand(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //New Message Box
            TaskDialogPage mBox = new TaskDialogPage()
            {
                Heading = "cw Serial Monitor",
                Text = "Version: " + cwVersion + "\r\n@Cwrstata\r\n"+ "https://github.com/Cwrstata/cw-Serial-Monitor/",
                Caption = "cw Serial Monitor",




            };
            if (Icon != null){ mBox.Icon = new TaskDialogIcon(Icon); }
            TaskDialog.ShowDialog(this, mBox);
        }



        private void programFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", @$"{AppDomain.CurrentDomain.BaseDirectory}");
        }
    }



}