using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models.Entities
{
    public abstract class HistoryItem
    {
        public DateTimeOffset InputDateTime { get; set; }
        public DateTimeOffset ChangeDateTime { get; set; }
        public long Version { get; set; }
    }
}
