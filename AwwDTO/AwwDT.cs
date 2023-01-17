using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AwwDTO
{
    public class AwwDT
    {
        [Key]
        public int AwwId { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public int CategoryId { get; set; }
        public virtual AwwCategoryDT AwwCategoryDT { get; set; }

    }
}