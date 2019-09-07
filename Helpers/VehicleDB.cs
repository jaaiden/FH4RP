using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using FH4RP.DataStructs;
using Newtonsoft.Json;
using System.Net;

namespace FH4RP.Helpers
{
    public class VehicleDB
    {

        public struct VehicleDBEntry
        {
            public int id;
            public int ordinal;
            public string make;
            public string model;
            public int year;
            public string game;
            [JsonProperty("class")] public string _class;
            public int pi;
            public string drivetrain;
            public int power;
            public int torque;
            public int weight;
            public int weight_percent;
            public int displacement;
            public string description;
            public int added_by;
            public int updated_by;
            public string created_at;
            public string updated_at;
        }

        public static VehicleDB Instance { get; private set; }

        public VehicleDB()
        {
            if (Instance == null) Instance = this;
            else return;
        }

        public Vehicle GetVehicle(int vehicleId)
        {
            Vehicle v = default;
            VehicleDBEntry entry = GetVehicleEntry(vehicleId);
            v.ID = entry.ordinal;
            v.Year = entry.year;
            v.Make = entry.make;
            v.Model = entry.model;
#if DEBUG
            Console.WriteLine($"[{v.ID}] {v.GetVehicleInfo()}");
#endif
            return v;
        }

        private string HttpGet(string uri)
        {
            string retStr = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            try
            {
                using(HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using(Stream stream = response.GetResponseStream())
                using(StreamReader reader = new StreamReader(stream))
                {
                    retStr = reader.ReadToEnd();
                }
            }
            catch (Exception e) { Console.WriteLine($"[API] Exception: {e.ToString()}"); }
            return retStr;
        }

        private VehicleDBEntry GetVehicleEntry(int vehicleId)
        {
            return JsonConvert.DeserializeObject<VehicleDBEntry>(HttpGet("https://forzadb.dgtl.dev/api/vehicles/" + vehicleId));
        }
    }
}
