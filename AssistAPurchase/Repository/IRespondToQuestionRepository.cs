using AssistAPurchase.Models;
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
        IEnumerable<MonitoringItems> FindByPortabilityCategory(string portabilityCategoryValue);
        IEnumerable<MonitoringItems> FindByBatterySupportCategory(string batterySupportCategoryValue);
        IEnumerable<MonitoringItems> FindByThirdPartyDeviceSupportCategory(string thirdPartyDeviceSupportCategoryValue);
        IEnumerable<MonitoringItems> FindBySafeToFlyCertificationCategory(string safeToFlyCertificationCategoryValue);
        IEnumerable<MonitoringItems> FindByTouchScreenSupportCategory(string touchScreenSupportCategoryValue);
        IEnumerable<MonitoringItems> FindByScreenSizeCategory(string screenSize, string belowOrAbove);
        IEnumerable<MonitoringItems> FindByMultiPatientSupportCategory(string multiPatientSupportCategoryValue);
        IEnumerable<MonitoringItems> FindByCyberSecuritytCategory(string cyberSecurityCategoryValue);
        List<MonitoringItems> FilterByCategory(MonitoringItems categoryDict);

    }
}
