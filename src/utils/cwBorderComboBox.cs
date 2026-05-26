// ---------------------------------------------------------------------------- //
//  Cwrstata || cw Border Combo Box
//      https://github.com/Cwrstata
//      https://github.com/Cwrstata/cw-Serial-Monitor
//
//      cwBorderComboBox
//          
//      Custom Control that draws on top of a combo box.
//      This combo box replaces the dafault white arrow with one that is in line with the Foreground Color.
//      You also can specify how the borders are drawn.
// ---------------------------------------------------------------------------- //


using System;
using System.Drawing;
using System.Windows.Forms;



    public class cwBorderComboBox : ComboBox
    {

        public cwBorderComboBox() { }

        private ScrollBars _BordersDirection = ScrollBars.Both;
        /// <summary>
        /// Custom borders parameter.
        /// </summary>
        [System.ComponentModel.Category("Custom"),
        System.ComponentModel.Description("Dictates where the borders are drawn."),
        System.ComponentModel.DefaultValue(ScrollBars.Both)]
        public ScrollBars Borders
        {
            get => _BordersDirection;
            set
            {
                _BordersDirection = value;
                Invalidate();
            }
        }


        private Color _BordersColor = Color.Gray;
        /// <summary>
        /// Custom borders parameter.
        /// </summary>
        [System.ComponentModel.Category("Custom"),
        System.ComponentModel.Description("Border Style."),
        System.ComponentModel.DefaultValue(null)]
        public Color BorderStyle
        {
            get => _BordersColor;
            set
            {
                _BordersColor = value;
                Invalidate();
            }
        }






        private const int WM_PAINT = 0xF;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);


            if (m.Msg == WM_PAINT && DropDownStyle != ComboBoxStyle.Simple)
            {this.DoubleBuffered = true;
                using (var boxGrf = Graphics.FromHwnd(Handle))
                {


                    var pen_Border = new Pen(_BordersColor, 1);



                    using (var pen = new Pen(this.BackColor, 2))
                    {
                        using (var brush = new SolidBrush(this.BackColor))
                        {
                         
                        
                        
                        
                           
                            using (var _backColor = new SolidBrush(this.BackColor))
                            {
                                
                                boxGrf.FillRectangle(_backColor, Width-20, 0, Width, Height);
                                boxGrf.DrawRectangle(pen, 0, 0, Width-1, Height-1);

                                switch (_BordersDirection) {
                                
                                    case ScrollBars.Both:
                                        boxGrf.DrawRectangle(pen_Border, 0, 0, Width - 1, Height - 1);

                                        break;
                                    case ScrollBars.Vertical:
                                        boxGrf.DrawLine(pen_Border, 0, 0, Width, 0);
                                        boxGrf.DrawLine(pen_Border, 0, Height - 1, Width, Height - 1);
                                        break;
                                    case ScrollBars.Horizontal:
                                        boxGrf.DrawLine(pen_Border, 0, 0, 0, Height - 1);
                                        boxGrf.DrawLine(pen_Border, Width - 1, 0, Width - 1, Height - 1);
                                        break;

                                }

                                
                            }
                            using (Font _Font = new Font("Cascadia Code", 10,FontStyle.Bold))
                            {
                                var _foreColor = new SolidBrush(this.ForeColor);
                                boxGrf.DrawString("▼", _Font, _foreColor, Width - 18, 4.3f);
                            }
                           
                        }

                     
                    }
                }
            }
        }
    }

