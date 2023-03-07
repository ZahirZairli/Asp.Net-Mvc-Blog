using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DtoChart
{
    public class HeadingChart
    {
        [Key]
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
