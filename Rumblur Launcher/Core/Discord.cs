﻿using DiscordRPC;
using log4net;
using System.Threading;

namespace Rumblur_Launcher.Core
{
    class Discord
    {
        #region Singleton

        private static Discord instance;
        public static Discord App
        {
            get
            {
                if (instance == null)
                    instance = new Discord();
                return instance;
            }
        }

        private Discord() { }
        #endregion

        private DiscordRpcClient client;
        private const string CLIENT_ID = "786634838244720660";
        Thread InvokeThread;
        bool IsWorking = false;

        private static ILog log = LogManager.GetLogger("Discord");

        public RichPresence Presence { get; private set; }

        public void Initialize()
        {
            log.Info("Initializing Discord Rich Presence : " + CLIENT_ID);

            client = new DiscordRpcClient(CLIENT_ID);
            client.Logger = new DiscordRPC.Logging.NullLogger();

            client.OnReady += Client_OnReady;
            client.OnPresenceUpdate += Client_OnPresenceUpdate;

            log.Info("Initializing Client");
            client.Initialize();

            Presence = new RichPresence();
            Presence.Assets = new Assets()
            {
                LargeImageKey = "chainfire",
                LargeImageText = "Rumblur Classic"
            };

            IsWorking = true;
            InvokeThread = new Thread(Invoking);
            log.Info("Starting invoking thread");
            InvokeThread.Start();
        }

        public void DeInitialize()
        {
            IsWorking = false;
            InvokeThread.Abort();
            client.Dispose();

            log.Info("DeInitialized");
        }

        private void Invoking()
        {
            while (IsWorking)
            {
                Thread.Sleep(150);

                client.SetPresence(Presence.Clone());
                client.Invoke();
            }
        }

        private void Client_OnPresenceUpdate(object sender, DiscordRPC.Message.PresenceMessage args)
        {

        }

        private void Client_OnReady(object sender, DiscordRPC.Message.ReadyMessage args)
        {

        }
    }
}
