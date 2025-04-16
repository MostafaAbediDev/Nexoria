using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages
{
    public class AdminPageModelModel : PageModel
    {
        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            var request = context.HttpContext.Request;
            var username = request.Query["u"].ToString();
            var password = request.Query["p"].ToString();

            if (username != "admin" || password != "1234")
            {
                // اگر اطلاعات نادرست بود، به صفحه لاگین ریدایرکت کن
                context.Result = new RedirectToPageResult("/Admin", new { ReturnUrl = request.Path });
            }

            base.OnPageHandlerExecuting(context);
        }
    }
}
