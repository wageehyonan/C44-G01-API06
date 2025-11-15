using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_G02.Shared.DTOs.BasketsDtos
{
    public class CustomerBasketDto
    {
        public string Id { get; set; } = null!;
        public ICollection<BasketItemDto>? Items { get; set; }
    }
}
