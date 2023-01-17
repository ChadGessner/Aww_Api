using AwwDTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
namespace Aww_Api_Repository
{
    public class AwwRepository
    {
        private IConfigurationRoot _configuration;
        private DbContextOptionsBuilder<ApplicationDbContext> _optionsBuilder;
        public AwwRepository()
        {
            BuildOptions();
        }
        private void BuildOptions()
        {
            _configuration = ConfigurationBuilderSingleton.ConfigurationRoot;
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            _optionsBuilder.UseSqlServer(_configuration.GetConnectionString("StringyConnections"));
        }
        public IEnumerable<AwwCategoryDT> GetCategories()
        {
            using(ApplicationDbContext db = new ApplicationDbContext(_optionsBuilder.Options))
            {
                return db.Categories
                    .ToList();
            }
        }
        public bool AddCategory(AwwCategoryDT cat)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_optionsBuilder.Options))
            {
                AwwCategoryDT notCat = GetCategories()
                    .FirstOrDefault(c => c.CategoryId == cat.CategoryId || c.Category == cat.Category);
                if (notCat == null)
                {
                    db.Add(cat);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public List<ApiUrlDTO> GetApiUrls()
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_optionsBuilder.Options))
            {
                return db.ApiUrls
                    .ToList();
            }
        }
        public AwwCategoryDT GetCategoryDTById(int? id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_optionsBuilder.Options))
            {
                return GetCategories()
                    .FirstOrDefault(c => c.CategoryId == id);
            }
        }
        public List<AwwDT> GetAllAwwDT()
        {
            using(ApplicationDbContext db = new ApplicationDbContext(_optionsBuilder.Options))
            {
                return db.AwwImages.Include(x=>x.AwwCategoryDT)
                    .ToList();
            }
        }
        public AwwDT GetAwwDTById(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_optionsBuilder.Options))
            {
                
                AwwDT dto = GetAllAwwDT()
                    .FirstOrDefault(a => a.AwwId == id);
                if(dto != null)
                {
                    return dto;
                }
                Console.Write("gayeee");
                return dto;
                
            }
        }
        public bool DeleteAwwImageById(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_optionsBuilder.Options))
            {
                AwwDT aww = GetAwwDTById(id);
                if(aww != null)
                {
                    db.Remove(aww);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
                
        }
        public bool AddAwwDT(AwwDT aww, int categoryId)
        {
            
            
            using (ApplicationDbContext db = new ApplicationDbContext(_optionsBuilder.Options))
            {
                db.AwwImages.Add(aww);
                aww.CategoryId = categoryId;
                aww.AwwCategoryDT = GetCategoryDTById(aww.CategoryId);
                

                
                GetCategoryDTById(categoryId).AwwImages.Add(aww);
                db.SaveChanges();
                return true;

            }
        }
        public ApiUrlDTO GetUrlById(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_optionsBuilder.Options))
            {
                return db.ApiUrls
                    .FirstOrDefault(x => x.UrlId == id);
            }
        }
        public bool AddUrlToDb(ApiUrlDTO url)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_optionsBuilder.Options))
            {
                ApiUrlDTO notUrl = GetUrlById(url.UrlId);
                if(notUrl == null)
                {
                    db.ApiUrls.Add(url);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        
    }
}