using Microsoft.AspNet.Identity;
using MVC.Models;
using ReadLater.Entities;
using ReadLater.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    [Authorize]
    public class BookmarksController : Controller
    {
        IBookmarkService _bookmarkService;
        ICategoryService _categoryService;

        public Bookmark Bookmark { get; set; } = new Bookmark();

        public BookmarksController(IBookmarkService bookmarkService, ICategoryService categoryService)
        {
            _bookmarkService = bookmarkService;
            _categoryService = categoryService;
        }

        // GET: Bookmarks
        public ActionResult Index()
        {
            List<Bookmark> model = _bookmarkService.GetBookmarksByUser(User.Identity.GetUserId());
            return View(model);
        }

        // GET: Bookmarks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bookmark= _bookmarkService.GetBookmark((int)id);
            if (Bookmark == null)
            {
                return HttpNotFound();
            }
            return View(Bookmark);
        }

        // GET: Bookmarks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bookmarks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookmarksViewModel model, int? categorySelected)
        {
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                {
                    Bookmark = new Bookmark();
                    Bookmark.UserId = User.Identity.GetUserId();
                    Bookmark.ShortDescription = model.ShortDescription;
                    Bookmark.URL = model.URL;
                    Bookmark.CreateDate = model.CreatedDate;
                    Bookmark.CategoryId = categorySelected;
                    _bookmarkService.CreateBookmark(Bookmark);

                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        // GET: Bookmarks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bookmark = _bookmarkService.GetBookmark((int)id);
            EditBookmarkViewModel model = new EditBookmarkViewModel();
            model.ID = Bookmark.ID;
            model.Categories = _categoryService.GetCategoriesByUser(User.Identity.GetUserId());
            model.CreatedDate = Bookmark.CreateDate;
            model.ShortDescription = Bookmark.ShortDescription;
            model.URL = Bookmark.URL;
            model.SelectedCategory = Bookmark.CategoryId;
            if (Bookmark == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Bookmarks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditBookmarkViewModel model, int? categorySelected)
        {
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                {
                    Bookmark = _bookmarkService.GetBookmark(model.ID);
                    Bookmark.ShortDescription = model.ShortDescription;
                    Bookmark.URL = model.ShortDescription;
                    Bookmark.CreateDate = model.CreatedDate;
                    Bookmark.CategoryId = categorySelected;
                    _bookmarkService.UpdateBookmark(Bookmark);

                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        // GET: Bookmarks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           Bookmark = _bookmarkService.GetBookmark((int)id);
            if (Bookmark == null)
            {
                return HttpNotFound();
            }
            return View(Bookmark);
        }

        // POST: Bookmarks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bookmark = _bookmarkService.GetBookmark(id);
            _bookmarkService.DeleteBookmark(Bookmark);
            return RedirectToAction("Index");
        }

        public JsonResult GetCategories()
        {
            var categories = _categoryService.GetCategoriesByUser(User.Identity.GetUserId());
            return Json(categories, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddCategory(string category)
        {
            _categoryService.CreateCategory(new Category { Name = category, UserId = User.Identity.GetUserId() });
            var categories = _categoryService.GetCategoriesByUser(User.Identity.GetUserId());
            return Json(categories, JsonRequestBehavior.AllowGet);
        }

        public ActionResult OpenUrl(int id, string url)
        {
            Bookmark=_bookmarkService.GetBookmark(id);
            Bookmark.NumberOfClicks += 1;
            _bookmarkService.UpdateBookmark(Bookmark);
            return  Redirect(url);
        }
    }
}
