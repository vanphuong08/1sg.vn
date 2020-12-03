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
    public class TeamController : Controller
    {
        public DataContext db = new DataContext();
        // GET: Home

        public ActionResult Index()
        {
            var list_team = db.TEAMs.ToList();
            return View(list_team);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection fc)
        {
            string NAME = Request.Form["NAME"];
            string POSITION = Request.Form["POSITION"];
            string IMAGE = Request.Form["IMAGE"];
            string strConnection = ConfigurationManager.ConnectionStrings["connection"].ToString();
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand cmd = new SqlCommand("insert into TEAMS(NAME,POSITION,IMAGE)values(@NAME,@POSITION,@IMAGE)", conn);
                cmd.Parameters.AddWithValue("@NAME", NAME);
                cmd.Parameters.AddWithValue("@POSITION", POSITION);
                cmd.Parameters.AddWithValue("@IMAGE", IMAGE);
                //mo lenh ket noi
                conn.Open();
                //thuc thi cau lenh sql
                cmd.ExecuteNonQuery();
            }
            //---
            return RedirectToAction("Index", "Team");
        }
        public ActionResult Update(int ID)
        {
            int _ID = ID;

            string strConnection = ConfigurationManager.ConnectionStrings["connection"].ToString();
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand cmd = new SqlCommand("select * from TEAMS where ID=@ID", conn);
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
            string POSITION = Request.Form["POSITION"];
            string _IMAGE = Request.Form["IMAGE"];
            string strConnection = ConfigurationManager.ConnectionStrings["connection"].ToString();
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand("update TEAMS set NAME=@NAME,POSITION=@POSITION,IMAGE=@IMAGE where ID=@ID", conn);

                    cmd.Parameters.AddWithValue("@ID", _ID);
                    cmd.Parameters.AddWithValue("@NAME", NAME);
                    cmd.Parameters.AddWithValue("@POSITION", POSITION);
                    cmd.Parameters.AddWithValue("@IMAGE", _IMAGE);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

            }
            return RedirectToAction("Index", "Team");
        }
        public ActionResult Delete(int ID)
        {
            int _ID = ID;
           
            string strConnection = ConfigurationManager.ConnectionStrings["connection"].ToString();
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand cmd = new SqlCommand("delete from TEAMS where ID=@ID", conn);
                cmd.Parameters.AddWithValue("@ID", _ID);
                //mo lenh ket noi
                conn.Open();
                //thuc thi cau lenh sql
                cmd.ExecuteNonQuery();
            }
            //---
            //di chuyen den url: Admin/Categories/Read
            return RedirectToAction("Index", "Team");
        }

    }
}