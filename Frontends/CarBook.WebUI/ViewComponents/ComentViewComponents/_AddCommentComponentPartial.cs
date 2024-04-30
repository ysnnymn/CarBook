using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.ComentViewComponents
{
    public class _AddCommentComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
