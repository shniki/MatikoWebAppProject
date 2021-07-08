using MatikoWebAppProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace MatikoWebAppProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        /*
                [WebMethod]
                public void GetAllEmployee()
                {
                    List<EmployeesRecord> employeelist = new List<EmployeesRecord>();

                    string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        SqlCommand cmd = new SqlCommand("spGetAllEmployee", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            EmployeesRecord employee = new EmployeesRecord();
                            employee.ID = Convert.ToInt32(rdr["ID"]);
                            employee.Name = rdr["Name"].ToString();
                            employee.Position = rdr["Position"].ToString();
                            employee.Office = rdr["Office"].ToString();
                            employee.Age = Convert.ToInt32(rdr["Age"]);
                            employee.Salary = Convert.ToInt32(rdr["Salary"]);

                            employeelist.Add(employee);
                        }
                    }

                    JavaScriptSerializer js = new JavaScriptSerializer();
                    Context.Response.Write(js.Serialize(employeelist));
                }
            }
        */
    }
}
