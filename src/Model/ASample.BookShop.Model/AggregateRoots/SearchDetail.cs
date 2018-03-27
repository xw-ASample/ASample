using System;

namespace ASample.BookShop.Model.AggregateRoots
{
    /// <summary>
    /// 搜索详情
    /// </summary>
    public class SearchDetail
    {
        /// <summary>
        /// 关键字
        /// </summary>
        public string KeyWords { get; set; }

        /// <summary>
        /// 搜索时间
        /// </summary>
        public DateTime  SearchDateTime { get; set; }
    }
}
