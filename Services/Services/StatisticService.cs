using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadLater.Entities;
using ReadLater.Repository;

namespace ReadLater.Services
{
    public class StatisticService : IStatisticService
    {
        protected IUnitOfWork _unitOfWork;

        public StatisticService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Bookmark> GetMostClickedBookmarks(string userId)
        {
            return _unitOfWork.Repository<Bookmark>().Query()
                                                      .Filter(c => c.UserId == userId)
                                                      .Get()
                                                      .OrderByDescending(c => c.NumberOfClicks)
                                                      .Take(5)
                                                      .ToList();
        }

        public List<Bookmark> GetMostClickedBookmarksByCategory(string userId, int category)
        {
            return _unitOfWork.Repository<Bookmark>().Query()
                                                      .Filter(c => c.UserId == userId && c.CategoryId == category)
                                                      .Get()
                                                      .OrderByDescending(c => c.NumberOfClicks)
                                                      .Take(5)
                                                      .ToList();
        }
    }
}
