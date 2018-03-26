using ASample.BookShop.Model.Values;
using ASmaple.Domain.Models;

namespace ASample.BookShop.Model.AggregateRoots
{
    public class VideoFile : AggregateRoot
    {
        /// <summary>
        /// 文件标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 文件路径
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// 文件状态
        /// </summary>
        public FileStatus Status { get; set; }

        /// <summary>
        /// 文件扩展吗名
        /// </summary>
        public string FileExt { get; set; }
    }
}
