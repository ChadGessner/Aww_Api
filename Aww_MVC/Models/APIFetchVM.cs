using AwwDTO;

namespace Aww_MVC.Models
{
    public class APIFetchVM
    {
        public int OrderID { get; set; }
        public string Title { get; set; }
        public string ImageURL { get; set; } 
        
        public static List<APIFetchVM> GetVMFromDictionary(Dictionary<string, string> map)
        {
            return map
                .Select(
                (kvp, index) => 
                new APIFetchVM 
                { 
                    OrderID = index + 1, 
                    Title = kvp.Key, 
                    ImageURL = kvp.Value 
                })
                .ToList();
        }
        
        public static AwwDT GetAwwDTFromVM(APIFetchVM vm)
        {
            return new AwwDT()
            {
                Title = vm.Title,
                Url = vm.ImageURL,
            };
        }
    }
}
