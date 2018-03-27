using ASmaple.Domain.Models;

namespace ASample.BookShop.Model.AggregateRoots
{
    /// <summary>
    /// 系统配置
    /// </summary>
    public class Setting:AggregateRoot
    {
        /// <summary>
        /// 键
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }
    }
}
