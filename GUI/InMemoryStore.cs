using System.Collections.Generic;
using Core;

namespace GUI
{
    internal class InMemoryStore : IStore
    {
        public InMemoryStore()
        {
            AllCommands = new List<ScanCommmands>();
        }

        public void Save(ScanCommmands scanCommmands)
        {
            if (!AllCommands.Contains(scanCommmands))
            {
                AllCommands.Insert(0, scanCommmands);
            }
        }

        public IList<ScanCommmands> AllCommands { get; private set; }
    }
}