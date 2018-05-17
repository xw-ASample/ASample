using ASmaple.Domain.Models;


namespace ASample.ByhShop.Model
{
    public class Category : AggregateRoot
    {
        public string Name { get; set; }

        public string Description { get; set; }

        
    }
}
