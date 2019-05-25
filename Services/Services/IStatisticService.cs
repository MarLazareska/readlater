using ReadLater.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadLater.Services
{
    public interface IStatisticService
    {
        List<Bookmark> GetMostClickedBookmarks(string userId);
        List<Bookmark> GetMostClickedBookmarksByCategory(string userId, int category);
    }
}
