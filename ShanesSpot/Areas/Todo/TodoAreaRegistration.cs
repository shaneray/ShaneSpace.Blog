using System.Web.Mvc;

namespace ShanesSpot.Areas.Todo
{
    public class TodoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Todo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Todo_default",
                "Todo/{controller}/{action}/{id}",
                new { controller = "TodoEntry", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}