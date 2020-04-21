using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace FH4RP.DataStructs
{
    public class AppConfig
    {
        private const string FILENAME = "config.json";

        public int ServerPort { get; set; }
        public bool UseKMH { get; set; }

        public static bool Exists()
        {
            return File.Exists(FILENAME);
        }

        public static AppConfig Load()
        {
            return Exists()
                ? JsonConvert.DeserializeObject<AppConfig>(File.ReadAllText(FILENAME))
                : Default();
        }

        public static void Save(AppConfig cfg)
        {
            File.WriteAllText(FILENAME, JsonConvert.SerializeObject(cfg));
        }

        private static AppConfig Default()
        {
            AppConfig cfg = new AppConfig()
            {
                ServerPort = 9909,
                UseKMH = false
            };
            Save(cfg);
            Console.WriteLine($"No configuration file ({FILENAME}) was found.\nA new one has been created with the default options set.");
            return cfg;
        }
    }
}
