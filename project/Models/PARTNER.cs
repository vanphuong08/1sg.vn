using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace project.Models
{
    public class PARTNER
    {
        [Key]
        public int ID { get; set; }
        public string NAME { get; set; }
        public string IMAGE { get; set; }
    }
}