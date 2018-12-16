using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASample.Permission.Service.Core
{
    public class Redirect:Exception
    {
        public string TargetUrl
        {
            get;
            private set;
        }

        public Redirect(string message, string targetUrl, string code) : base(message)
        {
            this.TargetUrl = targetUrl;
        }

        public Redirect(string targetUrl) : this("需要进行一次重定向", targetUrl, "Redirect_Needed")
        {
        }

        public Redirect(string message, string code = null) : base(message)
        {
        }
    }
}