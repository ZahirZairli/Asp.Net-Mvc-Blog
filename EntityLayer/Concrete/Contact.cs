using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        public string UserName{ get; set; }
        public string UserMail{ get; set; }
        public string UserSubject{ get; set; }
        public string UserMessage{ get; set; }
        public DateTime ContactDate { get; set; } = DateTime.Now;
    }
}
