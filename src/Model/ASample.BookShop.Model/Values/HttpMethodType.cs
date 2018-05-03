using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASample.BookShop.Model.Values
{
    public enum  HttpMethodType
    {
        [Description("Post方式")]
        Post = 0,
        [Description("Get方式")]
        Put = 1
    }
}
