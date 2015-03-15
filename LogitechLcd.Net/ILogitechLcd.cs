namespace LogitechLcd.NET
{
    public interface ILogitechLcd
    {
        bool Init(string friendlyName, int lcdType);

        bool IsConnected(int lcdType);

        bool IsButtonPressed(int button); 

        bool Update();

        void Shutdown();

        bool MonoSetBackground(byte[] bitmap);

        bool MonoSetText(int lineNumber, string text);

        bool ColorSetBackground(byte[] bitmap);

        bool ColorSetTitle(string text, int red, int green, int blue);

        bool ColorSetText(int lineNumber, string text, int red, int green, int blue);
    }
}
