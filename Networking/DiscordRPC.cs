using System;
using System.Collections.Generic;
using System.Text;
using DiscordRPC;
using DiscordRPC.Logging;
using FH4RP.DataStructs;
using FH4RP.Helpers;

namespace FH4RP.Networking
{
    public static class DiscordRPC
    {
        public static DiscordRpcClient discordClient;

        public static void Initialize()
        {
            discordClient = new DiscordRpcClient("619736536333811722");
            discordClient.Logger = new ConsoleLogger() { Level = LogLevel.Warning };
            discordClient.OnReady += (sender, e) => { Console.WriteLine($"[Discord] Received ready from {e.User.Username}!"); };
            discordClient.OnPresenceUpdate += (sender, e) => { Console.WriteLine("[Discord] Received presence update!"); };
            discordClient.Initialize();
        }

        public static void SetPresence(TelemetryData data)
        {
            discordClient.SetPresence(new RichPresence()
            {
                Details = VehicleDB.Instance.GetVehicle(data.CarOrdinal).GetVehicleInfo(),
                State = $"[{data.CarClass.ToString()} | {data.CarPI}] - {data.GetMPH()} mph",
                Assets = new Assets()
                {
                    LargeImageKey = "fm"
                }
            });
        }
    }
}
