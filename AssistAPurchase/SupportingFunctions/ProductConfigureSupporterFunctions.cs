using System.Collections.Generic;
using AssistAPurchase.Models;

namespace AssistAPurchase.SupportingFunctions
{
    public class ProductConfigureSupporterFunctions
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
            for (int i = 0; i < monitoringItems.Count; i++)
            {
                if (float.Parse(monitoringItems[i].Price) > float.Parse(price))
                    finalItemWithPriceAboveCategory.Add(monitoringItems[i]);
            }
            return finalItemWithPriceAboveCategory;
        }
        public static List<MonitoringItems> GetItemsBelowThanGivenPrice(string price, List<MonitoringItems> monitoringItems)
        {
            List<MonitoringItems> finalItemWithPriceBelowCategory = new List<MonitoringItems>();
            for (int i = 0; i < monitoringItems.Count; i++)
            {
                if (float.Parse(monitoringItems[i].Price) <= float.Parse(price))
                    finalItemWithPriceBelowCategory.Add(monitoringItems[i]);
            }
            return finalItemWithPriceBelowCategory;
        }

        public static List<MonitoringItems> GetItemsAboveThanGivenScreenSize(string screenSize, List<MonitoringItems> monitoringItems)
        {
            List<MonitoringItems> finalItemWithScreenSizeAboveCategory = new List<MonitoringItems>();
            for (int i = 0; i < monitoringItems.Count; i++)
            {
                if (float.Parse(monitoringItems[i].ScreenSize) > float.Parse(screenSize))
                    finalItemWithScreenSizeAboveCategory.Add(monitoringItems[i]);
            }
            return finalItemWithScreenSizeAboveCategory;
        }
        public static List<MonitoringItems> GetItemsBelowThanGivenScreenSize(string screenSize, List<MonitoringItems> monitoringItems)
        {
            List<MonitoringItems> finalItemWithScreenSizeBelowCategory = new List<MonitoringItems>();
            for (int i = 0; i < monitoringItems.Count; i++)
            {
                if (float.Parse(monitoringItems[i].ScreenSize) <= float.Parse(screenSize))
                    finalItemWithScreenSizeBelowCategory.Add(monitoringItems[i]);
            }
            return finalItemWithScreenSizeBelowCategory;
        }
    }
}
