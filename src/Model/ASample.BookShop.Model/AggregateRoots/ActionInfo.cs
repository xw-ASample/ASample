using ASample.BookShop.Model.Values;
using ASmaple.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASample.BookShop.Model.AggregateRoots
{
    public class ActionInfo:AggregateRoot
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 请求方式
        /// </summary>
        public HttpMethodType HttpMethod { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool DelFalg { get; set; }

        /// <summary>
        /// 是否为菜单
        /// </summary>
        public bool IsMenu { get; set; }

    }
}
