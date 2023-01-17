using AwwDTO;

namespace Aww_MVC.Models
{
    public class DbAwwVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string CategoryName { get; set; }
        public int? CategoryId { get; set; }
        public static DbAwwVM GetVMFromDT(AwwDT aww)
        {
            return new DbAwwVM() {
                Id = aww.AwwId,
                ImageUrl = aww.Url,
                CategoryId = aww.CategoryId,
                Title = aww.Title,
                CategoryName = aww.AwwCategoryDT.Category 
            };
        }
    }
    
}
