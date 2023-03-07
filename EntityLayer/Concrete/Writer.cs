using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int WriterId { get; set; }
        public string WriterName { get; set; }
        public string WriterSurname{ get; set; }
        [DefaultValue("avatar.png")]
        public string WriterImage { get; set; }
        public string WriterMail{ get; set; }
        public string WriterPhone{ get; set; }
        public string WriterPassword{ get; set; }
        public string WriterAbout{ get; set; }
        public bool WriterStatus { get; set; } = true;
        public DateTime WriterDate { get; set; } = DateTime.Now;

        public ICollection<Content> Contents { get; set; }
        public ICollection<Heading> Headings { get; set; }
    }
}
