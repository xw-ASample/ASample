using ASmaple.Domain.Models;

namespace ASample.BookShop.Model.AggregateRoots
{
    /// <summary>
    /// 出版社
    /// </summary>
    public class Publisher : AggregateRoot
    {
        /// <summary>
        /// 出版社名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 出版社描述
        /// </summary>
        public string Decription { get; set; }
    }
}
