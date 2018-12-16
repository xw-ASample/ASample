using Microsoft.Owin;
using System.Web;

namespace ASample.Permission.Service.Infrastructure
{
    public class OwinContextHelper
    {
        public static HttpContextBase CurrentContextBase
        {
            get { return new HttpContextWrapper(HttpContext.Current); }
        }

        public static IOwinContext CurrentOwinContext
        {
            get { return CurrentContextBase.GetOwinContext(); }
        }
    }
}