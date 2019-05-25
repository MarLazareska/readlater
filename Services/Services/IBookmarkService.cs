using System;
using System.Collections.Generic;
using ReadLater.Entities;

namespace ReadLater.Services
{
    public interface IBookmarkService
    {
        Bookmark CreateBookmark(Bookmark bookmark);
        List<Bookmark> GetBookmarks(string category);
        void UpdateBookmark(Bookmark bookmark);
        List<Bookmark> GetBookmarks();
        Bookmark GetBookmark(DateTime CreatedDate);
        void DeleteBookmark(Bookmark bookmark);
        Bookmark GetBookmark(int Id);
        List<Bookmark> GetBookmarksByUser(string userId);
    }
}