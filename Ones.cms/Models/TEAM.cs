using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ones.cms.Models
{
    public class TEAM
    {
        [Key]
        public int ID { get; set; }
        public string NAME { get; set; }
        public string POSITION { get; set; }
        public string IMAGE { get; set; }
    }
}