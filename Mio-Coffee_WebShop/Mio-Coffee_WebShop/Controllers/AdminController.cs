using Mio_Coffee_WebShop.Models;
using System.Linq;
using System.Web.Mvc;

namespace Mio_Coffee_WebShop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {

        private readonly ApplicationDbContext _dbContext;

        public AdminController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public AdminController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ActionResult ListUsers()
        {
            var roles = _dbContext.Roles.ToList();
            var users = _dbContext.Users.ToList();

            ViewBag.UserRoles = users.ToDictionary(
            user => user.Id,
            user => user.Roles.Select(usr => roles.FirstOrDefault(r => r.Id == usr.RoleId)?.Name).ToList()
            );
            return View(users);
        }

    }
}