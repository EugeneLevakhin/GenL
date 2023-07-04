using Microsoft.AspNetCore.Mvc;
using GenL.Business.Services.Abstract;
using GenL.Presentation.ViewComponents.Time.Models;

namespace GenL.Presentation.ViewComponents.Time;

public class TimeViewComponent : ViewComponent
{
    private readonly IUserService _userService;

    public TimeViewComponent(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<IViewComponentResult> InvokeAsync(bool isUtc)
    {
        TimeModel timeModel = new TimeModel(isUtc);

        // by default view must be in path:
        // ~/Views/<ViewFolderName, where component applied>/Components/<ComponentNameWithoutSuffix>/Default.cshtml

        // or in    ~/Views/Shared/Components/<ComponentNameWithoutSuffix>/Default.cshtml 
        //          ~/Pages/Shared/Components/<ComponentNameWithoutSuffix>/Default.cshtml
        return View(timeModel);

        // or return View("~/Views/Time/Components/Time/Default.cshtml", timeModel);

        // Content generation examples:
        //string time = $"{DateTime.Now.ToString("HH:mm:ss")}";
        //return Content(time); or - return new ContentViewComponentResult(time);
        //return new HtmlContentViewComponentResult(
        //    new HtmlString($"<p>Current time:<b>{DateTime.Now.ToString("HH:mm:ss")}</b></p>"));

        // ViewComponentContext :
        // HttpContext: представляет контекст, который описывает полученный запрос, а также отправляемый ответ
        // ModelState: представляет состояние модели в виде объекта ModelStateDictionary
        // Request: возвращает контекст запроса в виде объекта HttpRequest
        // RouteData: возвращает данные маршрута
        // Url: представляет объект IUrlHelper, который используется для генерации адресов URL
        // User: представляет текущего пользователя в виде объкта IPrincipal
        // ViewBag: представляет динамический объект, который может использоваться для передачи данных в представление
        // ViewContext: описывает контекст главного представления, в котором вызывается компонент
        // ViewComponentContext: представляет объект ViewComponentContext, который инкапсулирует контекст компонента
        // ViewData: возвращает объект ViewDataDictionary, который применяется для передачи данных в представление

        // example:
        //if (Request.Query.ContainsKey("number"))
        //{
        //    Int32.TryParse(Request.Query["number"].ToString(), out number);
        //}

        //ViewBag.Users = users.Take(number);
        //ViewData["Header"] = $"Количество пользователей: {number}.";
        //return View();
    }
}