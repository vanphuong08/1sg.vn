using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ones.cms.Controllers
{
    public class FeedbacksController : Controller
    {
        // GET: FEEDBACKS
        public ActionResult Index()
        {
            return View();
        }
       
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection fc)
        {
            string NAME = Request.Form["NAME"];
            string EMAIL = Request.Form["EMAIL"];
            string PHONE_NUMBER = Request.Form["PHONE_NUMBER"];
            string TITLE = Request.Form["TITLE"];
            string DESCRIPTION = Request.Form["DESCRIPTION"];
            string strConnection = ConfigurationManager.ConnectionStrings["connection"].ToString();
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand cmd = new SqlCommand("insert into FEESBACKS(NAME,EMAIL,PHONE_NUMBER,TITLE,DESCRIPTION)values(@NAME,@EMAIL,@PHONE_NUMBER,@TITLE,@DESCRIPTION)", conn);
                cmd.Parameters.AddWithValue("@NAME", NAME);
                cmd.Parameters.AddWithValue("@EMAIL", EMAIL);
                cmd.Parameters.AddWithValue("@PHONE_NUMBER", PHONE_NUMBER);
                cmd.Parameters.AddWithValue("@TITLE", TITLE);
                cmd.Parameters.AddWithValue("@DESCRIPTION", DESCRIPTION);
                //mo lenh ket noi
                conn.Open();
                //thuc thi cau lenh sql
                cmd.ExecuteNonQuery();
            }
            //---
            return RedirectToAction("Index", "Feedbacks");
        }
    }
}