using Microsoft.AspNet.Identity;
using ReadLater.Entities;
using ReadLater.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        IStatisticService _statisticService;
        IBookmarkService _bookmarkService;
        ICategoryService _categoryService;

        public Bookmark Bookmark { get; set; } = new Bookmark();

        public DashboardController(IStatisticService statisticService,
                                   IBookmarkService bookmarkService,
                                   ICategoryService categoryService)
        {
            _statisticService = statisticService;
            _bookmarkService = bookmarkService;
            _categoryService = categoryService;
        }

        // GET: Dashboard
        public ActionResult Index()
        {
            List<Bookmark> model = _statisticService.GetMostClickedBookmarks(User.Identity.GetUserId());
            return View(model);
        }

        public JsonResult GetCategories()
        {
            var categories = _categoryService.GetCategoriesByUser(User.Identity.GetUserId());
            return Json(categories, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetBookmarksByCategory(int category)
        {
            var bookmarks = _statisticService.GetMostClickedBookmarksByCategory(User.Identity.GetUserId(), category);
            return PartialView("_ListBookmarks", bookmarks);
        }

        public ActionResult OpenUrl(int id, string url)
        {
            Bookmark = _bookmarkService.GetBookmark(id);
            Bookmark.NumberOfClicks += 1;
            _bookmarkService.UpdateBookmark(Bookmark);
            return Redirect(url);
        }

    }
}
