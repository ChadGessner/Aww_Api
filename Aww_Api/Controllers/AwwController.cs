using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Aww_Api_Fetch;
using Aww_Api.Models;

namespace Aww_Api.Controllers
{
    public class AwwController : Controller
    {
        private ApiHandler api;
        public AwwController()
        {
            this.api = new ApiHandler();
        }
        // GET: AwwController
        public ActionResult Index()
        {
            //IEnumerable<ImageViewModel> images = api.Orchestrate().Select(j => new ImageViewModel() { ImageUrl = (string)j});
            return View();
        }

        // GET: AwwController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AwwController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AwwController/Create
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

        // GET: AwwController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AwwController/Edit/5
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

        // GET: AwwController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AwwController/Delete/5
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
        #region for api calls
        [HttpGet]
        public ActionResult Get(int id)
        {
            return View();
        }



        #endregion
    }
}
