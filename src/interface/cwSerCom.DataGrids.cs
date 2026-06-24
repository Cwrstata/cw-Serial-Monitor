// ---------------------------------------------------------------------------- //
//  Cwrstata || cw Serial Monitor
//      https://github.com/Cwrstata
//      https://github.com/Cwrstata/cw-Serial-Monitor
//
//      cwDataGrids
//           -v0.1.4a
//      "Serial Info" datagrid now fills asynchronously.
//
// ---------------------------------------------------------------------------- //

//This file contains everything that is related to the dataGridView objects in the form.

using System.Management;


namespace Exp
{
    
    partial class cwSerCom
    {

        List<bool> BluetoothList = new List<bool>();

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




            //This needs a dedicated method.

            int cellsHeight = dGridSerial.ClientRectangle.Height - dGridSerial.ColumnHeadersHeight;
            int rowsHeight = cellsHeight / dGridSerial.Rows.Count;

            if (rowsHeight > 23) { rowsHeight = 23; }
            foreach (DataGridViewRow row in dGridSerial.Rows)
            {

                row.Height = rowsHeight;

            }


            dGridSerial.Height = dGridSerial.Rows[0].Height * 4 + dGridSerial.ColumnHeadersHeight + 1;
            DataGridViewColumn? lastColumn = dGridSerial.Columns.GetLastColumn(DataGridViewElementStates.Visible,
                                DataGridViewElementStates.None);
            if (lastColumn != null)
            {
                lastColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            dGridSerial.Refresh();
            dGridSerial.EndEdit();

            dGridSerial.AutoResizeColumns();

            dGridSerial.ClearSelection();
            dGridSerial.Columns[0].Width = 70;

        }
        //Two click dropdown fix
        private void datagridview_CellEnter(object sender, DataGridViewCellEventArgs e)
        { //It may do nothing a at all :<
           
            var datagridview = sender as DataGridView;
            if (datagridview == null || (e.RowIndex != -1 && e.ColumnIndex != -1)) { 
                //Returns if grid is null or if the cell is not selected.
                return; }

            if (datagridview.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn)
            {
                datagridview.BeginEdit(true);

#pragma warning disable CS8602 
                ((ComboBox?)datagridview.EditingControl).DroppedDown = true;
#pragma warning restore CS8602 

                datagridview.EndEdit();

            }
        }

        /// <summary> 
        /// Abquires port informations trough ManagementObjectSearcher.
        /// 
        /// </summary>
        /// <returns>Return a ComPortDetails struct, if the querry provides no results returns null </returns>
        public ComPortDetails? GetComPortDetails(string? portn)
        {
            //To do
            //Split this in two distinct methods

            if (portn == null)
            {
                //Abort if portn is null
                return null;
            }
            ComPortDetails ret;

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher($"SELECT * FROM Win32_PnPEntity WHERE PNPClass = 'Ports' AND Caption LIKE '%({portn})%'"))
            {


                
                    if (searcher.Get().Count == 0) { return null; }

  
                    var port = searcher.Get().Cast<ManagementObject>().FirstOrDefault();
                    if (port == null) { return null; }

                    

              

                ret.Caption = port["Caption"]?.ToString();
                ret.Manufacturer = port["Manufacturer"]?.ToString();
                ret.Description = port["Description"]?.ToString();
                ret.Present = port["Present"]?.ToString();
                ret.Status = port["Status"]?.ToString();
                ret.PNPDeviceID = port["PNPDeviceID"]?.ToString();

                

            }

            return ret;
        }


        /// <summary>
        /// Called every time a new port is selected to retrieve all avaible informations.
        /// </summary>
        private async void comPortList_SelectedIndexChanged(object? sender, EventArgs e)
        {

            //This happens only if approrpiate grid is visible.
            if (dGridInfo.Visible)
            {

                if (comPortsList.SelectedIndex != -1 && comPortsList.SelectedIndex < comPortsList.Items.Count)
                {

                    if (comPortsList.SelectedItem == null) { return; }

                    string? port_s = comPortsList.SelectedItem.ToString();
                    ComPortDetails ?cmDet= await Task.Run(() => GetComPortDetails(port_s));

                    
                    
                    dGridInfo.DataSource = null;
                    dGridInfo.Rows.Clear();
                    dGridInfo.Columns.Clear();

                    if (cmDet == null) { return; }
                    //Column
                    dGridInfo.Columns.Add("Info", "Info");
                    dGridInfo.Columns.Add("Data", "Data");
                    dGridInfo.EnableHeadersVisualStyles = false;
                    dGridInfo.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control;
                    dGridInfo.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dGridInfo.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

                    //Cells
                    
                    if (cmDet.Value.Caption != null)
                        dGridInfo.Rows.Add("Caption", cmDet.Value.Caption);

                    if (cmDet.Value.Manufacturer != null)
                        dGridInfo.Rows.Add("Manufacturer", cmDet.Value.Manufacturer);

                    if (cmDet.Value.Description != null)
                        dGridInfo.Rows.Add("Description", cmDet.Value.Description);

                    if (cmDet.Value.Present != null)
                        dGridInfo.Rows.Add("Present", cmDet.Value.Present);

                    if (cmDet.Value.Status != null)
                        dGridInfo.Rows.Add("Status", cmDet.Value.Status);

                    if (cmDet.Value.PNPDeviceID!=null)
                        dGridInfo.Rows.Add("PNP ID", cmDet.Value.PNPDeviceID);

                    dGridInfo.AutoResizeColumns();


                    int cellsHeight = dGridInfo.ClientRectangle.Height - dGridInfo.ColumnHeadersHeight;
                    int rowsHeight = cellsHeight / dGridInfo.Rows.Count;

                    foreach (DataGridViewRow row in dGridInfo.Rows)
                    {
                        row.Height = rowsHeight;
                    }

                    DataGridViewColumn? lastColumn = dGridInfo.Columns.GetLastColumn(DataGridViewElementStates.Visible,
                                        DataGridViewElementStates.None);
                    if (lastColumn != null)
                    {
                        lastColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }

                    dGridInfo.SelectionMode = 0;

                    dGridInfo.ClearSelection();
                }

            }



        }

    }

    public struct ComPortDetails
    {
        public string? Caption;
        public string? Manufacturer;
        public string? Description;
        public string? Present;
        public string? Status;
        public string? PNPDeviceID;
    }

}