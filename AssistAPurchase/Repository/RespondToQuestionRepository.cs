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
            for (int i = 0; i < monitoringItems.Count; i++)
            {
                if (monitoringItems[i].Compact == compactValue)
                {
                    finalItemWithCompactCategory.Add(monitoringItems[i]);
                }
            }
            return finalItemWithCompactCategory;
        }

        public string GetDescription(string productNumber)
        {
            MonitoringItems monitoringItem= Find(productNumber);
            if (monitoringItem == null)
                return null;
            return monitoringItem.Description;
        }

        public IEnumerable<MonitoringItems> FindByProductSpecificTrainingCategory(string productSpecificTrainingvalue)
        {
            List<MonitoringItems> finalItemWithProductSpecificTrainingCategory = new List<MonitoringItems>();
            for (int i = 0; i < monitoringItems.Count; i++)
            {
                if (monitoringItems[i].ProductSpecficTraining == productSpecificTrainingvalue)
                {
                    finalItemWithProductSpecificTrainingCategory.Add(monitoringItems[i]);
                }
            }
            return finalItemWithProductSpecificTrainingCategory;
        }

        public IEnumerable<MonitoringItems> FindByPriceCategory(string amount, string belowOrAbove) 
        {
            if (belowOrAbove == "ABOVE")
             return ProductConfigureSupporterFunctions.GetItemsAboveThanGivenPrice(amount, monitoringItems);
            return ProductConfigureSupporterFunctions.GetItemsBelowThanGivenPrice(amount, monitoringItems);
        }
        public IEnumerable<MonitoringItems> FindByWearableCategory(string wearableCategoryvalue){

            List<MonitoringItems> finalItemWithWearableCategory = new List<MonitoringItems>();
            for (int i = 0; i < monitoringItems.Count; i++)
            {
                if (monitoringItems[i].Wearable == wearableCategoryvalue)
                {
                    finalItemWithWearableCategory.Add(monitoringItems[i]);
                }
            }
            return finalItemWithWearableCategory;
        }

        public IEnumerable<MonitoringItems> FindBySoftwareUpdateSupportCategory(string softwareUpdateSupportvalue)
        {
            List<MonitoringItems> finalItemWithSoftwareUpdateSupportCategory = new List<MonitoringItems>();
            for (int i = 0; i < monitoringItems.Count; i++)
            {
                if (monitoringItems[i].SoftwareUpdateSupport == softwareUpdateSupportvalue)
                {
                    finalItemWithSoftwareUpdateSupportCategory.Add(monitoringItems[i]);
                }
            }
            return finalItemWithSoftwareUpdateSupportCategory;
        }

        public IEnumerable<MonitoringItems> FindByPortabilityCategory(string portabilityCategoryValue)
        {
            List<MonitoringItems> finalItemWithPortabilityCategory = new List<MonitoringItems>();
            for (int i = 0; i < monitoringItems.Count; i++)
            {
                if (monitoringItems[i].Portability == portabilityCategoryValue)
                {
                    finalItemWithPortabilityCategory.Add(monitoringItems[i]);
                }
            }
            return finalItemWithPortabilityCategory;
        }
        public IEnumerable<MonitoringItems> FindByBatterySupportCategory(string batterySupportCategoryValue)
        {
            List<MonitoringItems> finalItemWithBatterySupportCategory = new List<MonitoringItems>();
            for (int i = 0; i < monitoringItems.Count; i++)
            {
                if (monitoringItems[i].BatterySupport == batterySupportCategoryValue)
                {
                    finalItemWithBatterySupportCategory.Add(monitoringItems[i]);
                }
            }
            return finalItemWithBatterySupportCategory;
        }

        public IEnumerable<MonitoringItems> FindByThirdPartyDeviceSupportCategory(string thirdPartyDeviceSupportCategoryValue)
        {
            List<MonitoringItems> finalItemWithThirdPartyDeviceSupportCategory = new List<MonitoringItems>();
            for (int i = 0; i < monitoringItems.Count; i++)
            {
                if (monitoringItems[i].ThirdPartyDeviceSupport == thirdPartyDeviceSupportCategoryValue)
                {
                    finalItemWithThirdPartyDeviceSupportCategory.Add(monitoringItems[i]);
                }
            }
            return finalItemWithThirdPartyDeviceSupportCategory;
        }

        public IEnumerable<MonitoringItems> FindBySafeToFlyCertificationCategory(string safeToFlyCertificationCategoryValue)
        {
            List<MonitoringItems> finalItemWithSafeToFlyCertificationCategory = new List<MonitoringItems>();
            for (int i = 0; i < monitoringItems.Count; i++)
            {
                if (monitoringItems[i].SafeToFlyCertification == safeToFlyCertificationCategoryValue)
                {
                    finalItemWithSafeToFlyCertificationCategory.Add(monitoringItems[i]);
                }
            }
            return finalItemWithSafeToFlyCertificationCategory;
        }
        public IEnumerable<MonitoringItems> FindByTouchScreenSupportCategory(string touchScreenSupportCategoryValue)
        {
            List<MonitoringItems> finalItemWithTouchScreenSupportCategory = new List<MonitoringItems>();
            for (int i = 0; i < monitoringItems.Count; i++)
            {
                if (monitoringItems[i].TouchScreenSupport == touchScreenSupportCategoryValue)
                {
                    finalItemWithTouchScreenSupportCategory.Add(monitoringItems[i]);
                }
            }
            return finalItemWithTouchScreenSupportCategory;
        }

        public IEnumerable<MonitoringItems> FindByScreenSizeCategory(string screenSize, string belowOrAbove)
        {
            if (belowOrAbove == "ABOVE")
                return ProductConfigureSupporterFunctions.GetItemsAboveThanGivenScreenSize(screenSize,monitoringItems);
            return ProductConfigureSupporterFunctions.GetItemsBelowThanGivenScreenSize(screenSize, monitoringItems);
        }

        public IEnumerable<MonitoringItems> FindByMultiPatientSupportCategory(string multiPatientSupportCategoryValue)
        {
            List<MonitoringItems> finalItemWithMultiPatientSupportCategory = new List<MonitoringItems>();
            for (int i = 0; i < monitoringItems.Count; i++)
            {
                if (monitoringItems[i].MultiPatientSupport == multiPatientSupportCategoryValue)
                {
                    finalItemWithMultiPatientSupportCategory.Add(monitoringItems[i]);
                }
            }
            return finalItemWithMultiPatientSupportCategory;
        }

        public IEnumerable<MonitoringItems> FindByCyberSecuritytCategory(string cyberSecurityCategoryValue)
        {
            List<MonitoringItems> finalItemWithCyberSecurityCategory = new List<MonitoringItems>();
            for (int i = 0; i < monitoringItems.Count; i++)
            {
                if (monitoringItems[i].CyberSecurity == cyberSecurityCategoryValue)
                {
                    finalItemWithCyberSecurityCategory.Add(monitoringItems[i]);
                }
            }
            return finalItemWithCyberSecurityCategory;
        }

    }
}
