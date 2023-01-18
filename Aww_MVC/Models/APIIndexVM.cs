using AwwDTO;

namespace Aww_MVC.Models
{
    public class APIIndexVM
    {
        public int Id { get; set; }
        public string URL { get; set; } = "http://reddit.com/r/aww/.json";
        public List<APIFetchVM> ModelList { get; set; }
        public List<ApiUrlDTO> UrlList { get; set; }
        public static ApiUrlDTO GetDTOFromVM(APIIndexVM model)
        {
            return new ApiUrlDTO()
            {
                Url = model.URL
            };
        }
    }
    
}
