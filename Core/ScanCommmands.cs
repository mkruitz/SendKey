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

        private String GetKeysToSendAsString()
        {
            return String.Join("#", KeysToSend);
        }

        public override bool Equals(object o)
        {
            var other = o as ScanCommmands;
            if (other == null)
                return false;

            return DisplayName == other.DisplayName
                && ProcessName == other.ProcessName
                && TitleStartsWith == other.TitleStartsWith
                && GetKeysToSendAsString() == other.GetKeysToSendAsString();
        }

        public override int GetHashCode()
        {
            return
                String.Format("{0}/{1}/{2}/{3}", DisplayName, ProcessName, TitleStartsWith, GetKeysToSendAsString())
                    .GetHashCode();
        }
    }
}
