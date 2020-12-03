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
    public class MenuController : Controller
    {
        // GET: Menu
        public DataContext db = new DataContext();
        // GET: Home

        public ActionResult Index()
        {
            var list_menu = db.MENUs.ToList();
            return View(list_menu);
        }
        public ActionResult Delete(int ID)
        {
            int _ID = ID;
            //---
            //lay ra ban ghi tuong ung voi danh muc truyen vao
            //lay chuoi ket noi tu file Web.config
            string strConnection = ConfigurationManager.ConnectionStrings["connection"].ToString();
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand cmd = new SqlCommand("delete from MENUS where ID=@ID", conn);
                cmd.Parameters.AddWithValue("@ID", _ID);
                //mo lenh ket noi
                conn.Open();
                //thuc thi cau lenh sql
                cmd.ExecuteNonQuery();
            }
            //---
            return RedirectToAction("Index", "Menu");
        }



        public ActionResult Create()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection fc)
        {
            string NAME = Request.Form["NAME"];
            string URL = Request.Form["URL"];
            string strConnection = ConfigurationManager.ConnectionStrings["connection"].ToString();
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand cmd = new SqlCommand("insert into MENUS(NAME,URL)values(@NAME,@URL)", conn);
                cmd.Parameters.AddWithValue("@NAME", NAME);
                cmd.Parameters.AddWithValue("@URL", URL);
                //mo lenh ket noi
                conn.Open();
                //thuc thi cau lenh sql
                cmd.ExecuteNonQuery();
            }
            //---
            return RedirectToAction("Index", "Menu");
        }
        public ActionResult Update(int ID)
        {
            int _ID = ID;

            string strConnection = ConfigurationManager.ConnectionStrings["connection"].ToString();
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand cmd = new SqlCommand("select * from MENUS where ID=@ID", conn);
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
            string _NAME = Request.Form["NAME"];
            string _URL = Request.Form["URL"];
            string strConnection = ConfigurationManager.ConnectionStrings["connection"].ToString();
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand("update MENUS set NAME=@NAME,URL=@URL where ID=@ID", conn);
                    cmd.Parameters.AddWithValue("@ID", _ID);
                    cmd.Parameters.AddWithValue("@NAME", _NAME);
                    cmd.Parameters.AddWithValue("@URL", _URL);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

            }

            return RedirectToAction("Index", "Menu");
        }
    }
}