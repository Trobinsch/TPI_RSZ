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
        const string userDefaultSettingsFileName = "DefaultUserSettings.json";

        /// <summary>
        /// static method used to write user settings in json
        /// </summary>
        /// <param name="userEmail">the mail of the user (used for the file name)</param>
        /// <param name="settings">the settings to put in Json</param>
        //public static void WriteUsersettings(string userEmail, UserSettings settings)
        //{
        //    string jsonString = JsonConvert.SerializeObject(settings);
        //    using (StreamWriter writer = new StreamWriter(path + userEmail + ".json", false))
        //    {
        //        writer.WriteLine(jsonString);
        //    }
        //}

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

        //public static UserSettings ReadUserSettings(string userEmail)
        //{
        //    if (File.Exists(path + userEmail + ".json"))
        //    {
        //        string json;
        //        using (var reader = new StreamReader(path + userEmail + ".json"))
        //        {
        //            json = reader.ReadToEnd();
        //        }
        //        return JsonConvert.DeserializeObject<UserSettings>(json);
        //    }
        //    else
        //    {
        //        string sourceFile = path + userDefaultSettingsFileName;
        //        string destinationFile = path + userEmail + ".json";
        //        File.Copy(sourceFile, destinationFile);
        //        if (File.Exists(path + userEmail + ".json"))
        //        {

        //            string json;
        //            using (var reader = new StreamReader(sourceFile))
        //            {
        //                json = reader.ReadToEnd();
        //            }
        //            return JsonConvert.DeserializeObject<UserSettings>(json);
        //        }
        //        else { throw new ApplicationSettingsError(); }
        //    }
        //}

    }
}
