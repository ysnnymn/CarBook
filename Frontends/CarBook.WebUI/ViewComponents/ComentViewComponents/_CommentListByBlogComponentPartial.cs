using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.ComentViewComponents
{
    public class _CommentListByBlogComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
