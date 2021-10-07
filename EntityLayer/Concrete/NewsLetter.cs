using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class NewsLetter
    {
        [Key]
        public int mailId { get; set; }
        public string Mail { get; set; }
        public bool  mailStatus { get; set; }
    }
}
