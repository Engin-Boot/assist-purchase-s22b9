using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using AssistAPurchase.Models;

namespace AssistAPurchase.Repository
{
    public class MonitoringProductRepository : IMonitoringProductRepository
    {
        private static ConcurrentDictionary<int, MonitoringItems> items =
              new ConcurrentDictionary<int, MonitoringItems>();

        public MonitoringProductRepository()
        {
            Add(new MonitoringItems { ProductName = "Item1" });
        }

        public IEnumerable<MonitoringItems> GetAll()
        {
            return items.Values;
        }

        public void Add(MonitoringItems product)
        {
        
            Random r = new Random();
            int genRand = r.Next(10, 50);
            product.ProductNumber = genRand;
            items[product.ProductNumber] = product;

          }

        public MonitoringItems Find(int productNumber)
        {
            MonitoringItems product;
            items.TryGetValue(productNumber, out product);
            return product;
        }

        public MonitoringItems Remove(int productNumber)
        {
            MonitoringItems product;
            items.TryGetValue(productNumber, out product);
            items.TryRemove(productNumber, out product);
            return product;
        }

        public void Update(MonitoringItems product)
        {
            items[product.ProductNumber] = product;
        }
    }
}
