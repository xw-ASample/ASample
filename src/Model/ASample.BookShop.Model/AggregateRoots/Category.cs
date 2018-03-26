using ASmaple.Domain.Models;

namespace ASample.BookShop.Model.AggregateRoots
{
    /// <summary>
    /// 类别
    /// </summary>
    public class Category:AggregateRoot
    {
        /// <summary>
        /// 类别名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 类别描述
        /// </summary>
        public string Description { get; set; }
    }
}
