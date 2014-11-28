using System;
using System.Collections.Generic;

namespace Core
{
    public class ScanCommmands
    {
        public ScanCommmands()
        {
            KeysToSend = new List<string>();
        }

        public String DisplayName { get; set; }
        public String ProcessName { get; set; }
        public String TitleStartsWith { get; set; }
        public List<String> KeysToSend { get; set; }
    }
}
