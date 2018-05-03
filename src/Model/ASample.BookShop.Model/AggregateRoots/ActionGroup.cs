using ASmaple.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASample.BookShop.Model.AggregateRoots
{
    public class ActionGroup : AggregateRoot
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
        public bool DelFlag { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        public int Sort { get; set; }
    }
}
