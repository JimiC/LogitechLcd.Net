using System.Drawing;
using System.Reflection;
using System.Threading;
using LogitechLcd.NET;

namespace LcdDemo
{
    internal static class Program
    {
        private static void Main()
        {
            var friendlyName = Assembly.GetEntryAssembly().GetName().Name;

            // Initialize instance
            var lgLcd = LogitechLcd.NET.LogitechLcd.Instance;

            MonochromeDemo(lgLcd, friendlyName);

            // Close
            lgLcd.Shutdown();
        }

        private static void MonochromeDemo(ILogitechLcd lgLcd, string friendlyName)
        {
            // Initialize Mono device
            var init = lgLcd.Init(friendlyName, (int)(LogitechLcdConstants.LogiLcdType.LogiLCDTypeMono));
            if (!init)
                return;

            // Connection check
            var isConnected = lgLcd.IsConnected((int)(LogitechLcdConstants.LogiLcdType.LogiLCDTypeMono));

            // Close if not connected
            if (!isConnected)
                lgLcd.Shutdown();

            // Draw Mono background
            var bitmap = GetMonoBitmap(Properties.Resources.LogiLogoMono);
            lgLcd.MonoSetBackground(bitmap);
            lgLcd.Update();
            Thread.Sleep(2000);

            // Draw Mono inverted background
            bitmap = GetMonoBitmap(Properties.Resources.LogiLogoMonoInverted);
            lgLcd.MonoSetBackground(bitmap);
            lgLcd.Update();
            Thread.Sleep(2000);

            // Clear background
            lgLcd.MonoSetBackground(new byte[0]);
            lgLcd.Update();

            // Draw lines
            var lineNumber = 0;
            while (lineNumber < 4)
            {
                lgLcd.MonoSetText(lineNumber, string.Format("This is line {0}", lineNumber + 1));
                lgLcd.Update();
                Thread.Sleep(1000);
                lineNumber++;
            }
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
    }
}
