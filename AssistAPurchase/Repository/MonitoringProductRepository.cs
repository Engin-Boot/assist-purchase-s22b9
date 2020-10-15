using System.Collections.Generic;
using AssistAPurchase.AssistAPurchase.DataBase;
using AssistAPurchase.Models;

namespace AssistAPurchase.Repository
{
    public class MonitoringProductRepository : IMonitoringProductRepository
    {
        protected readonly List<MonitoringItems> MonitoringItems = new List<MonitoringItems>();

        public MonitoringProductRepository()
        {
            var products = new MonitoringProductsGetter().Products;
            foreach (MonitoringItems item in products)
                Add(item);
        }

        public IEnumerable<MonitoringItems> GetAll()
        {
            return MonitoringItems;
        }

        public void Add(MonitoringItems product)
        {
            MonitoringItems.Add(product);
        }

        public MonitoringItems Find(string productNumber)
        {
            foreach (MonitoringItems item in MonitoringItems)
                if (item.ProductNumber == productNumber)
                    return item;

            return null;
        }

        public MonitoringItems Remove(string productNumber)
        {
            for (var i = 0; i < MonitoringItems.Count; i++)
                if (MonitoringItems[i].ProductNumber == productNumber)
                {
                    var currentProduct = MonitoringItems[i];
                    MonitoringItems.RemoveAt(i);
                    return currentProduct;
                }

            return null;
        }

        public string Update(MonitoringItems product)
        {
            var currentProductNumber = product.ProductNumber;
            for (var i = 0; i < MonitoringItems.Count; i++)
                if (MonitoringItems[i].ProductNumber == currentProductNumber)
                {
                    MonitoringItems.RemoveAt(i);
                    MonitoringItems.Add(product);
                    string message = "Updated Sucessfully";
                    return message;
                }

            return null;
        }
    }
}