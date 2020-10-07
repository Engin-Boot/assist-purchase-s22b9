using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AssistAPurchase.Models;
using AssistAPurchase.Repository;


namespace AssistAPurchase.SupportingFunctions
{
    public class ProductConfigureSupporterFunctions
    {
        public static bool CheckForNullOrMisMatchProductNumber(MonitoringItems product, string productNumber)
        {
            if (product == null || product.ProductNumber != productNumber)
                return true;
            else
                return false;
        }
    }
}
