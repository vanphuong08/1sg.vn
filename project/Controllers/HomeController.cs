using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Header(FormCollection fc)
        {
            string NAME = Request.Form["NAME"];
            string URL = Request.Form["EMAIL"];
            string strConnection = ConfigurationManager.ConnectionStrings["connection"].ToString();
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand cmd = new SqlCommand("insert into MENUS(NAME,URL)values(@NAME,@URL)", conn);
                cmd.Parameters.AddWithValue("@NAME", NAME);
                cmd.Parameters.AddWithValue("@EMAIL", URL);
                //mo lenh ket noi
                conn.Open();
                //thuc thi cau lenh sql
                cmd.ExecuteNonQuery();
            }
            //---
            return RedirectToAction("Index", "Feedbacks");
        }
        public ActionResult Home(FormCollection fc)
        {
            string TITLE = Request.Form["TITLE"];
            string DESCRIPTION = Request.Form["DESCRIPTION"];
            string CONTENT = Request.Form["CONTENT"];
            string IMAGE = Request.Form["IMAGE"];
            string strConnection = ConfigurationManager.ConnectionStrings["connection"].ToString();
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand cmd = new SqlCommand("insert into HOMES(TITLE,DESCRIPTION,CONTENT,IMAGE)values(@TITLE,@DESCRIPTION,@CONTENT,@IMAGE)", conn);
                cmd.Parameters.AddWithValue("@TITLE", TITLE);
                cmd.Parameters.AddWithValue("@DESCRIPTION", DESCRIPTION);
                cmd.Parameters.AddWithValue("@CONTENT", CONTENT);
                cmd.Parameters.AddWithValue("@IMAGE", IMAGE);
                //mo lenh ket noi
                conn.Open();
                //thuc thi cau lenh sql
                cmd.ExecuteNonQuery();
            }
            //---
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Team(FormCollection fc)
        {
            string TITLE = Request.Form["NAME"];
            string DESCRIPTION = Request.Form["POSITION"];
            string IMAGE = Request.Form["IMAGE"];
            string strConnection = ConfigurationManager.ConnectionStrings["connection"].ToString();
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand cmd = new SqlCommand("insert into TEAMS(NAME,POSITION,IMAGE)values(@NAME,@POSITION,@IMAGE)", conn);
                cmd.Parameters.AddWithValue("@NAME", TITLE);
                cmd.Parameters.AddWithValue("@POSITION", DESCRIPTION);
                cmd.Parameters.AddWithValue("@IMAGE", IMAGE);
                //mo lenh ket noi
                conn.Open();
                //thuc thi cau lenh sql
                cmd.ExecuteNonQuery();
            }
            //---
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Contacts(FormCollection fc)
        {
            string EMAIL = Request.Form["EMAIL"];
            string PHONE_NUMBER = Request.Form["PHONE_NUMBER"];
            string ADDRESS = Request.Form["ADDRESS"];
            string strConnection = ConfigurationManager.ConnectionStrings["connection"].ToString();
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand cmd = new SqlCommand("insert into TEAMS(EMAIL,PHONE_NUMBER,ADDRESS)values(@EMAIL,@PHONE_NUMBER,@ADDRESS)", conn);
                cmd.Parameters.AddWithValue("@EMAIL", EMAIL);
                cmd.Parameters.AddWithValue("@PHONE_NUMBER", PHONE_NUMBER);
                cmd.Parameters.AddWithValue("@ADDRESS", ADDRESS);
                //mo lenh ket noi
                conn.Open();
                //thuc thi cau lenh sql
                cmd.ExecuteNonQuery();
            }
            //---
            return RedirectToAction("Index", "Home");
        }
      
    }
}