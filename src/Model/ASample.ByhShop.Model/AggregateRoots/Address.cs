using ASample.ByhShop.Model.Values;
using ASmaple.Domain.Models;

namespace ASample.ByhShop.Model
{
    public class Address : AggregateRoot
    {
        // 国家
        public string Country { get; set; }

        //省份
        public string State { get; set; }

        // 市
        public string City { get; set; }


        public string Street { get; set; }

        public string Zip { get; set; }

        public string FullAddress { get; set; }

        public AddressType AddressType { get; set; }
    }
}
