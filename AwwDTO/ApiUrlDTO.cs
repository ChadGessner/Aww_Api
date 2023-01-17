using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwwDTO
{
    public class ApiUrlDTO
    {
        [Key]
        public int UrlId { get; set; }
        public string Url { get; set; }
    }
}
