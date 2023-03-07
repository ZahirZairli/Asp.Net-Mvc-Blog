using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EntityLayer.Concrete
{
    public class Content
    {
        [Key]
        public int ContentId { get; set; }
        [AllowHtml]
        public string ContentValue { get; set; }
        public bool ContentStatus { get; set; } = true;
        public DateTime ContentDate { get; set; }

        public int HeadingId { get; set; }
        public virtual Heading Heading { get; set; }

        public int? WriterId { get; set; }
        public virtual Writer Writer { get; set; }
    }
}
