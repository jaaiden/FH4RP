# Discord Rich Presence for Forza Horizon 4

## What does this do?

This program will allow you to display [Discord Rich Presence](https://discordapp.com/developers/docs/rich-presence/how-to#so-what-is-it) information about your current car, performance index, and speed in Discord.

## How does it work?

Forza Horizon 4 has the ability to send car telemetry data out to a server. This is commonly used for racing simulation devices such as dashboards and hydraulic-powered racing seats. This program uses the same telemetry data to show car information in Discord.

## Can I use this for Forza Horizon 5?

Technically yes, but I recommend using my [other project for it](https://github.com/jaiden-d/FH5RP) as I have some other future plans for it.

## Running the program

---

**Note:** Due to limitations with Universal Windows Platform (UWP) apps, you ***must*** run the following command in an elevated command prompt window (CMD as admin) if you want to run this program on the same machine that you're playing Forza Horizon 4 on!

Make sure Forza Horizon 4 is closed before running this command!

`CheckNetIsolation.exe LoopbackExempt -a -n=Microsoft.SunriseBaseGame_8wekyb3d8bbwe`

---

Steps to configure Rich Presence:

1. Download the [latest release](https://github.com/zackdevine/FH4RP/releases) and extract it somewhere on your desktop.
2. Run the command above (only need to run it once per installation of Forza Horizon 4).
3. In Forza Horizon 4, load into the game world, then go to `Settings > HUD and Gameplay` and scroll down to the bottom.
    - Set `Data Out` to `On`
    - Set `Data Out IP Address` to `127.0.0.1` (or whatever local IP address is running the application)
    - Set `Data Out IP Port` to `9909`
4. Start the application!

You should see some console output in the window that appears. Once you see the message stating that Discord is ready, you're good to go!

## Contributing

The info that shows the vehicle manufacturer and model is pulled from a separate [web API](https://github.com/zackdevine/forzadb) that I created. Recording this data is a very time consuming task, as the only vehicle metadata that Forza returns is a unique ordinal ID for each vehicle. As such, every vehicle needs to be manually entered into the API database to be retrieved from the application.

If you would like to help out (it would mean a lot!), then please feel free to download the debug version of the application and run it to get the ID of the vehicle you're currently using. New vehicles can be submitted at the [ForzaDB](https://forzadb.dgtl.dev) website.

If you would like to contribute to this project, feel free to send PRs with updates!

## References

This project could not have been possible without the Turn 10 community and [Lachee's Discord RPC](https://github.com/Lachee/discord-rpc-csharp) package.

Forza logo from [Forza Horizon 4 Icon Pack - Windows 10 by tfphoenix](https://www.deviantart.com/tfphoenix/art/Forza-Horizon-4-Icon-Pack-Windows-10-767768186) on DeviantArt.
