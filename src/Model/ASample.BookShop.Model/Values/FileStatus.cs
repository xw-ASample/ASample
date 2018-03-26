using System.ComponentModel;

namespace ASample.BookShop.Model.Values
{
    /// <summary>
    /// 文件状态
    /// </summary>
    public enum  FileStatus
    {
        [Description("可用")]
        Enable = 0,
        [Description("不可用")]
        DisEnable = 1
    }
}
