using System.Runtime.InteropServices;
using System.Text;

namespace LogitechLcd.NET
{
    internal sealed class LogitechLcdx64 : ILogitechLcd
    {
        [DllImport("LogitechLcd.x64.dll", EntryPoint = "LogiLcdInit", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        private static extern bool LogiLcdInit(string friendlyName, int lcdType);

        bool ILogitechLcd.Init(string friendlyName, int lcdType)
        {
            friendlyName = Encoding.UTF8.GetString(Encoding.Unicode.GetBytes(friendlyName));
            return LogiLcdInit(friendlyName, lcdType);
        }

        [DllImport("LogitechLcd.x64.dll", EntryPoint = "LogiLcdIsConnected", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        private static extern bool LogiLcdIsConnected(int lcdType);

        bool ILogitechLcd.IsConnected(int lcdType)
        {
            return LogiLcdIsConnected(lcdType);
        }

        [DllImport("LogitechLcd.x64.dll", EntryPoint = "LogiLcdIsButtonPressed", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        private static extern bool LogiLcdIsButtonPressed(int button);

        bool ILogitechLcd.IsButtonPressed(int button)
        {
            return LogiLcdIsButtonPressed(button);
        }

        [DllImport("LogitechLcd.x64.dll", EntryPoint = "LogiLcdUpdate", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        private static extern bool LogiLcdUpdate();

        bool ILogitechLcd.Update()
        {
            return LogiLcdUpdate();
        }

        [DllImport("LogitechLcd.x64.dll", EntryPoint = "LogiLcdShutdown", CallingConvention = CallingConvention.Cdecl)]
        private static extern void LogiLcdShutdown();

        void ILogitechLcd.Shutdown()
        {
            LogiLcdShutdown();
        }

        [DllImport("LogitechLcd.x64.dll", EntryPoint = "LogiLcdMonoSetBackground", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        private static extern bool LogiLcdMonoSetBackground(byte[] bitmap);

        public bool MonoSetBackground(byte[] bitmap)
        {
            return LogiLcdMonoSetBackground(bitmap);
        }

        [DllImport("LogitechLcd.x64.dll", EntryPoint = "LogiLcdMonoSetText", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        private static extern bool LogiLcdMonoSetText(int lineNumber, string text);

        public bool MonoSetText(int lineNumber, string text)
        {
            text = Encoding.UTF8.GetString(Encoding.Unicode.GetBytes(text));
            return LogiLcdMonoSetText(lineNumber, text);
        }

        [DllImport("LogitechLcd.x64.dll", EntryPoint = "LogiLcdColorSetBackground", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        private static extern bool LogiLcdColorSetBackground(byte[] bitmap);

        public bool ColorSetBackground(byte[] bitmap)
        {
            return LogiLcdColorSetBackground(bitmap);
        }

        [DllImport("LogitechLcd.x64.dll", EntryPoint = "LogiLcdColorSetTitle", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        private static extern bool LogiLcdColorSetTitle(string text, int red, int green, int blue);

        public bool ColorSetTitle(string text, int red, int green, int blue)
        {
            text = Encoding.UTF8.GetString(Encoding.Unicode.GetBytes(text));
            return LogiLcdColorSetTitle(text, red, green, blue);
        }

        [DllImport("LogitechLcd.x64.dll", EntryPoint = "LogiLcdColorSetText", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        private static extern bool LogiLcdColorSetText(int lineNumber, string text, int red, int green, int blue);

        public bool ColorSetText(int lineNumber, string text, int red, int green, int blue)
        {
            text = Encoding.UTF8.GetString(Encoding.Unicode.GetBytes(text));
            return LogiLcdColorSetText(lineNumber, text, red, green, blue);
        }
    }
}
