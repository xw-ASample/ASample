using System.ComponentModel.DataAnnotations;

namespace ASample.BookShop.WebSite.Models
{
    public class RegisterModel
    {
        [StringLength(10),Required()]
        public string Name { get; set; }

        [StringLength(16), Required()]
        public string Password { get; set; }

        [StringLength(13), Required()]
        public string Phone { get; set; }
    }
}