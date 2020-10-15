using System.Collections.Generic;
using AssistAPurchase.Models;
using AssistAPurchase.SupportingFunctions;
namespace AssistAPurchase.Repository
{
    public class RespondToQuestionRepository :MonitoringProductRepository, IRespondToQuestionRepository
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
            MonitoringItems monitoringItem= Find(productNumber);
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
        public IEnumerable<MonitoringItems> FindByWearableCategory(string wearableCategoryvalue){

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
                return ProductConfigureSupporterFunctions.GetItemsAboveThanGivenScreenSize(screenSize,MonitoringItems);
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

    }
}
