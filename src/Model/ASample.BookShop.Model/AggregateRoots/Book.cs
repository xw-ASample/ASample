using ASmaple.Domain.Models;
using System;

namespace ASample.BookShop.Model
{
    /// <summary>
    /// 书本
    /// </summary>
    public class Book:AggregateRoot
    {
        /// <summary>
        /// 书本标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// 出版社编号
        /// </summary>
        public Guid PublisherId { get; set; }

        /// <summary>
        ///出版日期
        /// </summary>
        public DateTime PublishDate { get; set; }

        /// <summary>
        /// 书本编号
        /// </summary>
        public string ISBN { get; set; }

        /// <summary>
        /// 书本总字数
        /// </summary>
        public int WordsCount { get; set; }

        /// <summary>
        /// 书本价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 书本内容描述
        /// </summary>
        public string ContentDescription { get; set; }

        /// <summary>
        /// 书本作者描述
        /// </summary>
        public string AurhorDescription { get; set; }

        /// <summary>
        /// 编者评论
        /// </summary>
        public string EditorComment { get; set; }

        /// <summary>
        /// 书本目录
        /// </summary>
        public string TOC { get; set; }

        /// <summary>
        /// 类别编号
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        /// 书本点击次数
        /// </summary>
        public int Clicks { get; set; }
    }
}
