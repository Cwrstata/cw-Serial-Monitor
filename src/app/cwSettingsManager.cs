// ---------------------------------------------------------------------------- //
//  Cwrstata || cw Serial Monitor
//      https://github.com/Cwrstata
//      https://github.com/Cwrstata/cw-Serial-Monitor
//
//      cwSettingsManager
//           -v0.1.3a
//      
// ---------------------------------------------------------------------------- //

using System.Text.Json;


namespace Exp
{

    /// <summary>
    /// Manages reading and writing of settings file written in json.
    /// </summary>
    public class cwSettingsManager
    {
        private string filePath = "settings.json";
        public cwAppSettings appSettings = new cwAppSettings();

        /// <summary>
        /// Saves any given AppSettings class on a file.
        /// </summary>
        /// <param name="inputSettings"></param>
        /// <returns>Returns false when an error occurs</returns>
        public bool write(cwAppSettings inputSettings) {
            try { 
            string json_s = JsonSerializer.Serialize(inputSettings, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json_s);
            } catch { return false; }
            return true;
        }
        /// <summary>
        /// Reads from a json file.
        /// The resulting settings configurations is saved in the public cwAppSettings variable in this class.
        /// </summary>
        /// <returns>Returns false when an error occurs or when the file doesen't exist, in those cases the cwAppSettings variable is left untouched. </returns>
        public bool read() {

            if (File.Exists(filePath))
            {


                try { 
                string readPath = File.ReadAllText(filePath);
                appSettings= JsonSerializer.Deserialize<cwAppSettings>(readPath) ?? new cwAppSettings();
                } catch { return false; }
                return true;
            

            
            }

            return false;


        }

        /// <summary>
        /// Checks if appSettings or one of its branches are null.
        /// When thats the case, it chenges them to the default values.
        /// </summary>
        public void nullFill()
        {
            if (appSettings == null) {
                appSettings=new cwAppSettings();
            }
            if (appSettings.Serial == null) 
            {
                appSettings.Serial= new cwAppSettings_serial();
            }

        }
    }
}
