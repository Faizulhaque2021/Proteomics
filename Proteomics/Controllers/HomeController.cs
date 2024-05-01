using Microsoft.AspNetCore.Mvc;
using Proteomics.Models;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;
using Microsoft.CodeAnalysis;

namespace Proteomics.Controllers
{
    public class HomeController : Controller
    {
        private readonly string DefaultConnection;

        public HomeController(IConfiguration config)
        {
            DefaultConnection = config.GetConnectionString("DefaultConnection");
        }

        public JsonResult ListProteinSummary() 
        {
            List<ProteinSummary> prosum = new List<ProteinSummary>();
            using (var connection = new SqlConnection(DefaultConnection)) 
            {
                connection.Open();
                var cmd = new SqlCommand("SelectAllPs",connection);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) {
                        prosum.Add(new ProteinSummary
                        {
                            ProteinSummaryID = Convert.ToInt32(reader["ProteinSummaryID"]),
                            AccessionID = reader["AccessionID"].ToString(),
                            GeSymbol = reader["GeSymbol"].ToString(),
                            ProtName = reader["ProtName"].ToString(),
                            GeNames = reader["GeNames"].ToString(),
                            TotalPs = Convert.ToInt32(reader["TotalPs"].ToString()),
                            MePSMs = Convert.ToInt32(reader["MePSMs"].ToString()),
                            Detected = Convert.ToInt32(reader["Detected"].ToString())
                        }); ; 
                    }
                }
            }
            return Json(new { data = prosum });

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
    }
}
