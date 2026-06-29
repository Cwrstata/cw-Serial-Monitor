// ---------------------------------------------------------------------------- //
//  Cwrstata || cw Serial Monitor
//      https://github.com/Cwrstata
//      https://github.com/Cwrstata/cw-Serial-Monitor
//
//      cwAppSettings
//           -v0.1.3a
//      
// ---------------------------------------------------------------------------- //

namespace Exp
{

    public record cwAppSettings_interface
    {
        public bool show_info_grid { get; set; } = true;

    }
    public record cwAppSettings_serial
    {
        public decimal timeout_read  { get; set; } = 500;
        public decimal timeout_write { get; set; } = 500;

    }
    /// <summary>
    /// Class that contains all the program settings
    /// </summary>
    public record cwAppSettings
    {
        public string Version { get; set; } = cwSerCom.cwVersion;

        
        public bool show_port_type_icon { get; set; } = true;
        public bool list_auto_refresh { get; set; } = true;

        public cwAppSettings_interface? Interface { get; set; } = null;
        public cwAppSettings_serial? Serial { get; set; } = new cwAppSettings_serial();

    }

    
}
