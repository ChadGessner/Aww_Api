using AwwDTO;

namespace Aww_MVC.Models
{
    public class CategoryVM
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public static CategoryVM GetVMFromDT(AwwCategoryDT cat)
        {
            return new CategoryVM()
            {
                Id= cat.CategoryId,
                CategoryName= cat.Category
            };
        }
        
        public static AwwCategoryDT GetDTFromCollection(IFormCollection collection)
        {
            return new AwwCategoryDT()
            {
                Category = collection["CategoryName"],
            };
        }
    }
}
