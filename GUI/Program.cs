using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Core;

namespace GUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormScannerStub(GetStore()));
        }

        private static InMemoryStore GetStore()
        {
            var store = new InMemoryStore();
            store.Save(new ScanCommmands
            {
                DisplayName = "Demo 2014-11-06",
                ProcessName = "SpsScanner",
                TitleStartsWith = "",
                KeysToSend = new List<string>
                {
                    "ART#73010094{ENTER}",
                    "PO#149008{ENTER}",
                    "PO#149009{ENTER}",
                }
            });
            store.Save(new ScanCommmands
            {
                DisplayName = "US1810",
                ProcessName = "chrome",
                TitleStartsWith = "Terminal",
                KeysToSend = new List<string>
                {
                    "ACT#PRINT_NEXT_PRODUCTION_INSTRUCTION{ENTER}",
                    "MA#004-3SLBF4{ENTER}",
                }
            });
            store.Save(new ScanCommmands
            {
                DisplayName = "PR3667",
                ProcessName = "SpsScanner",
                TitleStartsWith = "",
                KeysToSend = new List<string>
                {
                    "PO#149652{ENTER}",
                    "KTL081047{ENTER}",
                }
            });
            return store;
        }
    }
}
