using System;
using System.Collections.Generic;
using System.Text;

namespace FH4RP.DataStructs
{
    public struct Vehicle
    {

        public enum DrivetrainType
        {
            FWD = 0,
            RWD = 1,
            AWD = 2
        }

        public enum CarClass
        {
            D = 0,
            C = 1,
            B = 2,
            A = 3,
            S1 = 4,
            S2 = 5,
            X = 6
        }

        public int ID { get; set; }

        /// <summary>
        /// Vehicle Manufacturer
        /// </summary>
        public string Make { get; set; }

        /// <summary>
        /// Vehicle Model
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Vehicle Year
        /// </summary>
        public int Year { get; set; }

        public string GetVehicleInfo ()
        {
            return $"{(Year == 0 ? 2019 : Year)} {(Make == "" ? "Unknown" : Make)} {(Model == "" ? "Unknown" : Model)}";
        }
    }
}
