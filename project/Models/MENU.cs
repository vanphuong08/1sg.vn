using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace project.Models
{
   
    public class MENU
    {
        [Key]
        public int ID { get; set; }
        public string NAME  { get; set; }
        public string URL { get; set; }

    }
}