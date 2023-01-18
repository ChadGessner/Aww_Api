using Aww_Api_Fetch;
using Aww_Api_Repository;
using AwwDTO;

namespace AwwDomain
{
    public class Interactor
    {
        private AwwRepository _db;
        private ApiHandler _api;
        public Interactor()
        {
            _db = new AwwRepository();
            _api = new ApiHandler();
        }
        public bool AddCategoryToDb(AwwCategoryDT cat)
        {
            return _db.AddCategory(cat);
        }
        public ApiUrlDTO GetLastUrl()
        {
            int max = _db
                .GetApiUrls()
                .Max(x => x.UrlId);

            return _db.GetUrlById(max);
        }
        public IEnumerable<AwwCategoryDT> GetAllCategories()
        {
            return _db.GetCategories();
        }
        public Dictionary<string,string> ServeApiResults(string url)
        {
            return _api.SetUrl(url);
        }
        public AwwDT GetAwwDTById(int id)
        {
            return _db.GetAwwDTById(id); 
        }
        public AwwCategoryDT GetCategoryById(int id)
        {
            AwwCategoryDT cat = _db
                .GetCategoryDTById(id);
            return cat;
        }
        public bool AddAwwDTToDb(AwwDT aww, int categoryId)
        {
            AwwDT notAww = _db.GetAwwDTById(aww.AwwId);
            
            if(notAww == null)
            {
                //AwwCategoryDT cat = _db.GetCategoryDTById(aww.CategoryId);
                //aww.AwwCategoryDT = cat;
                return _db.AddAwwDT(aww, categoryId);
            }
            return false;
        }
        public List<AwwDT> GetAllAwwDTs()
        {
            return _db.GetAllAwwDT();
        }
        public bool DeleteAwwDTById(int id)
        {
            return _db.DeleteAwwImageById(id);
        }
        public bool AddUrl(ApiUrlDTO url)
        {
            return _db.AddUrlToDb(url);
        }
        public ApiUrlDTO GetUrlById(int id)
        {
            return _db.GetUrlById(id);
        }
        public List<ApiUrlDTO> GetAllUrls()
        {
            return _db.GetApiUrls();
        }
    }
}