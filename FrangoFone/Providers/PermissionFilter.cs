using System.Configuration;
using System.Web;
using System.Web.Mvc;

namespace FrangoFone.Providers
{
    public class PermissionFilter: AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if ((bool)new AppSettingsReader().GetValue("EnablePermissionFiltrer", typeof(bool)))
            {
                base.OnAuthorization(filterContext);

                if (filterContext.Result is HttpUnauthorizedResult)                                                             
                filterContext.HttpContext.Response.Redirect("/Login/Login");
            }                                      
        }
    }
}
