using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_G02.Domain.Models.Baskets
{
    public class CustomerBasket
    {
        public string Id { get; set; } = null!;
        public ICollection<BasketItem>? Items { get; set; }
    }
}
