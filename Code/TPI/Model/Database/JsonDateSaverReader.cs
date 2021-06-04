using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

using Model.Exceptions;

namespace Model
{
    /// <summary>
    /// this class was designed to read and save user and app settings from json
    /// </summary>
    public class JsonDataSaverReader
    {
        const string path = ".\\Data\\";
        const string appSettingsFileName = "ApplicationParameter.json";
        

        

        public static ApplicationSettings ReadAppSettings()
        {
            if (File.Exists(path + appSettingsFileName))
            {
                string json;
                using (var reader = new StreamReader(path + appSettingsFileName))
                {
                    json = reader.ReadToEnd();
                }
                return JsonConvert.DeserializeObject<ApplicationSettings>(json);
            }
            else
            {
                throw new ApplicationSettingsError();
            }
        }

        

    }
}
