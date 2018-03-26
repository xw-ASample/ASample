using ASmaple.Domain.Models;
using System;

namespace ASample.BookShop.Model
{
    /// <summary>
    /// 图书评论
    /// </summary>
    public class BookComment:AggregateRoot
    {
        /// <summary>
        /// 评论内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 图书编号
        /// </summary>
        public Guid BookId { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public Guid UserId { get; set; }
    }
}
