using System;
using System.Reflection;

namespace Rumblur_Launcher
{
    class Launcher
    {
        public static readonly string
            LauncherName = "Rumblur Launcher",
            LauncherVersion = Assembly.GetEntryAssembly().GetName().Version.ToString(),

            LauncherPath = Environment.CurrentDirectory,
            GamePath = LauncherPath + "\\games\\",
            JavaPath = LauncherPath + "\\runtime",
            SettingPath = LauncherPath + "\\launcher\\launchersetting.json",
            LisencePath = LauncherPath + "\\license.txt",
            UpdaterPath = LauncherPath + "\\updater.exe",
            SecurityPath = LauncherPath + "\\launcher\\user.dat",

            ModPackListUrl = "https://api.mysticrs.tk/list",
            ModPackDataUrl = "https://api.mysticrs.tk/modpack",
            WhiteListUrl = "https://api.mysticrs.tk/whitelist",
    }
}
