// ---------------------------------------------------------------------------- //
//  Cwrstata || cw Serial Monitor
//      https://github.com/Cwrstata
//      https://github.com/Cwrstata/cw-Serial-Monitor
//
//      cwSerCom
//           -v1.1.0a
//      //Settings form is now more organized.
//      
// ---------------------------------------------------------------------------- //



using System.Diagnostics;
using System.Windows.Forms;

namespace Exp
{
    public partial class cwSettings : Form
    {
















        private void WatcherMainCheck_CheckedChanged(object sender, EventArgs e)
        {
            WatcherPanel.Enabled = ((CheckBox)sender).Checked;
        }



        private void A_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Seleziona la cartella di destinazione";
                folderDialog.UseDescriptionForTitle = true;
                folderDialog.ShowNewFolderButton = true;

                // Imposta una cartella di partenza opzionale (es. Documenti)
                folderDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Mostra la finestra di dialogo e verifica se l'utente ha premuto OK
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {

                    WatcherPath.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void WatcherPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
  


            Process.Start(new ProcessStartInfo("https://github.com/Cwrstata/cw-Serial-Monitor/blob/main/docs/Free_While_Flashing.md") { UseShellExecute = true });
        
        }
    }
}
