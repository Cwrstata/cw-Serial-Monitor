// ---------------------------------------------------------------------------- //
//  Cwrstata || cw Serial Monitor
//      https://github.com/Cwrstata
//      https://github.com/Cwrstata/cw-Serial-Monitor
//
//      cwMenuBar
// ---------------------------------------------------------------------------- //





//Contains menu items and interactions.
//Also, most interface management is done here (such as showing or hiding a panel).

using Exp2.src.utils;
using System.Diagnostics;

namespace Exp
{

    partial class cwSerCom {



        cwToggleControl cwToggleController = new cwToggleControl();

        /// <summary>
        /// Checks if the left container is empty, if so hides it.
        /// </summary>
        private void splitLeftCheck()
        {
            if (splitContainer2.Panel1Collapsed == true && !dGridInfo.Visible && !dGridSerial.Visible)
            {
                splitMain.Panel1Collapsed = true;
                return;
            }
            splitMain.Panel1Collapsed = false;

        }


        //View
                //Port Selector
        private void portSelectorMenuItem2_Click(object sender, EventArgs e)
        {
            cwToggleController.setCheck(
                cwToggleController.SplitToggle(splitContainer2, false),
                (ToolStripMenuItem)sender);

            splitLeftCheck();
        }
                //Serial Settings
        private void serialSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            splitMain.Panel1Collapsed = false;

            cwToggleController.setCheck(
                cwToggleController.Toggle(dGridSerial),
                (ToolStripMenuItem)sender);

            splitLeftCheck();
        }
                //Serial Info
        private void serialInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitMain.Panel1Collapsed = false;
            cwToggleController.setCheck(
               cwToggleController.Toggle(dGridInfo),
               (ToolStripMenuItem)sender);

            splitLeftCheck();
        }
                //Serial Monitor
        private void serialMonitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cwToggleController.setCheck(
                cwToggleController.SplitToggle(splitMain, true),
                (ToolStripMenuItem)sender);
        }



        //About
        private void repositoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/Cwrstata/cw-Serial-Monitor/tree/main") { UseShellExecute = true });
        }

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
            MessageBox.Show("Version: " + cwVersion, "cw Serial Monitor",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
        }

    }



}