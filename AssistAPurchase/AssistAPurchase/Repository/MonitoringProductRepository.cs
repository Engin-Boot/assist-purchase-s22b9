using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using AssistAPurchase.Models;
using AssistAPurchase.DataBase;

namespace AssistAPurchase.Repository
{
    public class MonitoringProductRepository : IMonitoringProductRepository
    {
        //private static ConcurrentDictionary<string, MonitoringItems> items = new ConcurrentDictionary<string, MonitoringItems>();

        private static List<MonitoringItems> monitoringItems = new List<MonitoringItems>();

        public MonitoringProductRepository()
        {
            List<MonitoringItems> products = new MonitoringProductsGetter().Products;
            for (int index = 0; index < products.Count; index++)
                Add(products[index]);
        }

        public IEnumerable<MonitoringItems> GetAll()
        {
            //return items.Values;
            return monitoringItems;
            
        }

        public void Add(MonitoringItems product)
        {
            //items[product.ProductNumber] = product;
            monitoringItems.Add(product);

        }

        public MonitoringItems Find(string productNumber)
        {
            for (int i = 0; i < monitoringItems.Count; i++)
            {
                if (monitoringItems[i].ProductNumber == productNumber)
                    return monitoringItems[i];
            }

            MonitoringItems notAvailableItem = new MonitoringItems();
            notAvailableItem.ProductName = "Available";
            notAvailableItem.ProductNumber = "Not Available";
            return notAvailableItem;
            /*MonitoringItems product;
            items.TryGetValue(productNumber, out product);
            return product;*/
        }

        public MonitoringItems Remove(string productNumber)
        {
            for (int i = 0; i < monitoringItems.Count; i++)
            {
                if (monitoringItems[i].ProductNumber == productNumber)
                {
                    MonitoringItems currentProduct = new MonitoringItems();
                    currentProduct = monitoringItems[i];
                    monitoringItems.RemoveAt(i);
                    return currentProduct;
                }
            }
            MonitoringItems notAvailableItem = new MonitoringItems();
            notAvailableItem.ProductName = "Not Available";
            notAvailableItem.ProductNumber = "Not Available";
            return notAvailableItem;
            /*MonitoringItems product;
            items.TryGetValue(productNumber, out product);
            items.TryRemove(productNumber, out product);
            return product;*/
        }

        public string Update(MonitoringItems product)
        {
            string currentProductNumber = product.ProductNumber;
            string message = "";
            for (int i = 0; i < monitoringItems.Count; i++)
            {
                if (monitoringItems[i].ProductNumber == currentProductNumber)
                {
                    monitoringItems.RemoveAt(i);
                    monitoringItems.Add(product);
                    message = "Updated Sucessfully";
                    return message;
                }
            }
            message = "No Items Matches!!";
            return message;
            //items[product.ProductNumber] = product;
        }
    }
}
