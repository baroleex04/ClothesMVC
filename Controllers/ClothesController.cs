using Microsoft.AspNetCore.Mvc;

namespace ClothesMVC.Controllers
{
    public class ClothesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
