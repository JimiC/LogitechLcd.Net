using System;

namespace LogitechLcd.NET
{
    public static class LogitechLcd
    {
        private static readonly ILogitechLcd s_lgLcd;

        static LogitechLcd()
        {
            if (Environment.Is64BitProcess)
                s_lgLcd = new LogitechLcdx64();
            else
                s_lgLcd = new LogitechLcdx86();
        }

        public static ILogitechLcd Instance
        {
            get { return s_lgLcd; }
        }
    }
}
