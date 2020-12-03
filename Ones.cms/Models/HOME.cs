using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ones.cms.Models
{
    public class HOME
    {
        [Key]

        public int ID { get; set; }
        public string TITLE { get; set; }
        public string DESCRIPTION { get; set; }
        public string CONTENT { get; set; }
        public string IMAGE { get; set; }
        
    }
}