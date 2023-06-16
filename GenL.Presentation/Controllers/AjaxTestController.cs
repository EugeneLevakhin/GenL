using Microsoft.AspNetCore.Mvc;
using GenL.Presentation.Models.Ajax;

namespace GenL.Presentation.Controllers
{
    public class AjaxTestController : Controller
    {
        public ActionResult AjaxTestView()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ShowResult(ResultModel resultModel)
        {
            resultModel.Result++;
            return PartialView("~/Views/Partial/AjaxTest/Result.cshtml", new ResultModel { Result = resultModel.Result });
        }
    }
}