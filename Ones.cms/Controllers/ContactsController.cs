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
    public class ContactsController : Controller
    {
        // GET: Contacts
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection fc)
        {
            string EMAIL = Request.Form["EMAIL"];
            string PHONE_NUMBER = Request.Form["PHONE_NUMBER"];
            string ADDRESS = Request.Form["ADDRESS	"];
            string strConnection = ConfigurationManager.ConnectionStrings["connection"].ToString();
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand cmd = new SqlCommand("insert into CONTACTS(EMAIL,PHONE_NUMBER,ADDRESS)values(@EMAIL,@PHONE_NUMBER,@ADDRESS)", conn);
                cmd.Parameters.AddWithValue("@EMAIL", EMAIL);
                cmd.Parameters.AddWithValue("@PHONE_NUMBER", PHONE_NUMBER);
                cmd.Parameters.AddWithValue("@ADDRESS", ADDRESS);
                //mo lenh ket noi
                conn.Open();
                //thuc thi cau lenh sql
                cmd.ExecuteNonQuery();
            }
            //---
            return RedirectToAction("Index", "Contacts");
        }
        public ActionResult Update(int ID)
        {
            int _ID = ID;

            string strConnection = ConfigurationManager.ConnectionStrings["connection"].ToString();
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand cmd = new SqlCommand("select * from CONTACTS where ID=@ID", conn);
                cmd.Parameters.AddWithValue("@ID", _ID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                //---
                DataRow dr = dt.NewRow();
                if (dt.Rows.Count > 0)
                    dr = dt.Rows[0];
                return View("Update", dr);
            }
            //---
        }
        //update - POST
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Update(FormCollection fc, int ID)
        {

            int _ID = ID;
            string _EMAIL = Request.Form["EMAIL"];
            string _PHONE_NUMBER = Request.Form["PHONE_NUMBER"];
            string _ADDRESS = Request.Form["ADDRESS"];
            string strConnection = ConfigurationManager.ConnectionStrings["connection"].ToString();
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand("update CONTACTS set EMAIL=@EMAIL,PHONE_NUMBER=@PHONE_NUMBER,ADDRESS=@ADDRESS  where ID=@ID", conn);
                    cmd.Parameters.AddWithValue("@ID", _ID);
                    cmd.Parameters.AddWithValue("@EMAIL", _EMAIL);
                    cmd.Parameters.AddWithValue("@PHONE_NUMBER", _PHONE_NUMBER);
                    cmd.Parameters.AddWithValue("@ADDRESS", _ADDRESS);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

            }
            return RedirectToAction("Index", "Contacts");
        }
    }
}