using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Ones.cms.Models;

namespace Ones.cms.Controllers
{
    public class PartnerController : Controller
    {
        // GET: Partner
        public DataContext db = new DataContext();
        // GET: Home

        public ActionResult Index()
        {
            var list_partner = db.PARTNERs.ToList();
            return View(list_partner);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection fc)
        {
            string NAME = Request.Form["NAME"];
            string IMAGE = Request.Form["IMAGE"];
            string strConnection = ConfigurationManager.ConnectionStrings["connection"].ToString();
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand cmd = new SqlCommand("insert into PARTNERS(NAME,IMAGE)values(@NAME,@IMAGE)", conn);
                cmd.Parameters.AddWithValue("@NAME", NAME);
                cmd.Parameters.AddWithValue("@IMAGE", IMAGE);
                //mo lenh ket noi
                conn.Open();
                //thuc thi cau lenh sql
                cmd.ExecuteNonQuery();
            }
            //---
            return RedirectToAction("Index", "Partner");
        }
        public ActionResult Update(int ID)
        {
            int _ID = ID;

            string strConnection = ConfigurationManager.ConnectionStrings["connection"].ToString();
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand cmd = new SqlCommand("select * from PARTNERS where ID=@ID", conn);
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
            string NAME = Request.Form["NAME"];
            string _IMAGE = Request.Form["IMAGE"];
            string strConnection = ConfigurationManager.ConnectionStrings["connection"].ToString();
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand("update PARTNERS set NAME=@NAME,IMAGE=@IMAGE where ID=@ID", conn);

                    cmd.Parameters.AddWithValue("@ID", _ID);
                    cmd.Parameters.AddWithValue("@NAME", NAME);
                    cmd.Parameters.AddWithValue("@IMAGE", _IMAGE);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

            }
            return RedirectToAction("Index", "Partner");
        }
        public ActionResult Delete(int ID)
        {
            int _ID = ID;

            string strConnection = ConfigurationManager.ConnectionStrings["connection"].ToString();
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand cmd = new SqlCommand("delete from PARTNERS where ID=@ID", conn);
                cmd.Parameters.AddWithValue("@ID", _ID);
                //mo lenh ket noi
                conn.Open();
                //thuc thi cau lenh sql
                cmd.ExecuteNonQuery();
            }
            //---
            return RedirectToAction("Index", "Partner");
        }

    }
}