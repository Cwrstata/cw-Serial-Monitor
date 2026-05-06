// ---------------------------------------------------------------------------- //
//  Cwrstata || cw Serial Monitor
//      https://github.com/Cwrstata
//      https://github.com/Cwrstata/cw-Serial-Monitor
//
//      cwDataGrids
// ---------------------------------------------------------------------------- //

//This file contains everything that is related to the dataGridView objects in the form.

using System.Management;


namespace Exp
{
    
    partial class cwSerCom
    {
        //Serial Settings

        //Serial Settings options definition;
        List<int> BaudRates = new List<int> { 1200, 2400, 4800, 9600, 19200, 38400, 57600, 115200, 230400, 460800, 921600 };
        List<string> ParityType = new List<string> { "None", "Odd", "Even", "Mark", "Space" };
        List<int> DataBits = new List<int> { 5, 6, 7, 8 };
        List<int> sStopBits = new List<int> { 1, 2 };
        //Cells
        DataGridViewComboBoxCell cellBaudRates = new DataGridViewComboBoxCell();
        DataGridViewComboBoxCell cellDataBits = new DataGridViewComboBoxCell();
        DataGridViewComboBoxCell cellParityType = new DataGridViewComboBoxCell();
        DataGridViewComboBoxCell cellStopBits = new DataGridViewComboBoxCell();

        /// <summary>
        /// Called only once at program startup.
        /// Sets the dataGridView control with serial communication settings.
        /// </summary>
        public void cellSerial()
        {





            dGridSerial.DataSource = null;
            dGridSerial.Rows.Clear();
            dGridSerial.Columns.Clear();



            //Column
            dGridSerial.Columns.Add("Settings", "Settings");
            dGridSerial.Columns.Add("Value", "Value");

            dGridSerial.EnableHeadersVisualStyles = false;
            dGridSerial.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control;
            dGridSerial.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dGridSerial.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            int selCell;


            //BaudRate Selector
            selCell = dGridSerial.Rows.Add("Baud");
            cellBaudRates.DataSource = BaudRates;
            cellBaudRates.ValueType = typeof(int);
            dGridSerial[1, selCell] = cellBaudRates;
            dGridSerial[0, selCell].Selected = false;
            dGridSerial[0, selCell].ReadOnly = true;
            cellBaudRates.Value = 115200;       //Default Value
            cellBaudRates.ReadOnly = false;



            //ParityType Selector
            selCell = dGridSerial.Rows.Add("Parity type");
            cellParityType.DataSource = ParityType;
            cellParityType.ValueType = typeof(string);
            dGridSerial[1, selCell] = cellParityType;
            dGridSerial[0, selCell].Selected = false;
            dGridSerial[0, selCell].ReadOnly = true;
            cellParityType.Value = "None";       //Default Value
            cellParityType.ReadOnly = false;



            //DataBits Selector
            selCell = dGridSerial.Rows.Add("Data Bits");
            cellDataBits.DataSource = DataBits;
            cellDataBits.ValueType = typeof(int);
            dGridSerial[1, selCell] = cellDataBits;
            dGridSerial[0, selCell].Selected = false;
            dGridSerial[0, selCell].ReadOnly = true;
            cellDataBits.Value = 8;       //Default Value
            cellDataBits.ReadOnly = false;



            //StopBits Selector
            selCell = dGridSerial.Rows.Add("Stop Bits");
            cellStopBits.DataSource = sStopBits;
            cellStopBits.ValueType = typeof(int);
            dGridSerial[1, selCell] = cellStopBits;
            dGridSerial[0, selCell].Selected = false;
            dGridSerial[0, selCell].ReadOnly = true;
            cellStopBits.Value = 1;       //Default Value
            cellStopBits.ReadOnly = false;






            //dGridSerial[1, selCell].heigh






            int cellsHeight = dGridSerial.ClientRectangle.Height - dGridSerial.ColumnHeadersHeight;
            int rowsHeight = cellsHeight / dGridSerial.Rows.Count;

            if (rowsHeight > 23) { rowsHeight = 23; }
            foreach (DataGridViewRow row in dGridSerial.Rows)
            {

                row.Height = rowsHeight;

            }


            dGridSerial.Height = dGridSerial.Rows[0].Height * 4 + dGridSerial.ColumnHeadersHeight + 1;
            dGridSerial.Columns.GetLastColumn(DataGridViewElementStates.Visible,
                                DataGridViewElementStates.None).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dGridSerial.Refresh();
            dGridSerial.EndEdit();

            dGridSerial.AutoResizeColumns();

            dGridSerial.ClearSelection();


        }
        //Two click dropdown fix
        private void datagridview_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
           
            var datagridview = sender as DataGridView;
            if (datagridview == null || (e.RowIndex != -1 && e.ColumnIndex != -1)) { 
                //Returns if grid is null or if the cell is not selected.
                return; }

            if (datagridview.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn)
            {
                datagridview.BeginEdit(true);
                ((ComboBox)datagridview.EditingControl).DroppedDown = true;
            }
        }

        /// <summary> 
        /// Abquires port informations trough ManagementObjectSearcher, then redraws the grid.
        /// 
        /// </summary>
        public void GetComPortDetails(string? portn)
        {
            //To do
            //Split this in two distinct methods

            if (portn == null)
            {
                //Abort if portn is null
                return;
            }

            using (var searcher = new ManagementObjectSearcher($"SELECT * FROM Win32_PnPEntity WHERE Caption LIKE '%({portn}%)'"))
            {
                // cellBaudRates.DetachEditingControl();


                if (searcher.Get().Count == 0) { return; }

                var port = searcher.Get().Cast<ManagementObject>().First();


                dGridInfo.DataSource = null;
                dGridInfo.Rows.Clear();
                dGridInfo.Columns.Clear();

                //Column
                dGridInfo.Columns.Add("Info", "Info");
                dGridInfo.Columns.Add("Data", "Data");
                dGridInfo.EnableHeadersVisualStyles = false;
                dGridInfo.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control;
                dGridInfo.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                dGridInfo.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

                //Cells

                dGridInfo.Rows.Add("Caption", port["Caption"]?.ToString());
                dGridInfo.Rows.Add("Manufacturer", port["Manufacturer"]?.ToString());
                dGridInfo.Rows.Add("Description", port["Description"]?.ToString());
                dGridInfo.Rows.Add("Present", port["Present"]?.ToString());
                dGridInfo.Rows.Add("Status", port["Status"]?.ToString());
                dGridInfo.Rows.Add(" PNP ID", port["PNPDeviceID"]?.ToString());






                dGridInfo.AutoResizeColumns();


                int cellsHeight = dGridInfo.ClientRectangle.Height - dGridInfo.ColumnHeadersHeight;
                int rowsHeight = cellsHeight / dGridInfo.Rows.Count;

                foreach (DataGridViewRow row in dGridInfo.Rows)
                {
                    row.Height = rowsHeight;
                }

                dGridInfo.Columns.GetLastColumn(DataGridViewElementStates.Visible,
                                    DataGridViewElementStates.None).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dGridInfo.SelectionMode = 0;

                dGridInfo.ClearSelection();

                dGridSerial.Columns[0].Width = 70;









            }
        }

        

    }



}