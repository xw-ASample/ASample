using ASmaple.Domain.Models;

namespace ASample.BookShop.Model
{
    /// <summary>
    /// 用户等级
    /// </summary>
    public class UserLevel:AggregateRoot
    {
        /// <summary>
        /// 等级标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 等级描述-*/89
        /// </summary>
        public string Description { get; set; }
    }
}
