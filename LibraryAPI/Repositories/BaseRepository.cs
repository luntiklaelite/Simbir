using LibraryAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Repositories
{
    public abstract class BaseRepository
    {
        public void SetInputDate(params HistoryItem[] items)
        {
            foreach (var item in items)
            {
                item.InputDateTime = DateTimeOffset.Now;
                UpdateDateAndVersion(item);
            }
        }

        public void UpdateDateAndVersion(params HistoryItem[] items)
        {
            foreach (var item in items)
            {
                item.ChangeDateTime = DateTimeOffset.Now;
                item.Version++;
            }
        }
    }
}
