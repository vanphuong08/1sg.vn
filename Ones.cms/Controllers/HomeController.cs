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
    public class HomeController : Controller
    {
        public DataContext db = new DataContext();
        // GET: Home

        public ActionResult Index()
        {
            var list_home = db.HOMEs.ToList();
            return View(list_home);
        }
       
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection fc)
        {
            string TITLE = Request.Form["TITLE"];
            string DESCRIPTION = Request.Form["DESCRIPTION"];
            string CONTENT = Request.Form["CONTENT	"];
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
        public ActionResult Update(int ID)
        {
            int _ID = ID;

            string strConnection = ConfigurationManager.ConnectionStrings["connection"].ToString();
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand cmd = new SqlCommand("select * from HOMES where ID=@ID", conn);
                cmd.Parameters.AddWithValue("@ID", _ID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                //---
                DataRow dr = dt.NewRow();
                if (dt.Rows.Count > 0)
                    dr = dt.Rows[0];
                return View("Create", dr);
            }
            //---
        }
        //update - POST
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Update(FormCollection fc, int ID)
        {

            int _ID = ID;
            string _TITLE = Request.Form["TITLE"];
            string _DESCRIPTION = Request.Form["DESCRIPTION"];
            string _CONTENT = Request.Form["CONTENT"];
            string _IMAGE = Request.Form["IMAGE"];
            string strConnection = ConfigurationManager.ConnectionStrings["connection"].ToString();
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand("update HOMES set TITLE=@TITLE,DESCRIPTION=@DESCRIPTION,CONTENT=@CONTENT,IMAGE=@IMAGE where ID=@ID", conn);

                    cmd.Parameters.AddWithValue("@ID", _ID);
                    cmd.Parameters.AddWithValue("@TITLE", _TITLE);
                    cmd.Parameters.AddWithValue("@DESCRIPTION", _DESCRIPTION);
                    cmd.Parameters.AddWithValue("@CONTENT", _CONTENT);
                    cmd.Parameters.AddWithValue("@IMAGE", _IMAGE);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

              
            }
        
        
            return RedirectToAction("Index", "Home");
        }

    }
}