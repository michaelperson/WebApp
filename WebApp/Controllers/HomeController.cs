using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IStudentService _studentService;
        public HomeController(ILogger<HomeController> logger, IConfiguration config, IStudentService studentService)
        {
            _logger = logger;
            _configuration = config;
            _studentService = studentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListStudents()
        {
            IEnumerable<ClientDto> students = _studentService.GetAll();
            if(students!=null)
            {
                return View(students);
            }
            else
            {
                return NotFound();
            }
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
