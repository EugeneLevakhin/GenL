using Microsoft.AspNetCore.Mvc;

namespace GenL.Presentation.Controllers
{
    public class JsTestController : Controller
    {
        public IActionResult JsTestView()
        {
            return View();
        }
    }
}