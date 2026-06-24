// ---------------------------------------------------------------------------- //
//  Cwrstata || cw Serial Monitor
//      https://github.com/Cwrstata
//      https://github.com/Cwrstata/cw-Serial-Monitor
//
//      cwError
//           -v0.1.4a
// ---------------------------------------------------------------------------- //

namespace Exp
{


    static public class cwError
    {
        /// <summary>
        /// Displays a error message box containing the exeption main message.
        /// A "Show More" button reveales the whole error dialogue.
        /// </summary>
        public static void ErrorInfo(Exception exception, string title, string description , Form owner)
        {

            TaskDialog.ShowDialog(owner,new TaskDialogPage()
            {
                Caption = title,
                Heading = description,
                Text = exception.Message,
                Icon = TaskDialogIcon.Error,
                Buttons = { TaskDialogButton.OK },

                Expander = new TaskDialogExpander()
                {
                    Text = exception.ToString(),
                    
                    Position = TaskDialogExpanderPosition.AfterFootnote
                }
            });




        }
    }

}