using System.ComponentModel;

namespace ASample.ByhShop.Model.Values
{
    public enum  AddressType
    {
        [Description("邮寄地址")]
        Post=0,
        [Description("联系地址")]
        Contact =1
    }
}
