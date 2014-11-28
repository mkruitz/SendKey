using System.Collections.Generic;

namespace Core
{
    public interface IStore
    {
        void Save(ScanCommmands scanCommmands);
        IList<ScanCommmands> AllCommands { get; }
    }
}