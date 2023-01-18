using Aww_Api_Fetch;
using Aww_MVC.Models;
using AwwDomain;
using AwwDTO;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace Aww_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApiHandler _handle;
        private Interactor _db;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _handle = new ApiHandler();
            _db = new Interactor();
        }
        public IActionResult Index()
        {
            APIIndexVM vm = new APIIndexVM()
            {
                URL = @"http://reddit.com/r/aww/.json",
            };
            
            vm.ModelList = APIFetchVM
                .GetVMFromDictionary(_db.ServeApiResults(vm.URL));
            return View(vm);
        }
        public IActionResult IndexPOST(APIIndexVM vm)
        {
            _db.AddUrl(APIIndexVM.GetDTOFromVM(vm));
            string url = _db
                .GetLastUrl().Url;
            vm.ModelList = APIFetchVM
                .GetVMFromDictionary(_db.ServeApiResults(url));
            return View(vm);
        }
        public IActionResult Create(string fancyId, string URL)
        {
            int id = int.Parse(fancyId);
            
            Console.WriteLine(id + "          " + URL);
            ViewBag.Category = _db
                .GetAllCategories()
                .ToDictionary(k => k.Category, v => v.CategoryId);
            APIFetchVM fetchVM = APIFetchVM
                .GetVMFromDictionary(_db.ServeApiResults(URL))
                .SingleOrDefault(api=>api.OrderID == id);
            CreateAwwVM vm = CreateAwwVM
                .GetNewAwwVM(fetchVM, new CategoryVM() { Id=-1,CategoryName=""});
            
            return View(vm);
        }
        [HttpPost]
        
        public IActionResult Create(IFormCollection collection)
        {
            int categoryId = int.Parse(collection["CategoryId"]);
            AwwDT dto = CreateAwwVM.GetAwwDTFromCollecion(collection);
            if(_db.AddAwwDTToDb(dto, categoryId))
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
       
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}