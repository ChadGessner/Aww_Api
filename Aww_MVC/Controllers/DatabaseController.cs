using Aww_MVC.Models;
using AwwDomain;
using AwwDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aww_MVC.Controllers
{
    public class DatabaseController : Controller
    {
        // GET: DatabaseController
        private Interactor _db;
        public DatabaseController()
        {
            _db = new Interactor();
        }
        public ActionResult Index()
        {
            IEnumerable<DbAwwVM> list = _db.GetAllAwwDTs().Select(x => DbAwwVM.GetVMFromDT(x));
            return View(list);
        }

        // GET: DatabaseController/Details/5
        public ActionResult Details(int id)
        {
            DbAwwVM aww = DbAwwVM.GetVMFromDT(_db.GetAwwDTById(id));
            return View(aww);
        }

        // GET: DatabaseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DatabaseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: DatabaseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DatabaseController/Edit/5
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

        // GET: DatabaseController/Delete/5
        public ActionResult Delete(int id)
        {
            AwwDT aww = _db.GetAwwDTById(id);
            return View(aww);
        }

        // POST: DatabaseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if (_db.DeleteAwwDTById(id))
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
