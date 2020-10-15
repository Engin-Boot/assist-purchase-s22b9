using System.Collections.Generic;
using AssistAPurchase.Models;

namespace AssistAPurchase.SupportingFunctions
{
    public static class ProductConfigureSupporterFunctions
    {
        public static bool CheckForNullOrMisMatchProductNumber(MonitoringItems product, string productNumber)
        {
            if (product == null || product.ProductNumber != productNumber)
                return true;
            return false;
        }

        public static List<MonitoringItems> GetItemsAboveThanGivenPrice(string price, List<MonitoringItems> monitoringItems)
        {
            List<MonitoringItems> finalItemWithPriceAboveCategory = new List<MonitoringItems>();
            foreach (MonitoringItems item in monitoringItems)
            {
                if (float.Parse(item.Price) > float.Parse(price))
                    finalItemWithPriceAboveCategory.Add(item);
            }
            return finalItemWithPriceAboveCategory;
        }
        public static List<MonitoringItems> GetItemsBelowThanGivenPrice(string price, List<MonitoringItems> monitoringItems)
        {
            List<MonitoringItems> finalItemWithPriceBelowCategory = new List<MonitoringItems>();
            foreach (MonitoringItems item in monitoringItems)
            {
                if (float.Parse(item.Price) <= float.Parse(price))
                    finalItemWithPriceBelowCategory.Add(item);
            }
            return finalItemWithPriceBelowCategory;
        }

        public static List<MonitoringItems> GetItemsAboveThanGivenScreenSize(string screenSize, List<MonitoringItems> monitoringItems)
        {
            List<MonitoringItems> finalItemWithScreenSizeAboveCategory = new List<MonitoringItems>();
            foreach (MonitoringItems item in monitoringItems)
            {
                if (float.Parse(item.ScreenSize) > float.Parse(screenSize))
                    finalItemWithScreenSizeAboveCategory.Add(item);
            }
            return finalItemWithScreenSizeAboveCategory;
        }
        public static List<MonitoringItems> GetItemsBelowThanGivenScreenSize(string screenSize, List<MonitoringItems> monitoringItems)
        {
            List<MonitoringItems> finalItemWithScreenSizeBelowCategory = new List<MonitoringItems>();
            foreach (MonitoringItems item in monitoringItems)
            {
                if (float.Parse(item.ScreenSize) <= float.Parse(screenSize))
                    finalItemWithScreenSizeBelowCategory.Add(item);
            }
            return finalItemWithScreenSizeBelowCategory;
        }
    }
}
