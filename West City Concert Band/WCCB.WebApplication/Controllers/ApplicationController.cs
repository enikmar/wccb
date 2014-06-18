using System.Linq;
using System.Web.Mvc;
using WCCB.Repositories;


namespace WCCB.WebApplication.Controllers
{
    public abstract class ApplicationController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (User != null)
            {
                var user = new UserRepository().FindBy(x => x.Username == User.Identity.Name).FirstOrDefault();
                if (user != null)
                {
                    ViewData.Add("UserName", string.Format("{0} {1}", user.UserProfile.Firstname, user.UserProfile.Lastname));
                    ViewData.Add("UserId", user.UserId);
                }
            }
            base.OnActionExecuted(filterContext);
        }
    }
}
