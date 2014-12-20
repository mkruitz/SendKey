using System.Collections.Generic;
using System.Linq;
using Core;

namespace GUI
{
    public class InMemoryStore : IStore
    {
        public InMemoryStore()
        {
            Reset();
        }

        public void Save(ScanCommmands scanCommmands)
        {
            if (!AllCommands.Contains(scanCommmands))
            {
                AllCommands.Insert(0, scanCommmands);
            }
        }

        public IList<ScanCommmands> AllCommands { get; private set; }
        
        public bool Exists()
        {
            return AllCommands.Any();
        }

        public void Reset()
        {
            AllCommands = new List<ScanCommmands>();
        }
    }
}