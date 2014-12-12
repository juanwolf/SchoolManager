using System.Web.Mvc;

namespace SchoolManager.Areas.ClassManagement
{
    public class ClassManagementAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ClassManagement";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ClassManagement_default",
                "ClassManagement/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
