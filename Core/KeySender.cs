using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Core;

namespace Core
{
    public class KeySender
    {
        private readonly ScanCommmands _command;

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        public KeySender(ScanCommmands command)
        {
            _command = command;
        }

        public void Send(String stringToSend)
        {
            var process = TryFindProcess();
            if (process == null)
                return;
            
            SendKeysToApplication(process, stringToSend);
        }

        private Process TryFindProcess()
        {
            if (_command == null)
                return null;
            return Process.GetProcessesByName(_command.ProcessName)
                .FirstOrDefault(p => p.MainWindowTitle.StartsWith(_command.TitleStartsWith));
        }

        private void SendKeysToApplication(Process process, string stringToSend)
        {
            SetForegroundWindow(process.MainWindowHandle);
            SendKeys.Send(stringToSend);
            SendKeys.Flush();
        }
    }
}