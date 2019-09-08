using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using FH4RP.DataStructs;
using FH4RP.Helpers;

namespace FH4RP.Networking
{
    public class TelemetryServer
    {
        private UdpClient udpClient;
        private IPEndPoint ep;
        public TelemetryData LastUpdate { get; private set; }

        public TelemetryServer(int port = 9909)
        {
            try
            {
                ep = new IPEndPoint(IPAddress.Loopback, port);
                udpClient = new UdpClient(ep);
                udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            }
            catch (Exception e) { Console.WriteLine($"Error: {e.ToString()}"); }
            new VehicleDB();
        }

        public void Start()
        {
            Console.WriteLine($"Started telemetry server on {ep.Address.ToString()}:{ep.Port}.");
            udpClient.BeginReceive(new AsyncCallback(OnUdpReceive), null);
        }

        private void OnUdpReceive(IAsyncResult ar)
        {
            byte[] data = udpClient.EndReceive(ar, ref ep);
            TelemetryData telemetryData = CreateDataStruct(data);
            if (telemetryData.CarOrdinal != 0) LastUpdate = telemetryData;
#if DEBUG
            // System.IO.File.WriteAllText("output.json", Newtonsoft.Json.JsonConvert.SerializeObject(LastUpdate, Newtonsoft.Json.Formatting.Indented));
#endif
            udpClient.BeginReceive(new AsyncCallback(OnUdpReceive), null);
        }

        private TelemetryData CreateDataStruct(byte[] data)
        {
            return new TelemetryData
            {
                IsRaceOn = BitConverter.ToInt32(data, 0),
                TimestampMS = BitConverter.ToUInt32(data, 4),

                EngineMaxRPM = BitConverter.ToSingle(data, 8),
                EngineIdleRPM = BitConverter.ToSingle(data, 12),
                EngineCurrentRPM = BitConverter.ToSingle(data, 16),

                AccelerationX = BitConverter.ToSingle(data, 20),
                AccelerationY = BitConverter.ToSingle(data, 24),
                AccelerationZ = BitConverter.ToSingle(data, 28),

                VelocityX = BitConverter.ToSingle(data, 32),
                VelocityY = BitConverter.ToSingle(data, 36),
                VelocityZ = BitConverter.ToSingle(data, 40),

                AngularVelocityX = BitConverter.ToSingle(data, 44),
                AngularVelocityY = BitConverter.ToSingle(data, 48),
                AngularVelocityZ = BitConverter.ToSingle(data, 52),

                Yaw = BitConverter.ToSingle(data, 56),
                Pitch = BitConverter.ToSingle(data, 60),
                Roll = BitConverter.ToSingle(data, 64),

                NormalizedSuspensionTravelFrontLeft = BitConverter.ToSingle(data, 68),
                NormalizedSuspensionTravelFrontRight = BitConverter.ToSingle(data, 72),
                NormalizedSuspensionTravelRearLeft = BitConverter.ToSingle(data, 76),
                NormalizedSuspensionTravelRearRight = BitConverter.ToSingle(data, 80),

                TireSlipRatioFrontLeft = BitConverter.ToSingle(data, 84),
                TireSlipRatioFrontRight = BitConverter.ToSingle(data, 88),
                TireSlipRatioRearLeft = BitConverter.ToSingle(data, 92),
                TireSlipRatioRearRight = BitConverter.ToSingle(data, 96),

                WheelRotationSpeedFrontLeft = BitConverter.ToSingle(data, 100),
                WheelRotationSpeedFrontRight = BitConverter.ToSingle(data, 104),
                WheelRotationSpeedRearLeft = BitConverter.ToSingle(data, 108),
                WheelRotationSpeedRearRight = BitConverter.ToSingle(data, 112),

                WheelOnRumbleStripFrontLeft = BitConverter.ToInt32(data, 116),
                WheelOnRumbleStripFrontRight = BitConverter.ToInt32(data, 120),
                WheelOnRumbleStripRearLeft = BitConverter.ToInt32(data, 124),
                WheelOnRumbleStripRearRight = BitConverter.ToInt32(data, 128),

                WheelInPuddleDepthFrontLeft = BitConverter.ToSingle(data, 132),
                WheelInPuddleDepthFrontRight = BitConverter.ToSingle(data, 136),
                WheelInPuddleDepthRearLeft = BitConverter.ToSingle(data, 140),
                WheelInPuddleDepthRearRight = BitConverter.ToSingle(data, 144),

                SurfaceRumbleFrontLeft = BitConverter.ToSingle(data, 148),
                SurfaceRumbleFrontRight = BitConverter.ToSingle(data, 152),
                SurfaceRumbleRearLeft = BitConverter.ToSingle(data, 156),
                SurfaceRumbleRearRight = BitConverter.ToSingle(data, 160),

                TireSlipAngleFrontLeft = BitConverter.ToSingle(data, 164),
                TireSlipAngleFrontRight = BitConverter.ToSingle(data, 168),
                TireSlipAngleRearLeft = BitConverter.ToSingle(data, 172),
                TireSlipAngleRearRight = BitConverter.ToSingle(data, 176),

                TireCombinedSlipFrontLeft = BitConverter.ToSingle(data, 180),
                TireCombinedSlipFrontRight = BitConverter.ToSingle(data, 184),
                TireCombinedSlipRearLeft = BitConverter.ToSingle(data, 188),
                TireCombinedSlipRearRight = BitConverter.ToSingle(data, 192),

                SuspensionTravelFrontLeft = BitConverter.ToSingle(data, 196),
                SuspensionTravelFrontRight = BitConverter.ToSingle(data, 200),
                SuspensionTravelRearLeft = BitConverter.ToSingle(data, 204),
                SuspensionTravelRearRight = BitConverter.ToSingle(data, 208),

                CarOrdinal = BitConverter.ToInt32(data, 212),

                CarClass = (Vehicle.CarClass)BitConverter.ToInt32(data, 216),
                CarPI = BitConverter.ToInt32(data, 220),
                DrivetrainType = (Vehicle.DrivetrainType)BitConverter.ToInt32(data, 224),
                NumCylinders = BitConverter.ToInt32(data, 228),

                PositionX = BitConverter.ToSingle(data, 232),
                PositionY = BitConverter.ToSingle(data, 236),
                PositionZ = BitConverter.ToSingle(data, 240),

                Speed = BitConverter.ToSingle(data, 244),
                Power = BitConverter.ToSingle(data, 248),
                Torque = BitConverter.ToSingle(data, 252),

                TireTempFrontLeft = BitConverter.ToSingle(data, 256),
                TireTempFrontRight = BitConverter.ToSingle(data, 260),
                TireTempRearLeft = BitConverter.ToSingle(data, 264),
                TireTempRearRight = BitConverter.ToSingle(data, 268),

                Boost = BitConverter.ToSingle(data, 272),
                Fuel = BitConverter.ToSingle(data, 276),
                DistanceTraveled = BitConverter.ToSingle(data, 280),

                BestLap = BitConverter.ToSingle(data, 284),
                LastLap = BitConverter.ToSingle(data, 288),
                CurrentLap = BitConverter.ToSingle(data, 292),
                CurrentRaceTime = BitConverter.ToSingle(data, 296),
                LapNumber = BitConverter.ToUInt16(data, 300),

                RacePosition = data[302],
                Accel = data[303],
                Brake = data[304],
                Clutch = data[305],
                Handbrake = data[306],
                Gear = data[307],
                Steer = (sbyte)data[308],
                NormalizedDrivingLine = (sbyte)data[309],
                NormalizedAIBrakeDifference = (sbyte)data[310]
            };
        }
    }
}
