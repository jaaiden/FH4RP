using System;
using System.Timers;
using FH4RP.Helpers;
using FH4RP.Networking;

namespace FH4RP
{
    class Program
    {
        private static int ServerPort = 9909;
        public static TelemetryServer Server { get; private set; }

        static void Main(string[] args)
        {

            Console.WriteLine("Forza Horizon 4 | Discord Rich Presence App");
            Console.WriteLine("Developed by digital#0001 | https://dgtl.dev");
            Console.WriteLine();
            Console.WriteLine("If you haven't already, open a command prompt as admin");
            Console.WriteLine("and run the following command to allow Forza Horizon 4's");
            Console.WriteLine("Telemetry Data Out to send to the local PC:");
            Console.WriteLine();
            Console.WriteLine("> CheckNetIsolation.exe LoopbackExempt -a -n=Microsoft.SunriseBaseGame_8wekyb3d8bbwe");
            Console.WriteLine();
            Server = new TelemetryServer(ServerPort);
            Server.Start();

            Networking.DiscordRPC.Initialize();

            var timer = new Timer(1250);
            timer.Elapsed += (sender, a) => { Networking.DiscordRPC.SetPresence(Server.LastUpdate); };
            timer.Start();

            // Wait for keypress to close
            Console.Read();
            timer.Stop();
            Networking.DiscordRPC.discordClient.Dispose();
        }
    }
}
