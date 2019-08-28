using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GetDataFromTheCloud.Models;
using GetDataFromTheCloud.viewModels;
using GetDataFromTheCloud.Repository.UnitOfWork.Interface;
using GetDataFromTheCloud.Repository.UnitOfWork.Class;
using Microsoft.EntityFrameworkCore;
using GetDataFromTheCloud.Models.Db.data;

namespace GetDataFromTheCloud.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUnitOfWork _context;
        public HomeController(DbContextOptions<AppDbContext> options)
        {
            _context = new UnitOfWork(new AppDbContext(options));
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetUsers()
        {
            var users = _context.UsersRepository.GetAll();
            return Json(users);
        }
        [HttpPost]
        public void SaveUser(UsersDto user)
        {
            var userId = user.UserId;
            var fullName = user.Name;
            var surname = user.Surname;

            if (string.IsNullOrEmpty(fullName) && string.IsNullOrEmpty(surname)) return;
            if(userId == 0)
            {
                var userTable = new Users()
                {
                    Name = fullName,
                    Surname = surname
                };

                _context.UsersRepository.Add(userTable);
            }
            else
            {
                var getUser = _context.UsersRepository.SingleOrDefault(u => u.UserId == userId);
                if (getUser == null) return;

                getUser.Name = fullName;
                getUser.Surname = surname;
            }
            
            _context.saveChanges();

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
