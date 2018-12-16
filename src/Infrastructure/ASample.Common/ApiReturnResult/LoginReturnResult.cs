using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASample.Common.ApiReturnResult
{
    public class LoginReturnResult
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public string ReturnUrl { get; set; }

        public static LoginReturnResult Success(string msg,string returnUrl = null)
        {
            var result = new LoginReturnResult()
            {
                Message = msg,
                IsSuccess = true,
                ReturnUrl = returnUrl
            };
            return result;
        }
        public static LoginReturnResult Error(string msg)
        {
            var result = new LoginReturnResult()
            {
                Message = msg,
                IsSuccess = false,
            };
            return result;
        }
    }
}
