using System.ComponentModel;

namespace ASample.Permission.Service.Models.Value
{
    public enum PasswordStatus
    {
        [Description("生效中")] Enabled = 0,
        [Description("已过期")] Expired,
        [Description("已生效")] Disabled
    }
}