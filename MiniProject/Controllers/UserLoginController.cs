using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiniProject.Models;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace MiniProject.Controllers
{
    public class UserLoginController : Controller
    {
        // GET: UserLogin
        public ActionResult Index()
        {
            return View();
        }
    

        public ActionResult Index(LoginClass lc)

        {
            String mainconn = ConfigurationManager.ConnectionStrings["MyDatabaseEntities"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "select UserName,UserPassword from [dbo][UserReg] where UserName=@UserName and UserPassword=@UserPassword";
            sqlconn.Open();
            SqlCommand sqlcomm = new SqlCommand(sqlquery,sqlconn);
            sqlcomm.Parameters.AddWithValue("@UserName", lc.UserName);
            sqlcomm.Parameters.AddWithValue("@UserPassword", lc.Password);
            SqlDataReader sdr = sqlcomm.ExecuteReader();
            if(sdr.Read())
            {
                Session["Username"] = lc.UserName.ToString();
                return RedirectToAction("AllBooks");
            }
            else
            {
                ViewData["Message"] = "User Login Details Failed !";
            }
            sqlconn.Close();
            return View();
        }
    }
}