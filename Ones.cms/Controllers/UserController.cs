using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Ones.cms.Models;

namespace Ones.cms.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection fc)
        {
            string NAME = Request.Form["NAME"];
            string EMAIL = Request.Form["EMAIL"];
            string ACCOUNT = Request.Form["ACCOUNT"];
           
            string strConnection = ConfigurationManager.ConnectionStrings["connection"].ToString();
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand cmd = new SqlCommand("insert into LOGIN(NAME,EMAIL,ACCOUNT)values(@NAME,@EMAIL,@ACCOUNT)", conn);
                cmd.Parameters.AddWithValue("@NAME", NAME);
                cmd.Parameters.AddWithValue("@EMAIL", EMAIL);
                cmd.Parameters.AddWithValue("@ACCOUNT", ACCOUNT);
                //mo lenh ket noi
                conn.Open();
                //thuc thi cau lenh sql
                cmd.ExecuteNonQuery();
            }
            //---
            return RedirectToAction("Index", "User");
        }
    }
}