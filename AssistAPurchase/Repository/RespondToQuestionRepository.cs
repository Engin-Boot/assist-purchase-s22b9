using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using AssistAPurchase.Models;
using AssistAPurchase.SupportingFunctions;
namespace AssistAPurchase.Repository
{
    public class RespondToQuestionRepository : MonitoringProductRepository, IRespondToQuestionRepository
    {

        public IEnumerable<MonitoringItems> GetAllProduct()
        {
            return GetAll();
        }
        public IEnumerable<MonitoringItems> FindByCompactCategory(string compactValue)
        {
            List<MonitoringItems> finalItemWithCompactCategory = new List<MonitoringItems>();
            foreach (MonitoringItems item in MonitoringItems)
            {
                if (item.Compact == compactValue)
                {
                    finalItemWithCompactCategory.Add(item);
                }
            }
            return finalItemWithCompactCategory;
        }

        public string GetDescription(string productNumber)
        {
            MonitoringItems monitoringItem = Find(productNumber);
            return monitoringItem?.Description;
        }

        public IEnumerable<MonitoringItems> FindByProductSpecificTrainingCategory(string productSpecificTrainingvalue)
        {
            List<MonitoringItems> finalItemWithProductSpecificTrainingCategory = new List<MonitoringItems>();
            foreach (MonitoringItems item in MonitoringItems)
            {
                if (item.ProductSpecficTraining == productSpecificTrainingvalue)
                {
                    finalItemWithProductSpecificTrainingCategory.Add(item);
                }
            }
            return finalItemWithProductSpecificTrainingCategory;
        }

        public IEnumerable<MonitoringItems> FindByPriceCategory(string amount, string belowOrAbove)
        {
            if (belowOrAbove == "ABOVE")
                return ProductConfigureSupporterFunctions.GetItemsAboveThanGivenPrice(amount, MonitoringItems);
            return ProductConfigureSupporterFunctions.GetItemsBelowThanGivenPrice(amount, MonitoringItems);
        }
        public IEnumerable<MonitoringItems> FindByWearableCategory(string wearableCategoryvalue) {

            List<MonitoringItems> finalItemWithWearableCategory = new List<MonitoringItems>();
            foreach (MonitoringItems item in MonitoringItems)
            {
                if (item.Wearable == wearableCategoryvalue)
                {
                    finalItemWithWearableCategory.Add(item);
                }
            }
            return finalItemWithWearableCategory;
        }

        public IEnumerable<MonitoringItems> FindBySoftwareUpdateSupportCategory(string softwareUpdateSupportvalue)
        {
            List<MonitoringItems> finalItemWithSoftwareUpdateSupportCategory = new List<MonitoringItems>();
            foreach (MonitoringItems item in MonitoringItems)
            {
                if (item.SoftwareUpdateSupport == softwareUpdateSupportvalue)
                {
                    finalItemWithSoftwareUpdateSupportCategory.Add(item);
                }
            }
            return finalItemWithSoftwareUpdateSupportCategory;
        }

        public IEnumerable<MonitoringItems> FindByPortabilityCategory(string portabilityCategoryValue)
        {
            List<MonitoringItems> finalItemWithPortabilityCategory = new List<MonitoringItems>();
            foreach (MonitoringItems item in MonitoringItems)
            {
                if (item.Portability == portabilityCategoryValue)
                {
                    finalItemWithPortabilityCategory.Add(item);
                }
            }
            return finalItemWithPortabilityCategory;
        }
        public IEnumerable<MonitoringItems> FindByBatterySupportCategory(string batterySupportCategoryValue)
        {
            List<MonitoringItems> finalItemWithBatterySupportCategory = new List<MonitoringItems>();
            foreach (MonitoringItems item in MonitoringItems)
            {
                if (item.BatterySupport == batterySupportCategoryValue)
                {
                    finalItemWithBatterySupportCategory.Add(item);
                }
            }
            return finalItemWithBatterySupportCategory;
        }

        public IEnumerable<MonitoringItems> FindByThirdPartyDeviceSupportCategory(string thirdPartyDeviceSupportCategoryValue)
        {
            List<MonitoringItems> finalItemWithThirdPartyDeviceSupportCategory = new List<MonitoringItems>();
            foreach (MonitoringItems item in MonitoringItems)
            {
                if (item.ThirdPartyDeviceSupport == thirdPartyDeviceSupportCategoryValue)
                {
                    finalItemWithThirdPartyDeviceSupportCategory.Add(item);
                }
            }
            return finalItemWithThirdPartyDeviceSupportCategory;
        }

        public IEnumerable<MonitoringItems> FindBySafeToFlyCertificationCategory(string safeToFlyCertificationCategoryValue)
        {
            List<MonitoringItems> finalItemWithSafeToFlyCertificationCategory = new List<MonitoringItems>();
            foreach (MonitoringItems item in MonitoringItems)
            {
                if (item.SafeToFlyCertification == safeToFlyCertificationCategoryValue)
                {
                    finalItemWithSafeToFlyCertificationCategory.Add(item);
                }
            }
            return finalItemWithSafeToFlyCertificationCategory;
        }
        public IEnumerable<MonitoringItems> FindByTouchScreenSupportCategory(string touchScreenSupportCategoryValue)
        {
            List<MonitoringItems> finalItemWithTouchScreenSupportCategory = new List<MonitoringItems>();
            foreach (MonitoringItems item in MonitoringItems)
            {
                if (item.TouchScreenSupport == touchScreenSupportCategoryValue)
                {
                    finalItemWithTouchScreenSupportCategory.Add(item);
                }
            }
            return finalItemWithTouchScreenSupportCategory;
        }

        public IEnumerable<MonitoringItems> FindByScreenSizeCategory(string screenSize, string belowOrAbove)
        {
            if (belowOrAbove == "ABOVE")
                return ProductConfigureSupporterFunctions.GetItemsAboveThanGivenScreenSize(screenSize, MonitoringItems);
            return ProductConfigureSupporterFunctions.GetItemsBelowThanGivenScreenSize(screenSize, MonitoringItems);
        }

        public IEnumerable<MonitoringItems> FindByMultiPatientSupportCategory(string multiPatientSupportCategoryValue)
        {
            List<MonitoringItems> finalItemWithMultiPatientSupportCategory = new List<MonitoringItems>();
            foreach (MonitoringItems item in MonitoringItems)
            {
                if (item.MultiPatientSupport == multiPatientSupportCategoryValue)
                {
                    finalItemWithMultiPatientSupportCategory.Add(item);
                }
            }
            return finalItemWithMultiPatientSupportCategory;
        }

        public IEnumerable<MonitoringItems> FindByCyberSecuritytCategory(string cyberSecurityCategoryValue)
        {
            List<MonitoringItems> finalItemWithCyberSecurityCategory = new List<MonitoringItems>();
            foreach (MonitoringItems item in MonitoringItems)
            {
                if (item.CyberSecurity == cyberSecurityCategoryValue)
                {
                    finalItemWithCyberSecurityCategory.Add(item);
                }
            }
            return finalItemWithCyberSecurityCategory;
        }






        private List<MonitoringItems> _filterByTouchScreen(string touchScreenValue, List<MonitoringItems> productList)
        {
            for (int item = productList.Count - 1; item >= 0; item--)
            {
                if (productList[item].TouchScreenSupport != touchScreenValue)
                {
                    productList.RemoveAt(item);
                }
            }
            return productList;
        }

        private List<MonitoringItems> _filterByProductSpecficTraining(string productSpecficTrainingValue, List<MonitoringItems> productList)
        {
            for (int item = productList.Count - 1; item >= 0; item--)
            {
                if (productList[item].ProductSpecficTraining != productSpecficTrainingValue)
                {
                    productList.RemoveAt(item);
                }
            }
            return productList;
        }
        private List<MonitoringItems> _filterByWearable(string wearableTrainingValue, List<MonitoringItems> productList)
        {
            for (int item = productList.Count - 1; item >= 0; item--)
            {
                if (productList[item].Wearable != wearableTrainingValue)
                {
                    productList.RemoveAt(item);
                }
            }
            return productList;
        }

        private List<MonitoringItems> _filterBySoftwareUpdateSupport(string softwareUpdateSupportValue, List<MonitoringItems> productList)
        {
            for (int item = productList.Count - 1; item >= 0; item--)
            {
                if (productList[item].SoftwareUpdateSupport != softwareUpdateSupportValue)
                {
                    productList.RemoveAt(item);
                }
            }
            return productList;
        }
        private List<MonitoringItems> _filterByPortability(string portabilitytValue, List<MonitoringItems> productList)
        {
            for (int item = productList.Count - 1; item >= 0; item--)
            {
                if (productList[item].Portability != portabilitytValue)
                {
                    productList.RemoveAt(item);
                }
            }
            return productList;
        }
        private List<MonitoringItems> _filterByCompact(string compactValue, List<MonitoringItems> productList)
        {
            for (int item = productList.Count - 1; item >= 0; item--)
            {
                if (productList[item].Compact != compactValue)
                {
                    productList.RemoveAt(item);
                }
            }
            return productList;
        }
        private List<MonitoringItems> _filterByBatterySupport(string batterySupportValue, List<MonitoringItems> productList)
        {
            for (int item = productList.Count - 1; item >= 0; item--)
            {
                if (productList[item].BatterySupport != batterySupportValue)
                {
                    productList.RemoveAt(item);
                }
            }
            return productList;
        }
        private List<MonitoringItems> _filterByThirdPartyDeviceSupport(string thirdPartyDeviceSupportValue, List<MonitoringItems> productList)
        {
            for (int item = productList.Count - 1; item >= 0; item--)
            {
                if (productList[item].ThirdPartyDeviceSupport != thirdPartyDeviceSupportValue)
                {
                    productList.RemoveAt(item);
                }
            }
            return productList;
        }
        private List<MonitoringItems> _filterBySafeToFlyCertification(string safeToFlyCertificationValue, List<MonitoringItems> productList)
        {
            for (int item = productList.Count - 1; item >= 0; item--)
            {
                if (productList[item].SafeToFlyCertification != safeToFlyCertificationValue)
                {
                    productList.RemoveAt(item);
                }
            }
            return productList;
        }
        private List<MonitoringItems> _filterByMultiPatientSupport(string multiPatientSupportValue, List<MonitoringItems> productList)
        {
            for (int item = productList.Count - 1; item >= 0; item--)
            {
                if (productList[item].MultiPatientSupport != multiPatientSupportValue)
                {
                    productList.RemoveAt(item);
                }
            }
            return productList;
        }
        private List<MonitoringItems> _filterByCyberSecurity(string cyberSecurityValue, List<MonitoringItems> productList)
        {
            for (int item = productList.Count - 1; item >= 0; item--)
            {
                if (productList[item].CyberSecurity != cyberSecurityValue)
                {
                    productList.RemoveAt(item);
                }
            }
            return productList;
        }
        private List<MonitoringItems> _filterByProductName(string productNameValue, List<MonitoringItems> productList)
        {
            for (int item = productList.Count - 1; item >= 0; item--)
            {
                if (productList[item].ProductName != productNameValue)
                {
                    productList.RemoveAt(item);
                }
            }
            return productList;
        }
        private List<MonitoringItems> _filterByPrice(string priceValue, List<MonitoringItems> productList)
        {
            for (int item = productList.Count - 1; item >= 0; item--)
            {
                if (float.Parse(productList[item].Price) >= float.Parse(priceValue))
                {
                    productList.RemoveAt(item);
                }
            }
            return productList;
        }
        private List<MonitoringItems> _filterByScreenSize(string screenSize, List<MonitoringItems> productList)
        {
            for (int item = productList.Count - 1; item >= 0; item--)
            {
                if (float.Parse(productList[item].ScreenSize) <= float.Parse(screenSize))
                {
                    productList.RemoveAt(item);
                }
            }
            return productList;
        }

        private List<MonitoringItems> _ifBatteryFilter(string value, List<MonitoringItems> product)
        {
            if (value!=null)
                _filterByBatterySupport(value, product);
            return product;
        }
        private List<MonitoringItems> _ifProductSpecficTrainingFilter(string value, List<MonitoringItems> product)
        {
            if (value !=null)
                _filterByProductSpecficTraining(value, product);
            return product;
        }
        private List<MonitoringItems> _ifWearableFilter(string value, List<MonitoringItems> product)
        {
            if (value !=null)
                _filterByWearable(value, product);
            return product;
        }
        private List<MonitoringItems> _ifSoftwareUpdateSupportFilter(string value, List<MonitoringItems> product)
        {
            if (value !=null)
                _filterBySoftwareUpdateSupport(value, product);
            return product;
        }
        private List<MonitoringItems> _ifPortabilityFilter(string value, List<MonitoringItems> product)
        {
            if (value !=null)
                _filterByPortability(value, product);
            return product;
        }
        private List<MonitoringItems> _ifThirdPartyDeviceSupportFilter(string value, List<MonitoringItems> product)
        {
            if (value !=null)
                _filterByThirdPartyDeviceSupport(value, product);
            return product;
        }
        private List<MonitoringItems> _ifSafeToFlyCertificationFilter(string value, List<MonitoringItems> product)
        {
            if (value !=null)
                _filterBySafeToFlyCertification(value, product);
            return product;
        }
        private List<MonitoringItems> _ifMultiPatientSupportFilter(string value, List<MonitoringItems> product)
        {
            if (value !=null)
                _filterByMultiPatientSupport(value, product);
            return product;
        }
        private List<MonitoringItems> _ifCompactFilter(string value, List<MonitoringItems> product)
        {
            if (value !=null)
                _filterByCompact(value, product);
            return product;
        }
        private List<MonitoringItems> _ifTouchScreenFilter(string value, List<MonitoringItems> product)
        {
            if (value !=null)
                _filterByTouchScreen(value, product);
            return product;
        }
        private List<MonitoringItems> _ifCyberSecurityFilter(string value, List<MonitoringItems> product)
        {
            if (value !=null)
                _filterByCyberSecurity(value, product);
            return product;
        }
        private List<MonitoringItems> _ifProductNameFilter(string value, List<MonitoringItems> product)
        {
            if (value != null)
                _filterByProductName(value, product);
            return product;
        }
        private List<MonitoringItems> _ifPriceFilter(string value, List<MonitoringItems> product)
        {
            if (value != null)
                _filterByPrice(value, product);
            return product;
        }
        private List<MonitoringItems> _ifScreenSizeFilter(string value, List<MonitoringItems> product)
        {
            if (value != null)
                _filterByScreenSize(value, product);
            return product;
        }
        public List<MonitoringItems> FilterByCategory(MonitoringItems category)
        {
            var productRepo = new MonitoringProductRepository();
            List<MonitoringItems> product = productRepo.GetAll();
            
                product = _ifProductSpecficTrainingFilter(category.ProductSpecficTraining, product);
                product = _ifWearableFilter(category.Wearable, product);
                product = _ifSoftwareUpdateSupportFilter(category.SoftwareUpdateSupport, product);
                product = _ifPortabilityFilter(category.Portability, product);
                product = _ifCompactFilter(category.Compact, product);
                product = _ifBatteryFilter(category.BatterySupport, product);
                product = _ifThirdPartyDeviceSupportFilter(category.ThirdPartyDeviceSupport, product);
                product = _ifSafeToFlyCertificationFilter(category.SafeToFlyCertification, product);
                product = _ifTouchScreenFilter(category.TouchScreenSupport, product);
                product = _ifMultiPatientSupportFilter(category.MultiPatientSupport, product);
                product = _ifCyberSecurityFilter(category.CyberSecurity, product);
                product = _ifProductNameFilter(category.ProductName, product);
                product = _ifPriceFilter(category.Price, product);
                product = _ifScreenSizeFilter(category.ScreenSize, product);
            return product;
        }
    }
}

