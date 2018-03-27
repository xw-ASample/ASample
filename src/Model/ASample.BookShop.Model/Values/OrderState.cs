using System.ComponentModel;

namespace ASample.BookShop.Model.Values
{
    public enum OrderState
    {
        [Description("已提交")]
        Commited = 0,

        [Description("未付款")]
        NonPayment = 1,

        [Description("已付款")]
        Paid = 2,


    }
}
