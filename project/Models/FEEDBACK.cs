using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace project.Models
{
    public class FEEDBACK
    {
        [Key]
        public int ID { get; set; }
        public string NAME { get; set; }
        public string EMAIL { get; set; }
        public string PHONE_NUMBER { get; set; }
        public string TITLE { get; set; }
        public string DESCRIPTION { get; set; }
    }
}