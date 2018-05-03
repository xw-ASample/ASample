using ASmaple.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASample.BookShop.IRepository.Models
{
    public class Book : AggregateRoot
    {
        public string Name { get; set; }

        public int  Price { get; set; }
    }
}
