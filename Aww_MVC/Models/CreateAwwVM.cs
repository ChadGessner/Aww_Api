using AwwDTO;

namespace Aww_MVC.Models
{
    public class CreateAwwVM
    {
        public APIFetchVM VM { get; set; }
        public int FetchId { get; set; }
        public int CategoryId { get; set; }
        public CategoryVM Category {get;set;}
        public static CreateAwwVM GetNewAwwVM(APIFetchVM vm, CategoryVM cat)
        {
            return new CreateAwwVM()
            {
                VM = vm,
                Category = cat
            };
        }
        public static AwwDT GetAwwDTFromCollecion(IFormCollection collection)
        {
            return new AwwDT()
            {
                Title = collection["VM.Title"],
                Url = collection["VM.ImageUrl"],
                
            };
        }
    }
}
