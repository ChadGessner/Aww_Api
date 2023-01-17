using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwwDTO
{
    public class AwwCategoryDT
    {
        [Key]
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public virtual List<AwwDT> AwwImages { get; set; } = new List<AwwDT>();
    }
}
