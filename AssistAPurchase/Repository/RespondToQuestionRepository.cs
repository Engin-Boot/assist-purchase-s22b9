using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using AssistAPurchase.Models;
using AssistAPurchase.DataBase;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;

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
            else
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
            List<MonitoringItems> finalItemWithPriceAboveCategory = new List<MonitoringItems>();
            List<MonitoringItems> finalItemWithPriceBelowCategory = new List<MonitoringItems>();
            for (int i = 0; i < monitoringItems.Count; i++)
                {
                if (float.Parse(monitoringItems[i].Price) <= float.Parse(amount))
                    finalItemWithPriceBelowCategory.Add(monitoringItems[i]);
                else
                    finalItemWithPriceAboveCategory.Add(monitoringItems[i]);
                }

            if (belowOrAbove == "ABOVE")
                return finalItemWithPriceAboveCategory;

            return finalItemWithPriceBelowCategory;
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

        public IEnumerable<MonitoringItems> FindByPortabilityCategory(string findByPortabilityCategoryValue)
        {
            List<MonitoringItems> finalItemWithPortabilityCategory = new List<MonitoringItems>();
            for (int i = 0; i < monitoringItems.Count; i++)
            {
                if (monitoringItems[i].Portability == findByPortabilityCategoryValue)
                {
                    finalItemWithPortabilityCategory.Add(monitoringItems[i]);
                }
            }
            return finalItemWithPortabilityCategory;

        }

    }
}
