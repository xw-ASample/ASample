using ASmaple.Domain.Models;

namespace ASample.BookShop.Model.AggregateRoots
{
    /// <summary>
    /// 关键字排名
    /// </summary>
    public class KeyWordRank:AggregateRoot
    {
        /// <summary>
        /// 关键字
        /// </summary>
        public string KeyWords { get; set; }

        /// <summary>
        /// 搜索次数
        /// </summary>
        public int SearchTimes { get; set; }
    }
}
