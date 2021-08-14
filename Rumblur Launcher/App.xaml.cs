using log4net;
using Rumblur_Launcher.Core;
using Rumblur_Launcher.UI;
using System;
using System.Windows;

namespace Rumblur_Launcher
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static ILog log = LogManager.GetLogger("App");
        private static DateTime StartTime = DateTime.UtcNow;
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            log4net.Config.XmlConfigurator.Configure();

            log.Info(" ### Starting Rumblur Launcher ###");
            log.Info("Launcher Version : " + Launcher.LauncherVersion);

            log.Info("Start Discord RPC");
            Discord.App.Initialize();
            SetDiscordIdleStatus();

            log.Info("Start LoginWindow");
            var loginWindow = new LoginWindow();
            loginWindow.Show();
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            log.Error("UnhandledException. IsTerm : " + e.IsTerminating, (Exception)e.ExceptionObject);
        }

        public static void Stop()
        {
            Discord.App.DeInitialize();

            log.Info("Stopping Program");
            Environment.Exit(0);
        }

        public static void SetDiscordIdleStatus()
        {
            Discord.App.Presence.Details = "";
            Discord.App.Presence.Timestamps = new DiscordRPC.Timestamps
            {
                Start = StartTime,
                End = null
            };
        }
    }
}
