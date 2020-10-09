using AssistAPurchase.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AssistAPurchase.Repository
{
    public interface IRespondToQuestionRepository
    {
        IEnumerable<MonitoringItems> FindByCompactCategory(string compact);
        IEnumerable<MonitoringItems> GetAllProduct();
        string GetDescription(string productNumber);
        IEnumerable<MonitoringItems> FindByProductSpecificTrainingCategory(string productSpecificTrainingvalue);
        IEnumerable<MonitoringItems> FindByPriceCategory(string amount,string belowOrAbove);
        IEnumerable<MonitoringItems> FindByWearableCategory(string wearableCategoryvalue);
        IEnumerable<MonitoringItems> FindBySoftwareUpdateSupportCategory(string softwareUpdateSupportvalue);
        IEnumerable<MonitoringItems> FindByPortabilityCategory(string findByPortabilityCategoryValue);

    }
}
