using Ecommerce_G02.Domain.Contacts.IRepos;
using Ecommerce_G02.Domain.Models.Baskets;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ecommerce_G02.Presistence.Repos
{
    public class BasketReposatory (IConnectionMultiplexer connection): IBasketReposatory
    {
        //for get database
        private readonly IDatabase _database= connection.GetDatabase();

        public async Task<CustomerBasket?> CreateUpdateAsync(CustomerBasket basket,TimeSpan? TimeToLive=null)
        {
           var jsonbasket=JsonSerializer.Serialize(basket);
            var IscreatedOrUpdated =await  _database.StringSetAsync(basket.Id, jsonbasket,TimeToLive ?? TimeSpan.FromHours(5));
            if (IscreatedOrUpdated)
            {
                return await GetBasketAsync(basket.Id);
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> DeleteBasketAsync(string key)
        {
          return await _database.KeyDeleteAsync(key);
        }

        public async Task<CustomerBasket?> GetBasketAsync(string key)
        {
            var basket=await _database.StringGetAsync(key);

            if (basket.IsNullOrEmpty)
            {
                return null;
            }
            else
            {
                return JsonSerializer.Deserialize<CustomerBasket>(basket);
            }
        }
    }
}
