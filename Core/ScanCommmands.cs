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

        private String getKeysToSendAsString()
        {
            return String.Join("#", KeysToSend);
        }

        public override bool Equals(object o)
        {
            var other = o as ScanCommmands;
            if (other == null)
                return base.Equals(o);

            return DisplayName == other.DisplayName
                && ProcessName == other.ProcessName
                && TitleStartsWith == other.TitleStartsWith
                && getKeysToSendAsString() == other.getKeysToSendAsString();
        }

        public override int GetHashCode()
        {
            return
                String.Format("{0}/{1}/{2}/{3}", DisplayName, ProcessName, TitleStartsWith, getKeysToSendAsString())
                    .GetHashCode();
        }
    }
}
