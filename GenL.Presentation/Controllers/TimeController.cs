using Microsoft.AspNetCore.Mvc;

namespace GenL.Presentation.Controllers;

public class TimeController : Controller
{
    public ActionResult ShowTime()
    {
        return View();
    }
}