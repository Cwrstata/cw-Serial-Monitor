// ---------------------------------------------------------------------------- //
//  Cwrstata || cw Serial Monitor
//      https://github.com/Cwrstata
//      https://github.com/Cwrstata/cw-Serial-Monitor
//
//      cwIDEWatcher
//           -v1.1.0a
//      Detects flashing based binaries being modified in a specific path.
//      Can be configured in settings.
//
// ---------------------------------------------------------------------------- //


namespace Exp
{

    partial class cwSerCom
    {
        private System.IO.FileSystemWatcher ? _fileWatcher = null;
        private bool _isProcessingEvent = false;
        private void InitializeIDEWatcher()
        {
            WatcherAbort();



            if (appSettings.Watcher==null) { return; }
          
            if (appSettings.Watcher.enabled==false) { return; }

            if (SPort==null) { return; }

            string TempPath = Environment.ExpandEnvironmentVariables(appSettings.Watcher.path);

           
            if (!System.IO.Directory.Exists(TempPath))
            {

                cwError.ErrorInfo("File Path does not exist, Flash watcher will now be disabled\n", "Flash Watcher", "Flash Watcher", this);

                appSettings.Watcher.enabled = false;
                return;
            }

            _fileWatcher = new System.IO.FileSystemWatcher();
            _fileWatcher.Path = TempPath;
            _fileWatcher.IncludeSubdirectories = appSettings.Watcher.watch_sub_dir;

            _fileWatcher.Filter = "*.*"; 
            _fileWatcher.NotifyFilter = System.IO.NotifyFilters.FileName | System.IO.NotifyFilters.LastWrite;

            
            _fileWatcher.Created += WatcherFileDetected;

            _fileWatcher.Changed += WatcherFileDetected;

           
            _fileWatcher.EnableRaisingEvents = true;
            detection_Count = 0;
        }

        int detection_Count=0;

        private void WatcherFileDetected(object sender, System.IO.FileSystemEventArgs e)
        {
            string extension = System.IO.Path.GetExtension(e.FullPath).ToLower();

            if (appSettings.Watcher == null) { return; }

            if (extension == appSettings.Watcher.file_type)
            {
                if (_isProcessingEvent) return;
                _isProcessingEvent = true;
                detection_Count++;
                if (detection_Count == appSettings.Watcher.close_at)
                {
                    if (appSettings.Watcher.disconnect_only) {
                        this.Invoke(new Action(() =>
                        { 
                        Port_Disconnect();
                        led.ForeColor = Color.Blue;

                        }));

                        detection_Count = 0;
                        WatcherAbort();


                        //Colored Text
                        textBoxMonitor.SelectionStart = textBoxMonitor.TextLength;
                        textBoxMonitor.SelectionLength = 0;
                        textBoxMonitor.SelectionColor = Color.Blue;
                        textBoxMonitor.AppendText("\n\n!!Flashing, Disconnected!!\n\n");
                        textBoxMonitor.SelectionColor = textBoxMonitor.ForeColor;

                        return;
                        }


                    
                    this.Invoke(new Action(() =>
                    {

                        if (SPort == null) {

                            //Sus
                            WatcherAbort();
                            return;
                            
                        }

                        led.ForeColor = Color.Blue;
                        this.Cursor = Cursors.AppStarting;
                        Disconnect.Enabled = false;
                        Refresh.Enabled = false;
                        Connect.Enabled = false;
                        menuStrip1.Enabled = false;

                        SPort.Close();

                        //Colored Text
                        textBoxMonitor.SelectionStart = textBoxMonitor.TextLength;
                        textBoxMonitor.SelectionLength = 0;
                        textBoxMonitor.SelectionColor = Color.Blue;
                        textBoxMonitor.AppendText("\n\n!!Flashing!!\n\n");
                        textBoxMonitor.SelectionColor = textBoxMonitor.ForeColor;


                        
                        _isProcessingEvent = false;


                        _ = Task.Run(async () =>
                        {
                            await Task.Delay(appSettings.Watcher.abort_after);
                            this.Invoke(new Action(() =>
                            {
                                if (Disconnect.Enabled == true || _isProcessingEvent == true) { } else { 
                                    led.ForeColor = Color.LimeGreen;
                                InitializeIDEWatcher();
                                Port_Refresh();
                                Disconnect.Enabled = true;
                                Refresh.Enabled = true;
                                Connect.Enabled = true;
                                menuStrip1.Enabled = true;
                                this.Cursor = Cursors.Default;

                                    cwError.ErrorInfo("Unable to determine if or when the program started flashing.\nTimed out (20000)", "IDE Watcher hang up", "IDE Watcher hang up", this);
                                }
                            }));
                        });
                    }));

                    return;

                }
                if (detection_Count == appSettings.Watcher.assume_flashing_at)
                {
              


                    this.Invoke(new Action(() =>
                    {

                        Thread.Sleep(appSettings.Watcher.assume_flashing_after);

                        if (SPort != null)
                        {

                           
                            

                        

                        for (int i = 0; i < 128; i++)
                        {

                           
                            Thread.Sleep(60);
                            try
                            {
                                SPort.Open();
                            }
                            catch 
                            {
                            }
                  
                               
                                if (SPort.IsOpen)
                                 {
                                break;
                                  }


                        }

                        }


                        _isProcessingEvent = false;
                        WatcherAbort();

                        _ = Task.Run(async () =>
                        {
                            _isProcessingEvent = true;
                            await Task.Delay(2000);
                            this.Invoke(new Action(() =>
                            {
                              
                                led.ForeColor = Color.LimeGreen;
                                InitializeIDEWatcher();
                                Port_Refresh();
                                Disconnect.Enabled = true;
                                Refresh.Enabled = true;

                                Connect.Enabled = true;
                                menuStrip1.Enabled = true;
                                _isProcessingEvent = false;
                                this.Cursor = Cursors.Default;

                            }));
                        });

                    }));


                }
                else
                {
                    _isProcessingEvent = false;
                }



            }
        }

  

        private void WatcherAbort() {
            if (_fileWatcher != null)
            {
                _fileWatcher.Created -= WatcherFileDetected;
                _fileWatcher.Changed -= WatcherFileDetected;
            
                _fileWatcher.EnableRaisingEvents = false;
                _fileWatcher.Dispose();
                _fileWatcher = null;

            }
        }

        private void cwSerCom_FormClosing(object sender, FormClosingEventArgs e)
        {
            WatcherAbort();


        }
    }
}