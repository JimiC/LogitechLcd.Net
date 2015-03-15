using System;

namespace LogitechLcd.NET
{
    public static class LogitechLcdConstants
    {
        [Flags]
        public enum LogiLcdType
        {
            LogiLCDTypeMono = 1,
            LogiLCDTypeColor = 2,
        }

        [Flags]
        public enum LogiLcdMonoButton
        {
            Button0 = 1,
            Button1 = 2,
            Button2 = 4,
            Button3 = 8
        }

        [Flags]
        public enum LogiLcdColorButton
        {
            ButtonLeft = 256,
            ButtonRight = 512,
            ButtonOk = 1024,
            ButtonCancel = 2048,
            ButtonUp = 4096,
            ButtonDown = 8192,
            ButtonMenu = 16384
        }

        public const int LogiLCDMonoWidth = 160; 
        public const int LogiLCDMonoHeight = 43;

        public const int LogiLCDColorWidth = 320;
        public const int LogiLCDColorHeight = 240;
    }
}
