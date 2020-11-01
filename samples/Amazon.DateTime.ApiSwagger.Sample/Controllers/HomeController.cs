using Microsoft.AspNetCore.Mvc;

namespace Amazon.DateTime.ApiSwagger.Sample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("/swagger");
        }
    }
}
