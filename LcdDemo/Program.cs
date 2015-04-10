using LogitechLcd.NET;
using System;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Timers;

namespace LcdDemo
{
    internal static class Program
    {
        private static System.Timers.Timer s_timer;
        private static ILogitechLcd s_lgLcd;

        private static void Main()
        {
            if (!Initialize())
                return;

            ShowBitmap();

            ShowText();

            SetTimer();

            while (s_lgLcd.IsConnected((int)(LogitechLcdConstants.LogiLcdType.LogiLCDTypeMono)))
            {
            }
        }

        private static bool Initialize()
        {
            // Set friendly name
            string friendlyName = Assembly.GetEntryAssembly().GetName().Name;

            // Initialize instance
            s_lgLcd = LogitechLcd.NET.LogitechLcd.Instance;

            // Initialize Mono device
            var init = s_lgLcd.Init(friendlyName, (int)(LogitechLcdConstants.LogiLcdType.LogiLCDTypeMono));
            if (!init)
                return false;

            // Connection check
            var isConnected = s_lgLcd.IsConnected((int)(LogitechLcdConstants.LogiLcdType.LogiLCDTypeMono));

            // Return if connected
            if (isConnected)
                return true;

            // Close if not connected
            s_lgLcd.Shutdown();
            return false;
        }

        private static void SetTimer()
        {
            s_timer = new System.Timers.Timer { Interval = 300 };
            s_timer.Elapsed += TimerOnElapsed;
            s_timer.Start();
        }

        private static void ShowBitmap()
        {
            // Draw Mono background
            var bitmap = GetMonoBitmap(Properties.Resources.LogiLogoMono);
            s_lgLcd.MonoSetBackground(bitmap);
            s_lgLcd.Update();
            Thread.Sleep(2000);

            // Draw Mono inverted background
            bitmap = GetMonoBitmap(Properties.Resources.LogiLogoMonoInverted);
            s_lgLcd.MonoSetBackground(bitmap);
            s_lgLcd.Update();
            Thread.Sleep(2000);

            // Clear background
            s_lgLcd.MonoSetBackground(new byte[0]);
            s_lgLcd.Update();
        }

        private static byte[] GetMonoBitmap(Bitmap img)
        {
            int pos = 0;
            byte[] bitmapMono = new byte[LogitechLcdConstants.LogiLCDMonoWidth * LogitechLcdConstants.LogiLCDMonoHeight];
            for (int y = 0; y < LogitechLcdConstants.LogiLCDMonoHeight; y++)
            {
                for (int x = 0; x < LogitechLcdConstants.LogiLCDMonoWidth; x++)
                {
                    // Get the blue pixel inverted
                    bitmapMono[pos] = (byte)(255 >> img.GetPixel(x, y).B);
                    pos++;
                }
            }

            return bitmapMono;
        }

        private static void ShowText()
        {
            // Draw lines
            var lineNumber = 0;
            while (lineNumber < 4)
            {
                s_lgLcd.MonoSetText(lineNumber, string.Format("This is line {0}", lineNumber + 1));
                s_lgLcd.Update();
                Thread.Sleep(1000);
                lineNumber++;
            }

            ClearAllText();
        }

        private static void ClearAllText()
        {
            // Clear lines
            var lineNumber = 0;
            while (lineNumber < 4)
            {
                s_lgLcd.MonoSetText(lineNumber, string.Empty);
                lineNumber++;
            }
            s_lgLcd.Update();
        }

        private static void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            // Button0 is pressed
            if (s_lgLcd.IsButtonPressed((int)LogitechLcdConstants.LogiLcdMonoButton.Button0))
            {
                ShowButtonText(LogitechLcdConstants.LogiLcdMonoButton.Button0);
                return;
            }

            // Button1 is pressed
            if (s_lgLcd.IsButtonPressed((int)LogitechLcdConstants.LogiLcdMonoButton.Button1))
            {
                ShowButtonText(LogitechLcdConstants.LogiLcdMonoButton.Button1);
                return;
            }

            // Button2 is pressed
            if (s_lgLcd.IsButtonPressed((int)LogitechLcdConstants.LogiLcdMonoButton.Button2))
            {
                ShowButtonText(LogitechLcdConstants.LogiLcdMonoButton.Button2);
                return;
            }

            // Button3 is pressed
            if (s_lgLcd.IsButtonPressed((int)LogitechLcdConstants.LogiLcdMonoButton.Button3))
            {
                ShowButtonText(LogitechLcdConstants.LogiLcdMonoButton.Button3);
                return;
            }

            ClearAllText();

            ShowPressAnyButton();
        }

        private static void ShowButtonText(LogitechLcdConstants.LogiLcdMonoButton button)
        {
            ClearAllText();

            var lineNumber = Convert.ToInt32(button.ToString().Replace("Button", string.Empty));
            s_lgLcd.MonoSetText(lineNumber, string.Format("You pressed {0}", button));
            s_lgLcd.Update();
        }

        private static void ShowPressAnyButton()
        {
            s_lgLcd.MonoSetText(0, "Press Any Button");
            s_lgLcd.Update();
        }
    }
}
