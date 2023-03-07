using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EntityLayer.Concrete
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        [StringLength(50)]
        public string SenderMail { get; set; }
        [StringLength(50)]
        public string RecieverMail { get; set; }
        [StringLength(100)]
        public string MessageSubject{ get; set; }
        [AllowHtml]
        public string MessageContent { get; set; }
        public DateTime MessageDate { get; set; } = DateTime.Now;
        public bool MessageStatus { get; set; } = true;
        public bool DraftStatus { get; set; } = false;
        public bool ReadingStatus { get; set; } = false;
    }
}
