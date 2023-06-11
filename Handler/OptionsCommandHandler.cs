using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace VoiceAssistent.Handler
{
    public class OptionsCommandHandler
    {
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private static OptionsCommandHandler instance = null;
        private static readonly object padlock = new object();

        bool iswindowShown = true;
        OptionsCommandHandler() { }

        public static OptionsCommandHandler Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new OptionsCommandHandler();
                        }
                    }
                }
                return instance;
            }
        }
        public bool SwitchWindowMode()
        {
            if (iswindowShown)
            {
                HideWindow();
            }
            else if (!iswindowShown)
            {
                ShowWindow();
            }
            return iswindowShown;
        }

        private void ShowWindow()
        {
            IntPtr h = Process.GetCurrentProcess().MainWindowHandle;
            ShowWindow(h, 1);
            iswindowShown = true;
        }
        private void HideWindow()
        {
            IntPtr h = Process.GetCurrentProcess().MainWindowHandle;
            HideWindow();
            iswindowShown = false;
        }

        public bool SwitchLogMode()
        {
            LogHandler log = LogHandler.Instance;
            if (log.OpenLog)
            {
                log.OpenLog = false;

            }
            else if (!log.OpenLog)
            {
                log.OpenLog = true;

            }
            return log.OpenLog;
        }

    }
}