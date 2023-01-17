using AwwDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AwwDomain;
using Aww_MVC.Models;

namespace Aww_MVC.Controllers
{
    public class CategoryController : Controller
    {
        // GET: CategoryController
        private Interactor _db;
        public CategoryController()
        {
            _db = new Interactor();
        }
        public ActionResult Index()
        {
            return View(_db.GetAllCategories().Select(c=>CategoryVM.GetVMFromDT(c)));
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        
        // GET: CategoryController/Create
        public ActionResult Create()
        {
            
            return View(new CategoryVM());
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            AwwCategoryDT cat = CategoryVM.GetDTFromCollection(collection);
            if (_db.AddCategoryToDb(cat))
            {
                return RedirectToAction(nameof(Index));
            }
            return View(cat);
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
