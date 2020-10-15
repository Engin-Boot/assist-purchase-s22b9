using System;
using System.Collections.Generic;
using AssistAPurchase.Models;

namespace AssistAPurchase.AssistAPurchase.DataBase
{
    public class MonitoringProductsGetter
    {
        public List<MonitoringItems> Products { get; private set; }

        public MonitoringProductsGetter() {

            this.GetAllItems();
            Console.WriteLine(Products.Count);

        }
        private void GetAllItems()
        {
            List<MonitoringItems> monitoringItems = new List<MonitoringItems>
            {
                new MonitoringItems
                {
                    ProductNumber = "X3",
                    ProductName = "IntelliVue",
                    Description =
                        "The Philips IntelliVue X3 is a compact, dual-purpose, transport patient monitor featuring intuitive smartphone-style operation and offering a scalable set of clinical measurements.",
                    ProductSpecficTraining = "NO",
                    Price = "14500",
                    Wearable = "NO",
                    SoftwareUpdateSupport = "YES",
                    Portability = "YES",
                    Compact = "YES",
                    BatterySupport = "NO",
                    ThirdPartyDeviceSupport = "YES",
                    SafeToFlyCertification = "NO",
                    TouchScreenSupport = "YES",
                    ScreenSize = "6.1",
                    MultiPatientSupport = "NO",
                    CyberSecurity = "NO"
                },
                new MonitoringItems
                {
                    ProductNumber = "MX40",
                    ProductName = "IntelliVue",
                    Description =
                        "The IntelliVue MX40 patient wearable monitor gives you technology, intelligent design, and innovative features you expect from Philips – in a device light enough and small enough to be comfortably worn by ambulatory patients.",
                    ProductSpecficTraining = "YES",
                    Price = "37000",
                    Wearable = "YES",
                    SoftwareUpdateSupport = "NO",
                    Portability = "YES",
                    Compact = "YES",
                    BatterySupport = "YES",
                    ThirdPartyDeviceSupport = "NO",
                    SafeToFlyCertification = "YES",
                    TouchScreenSupport = "YES",
                    ScreenSize = "2.8",
                    MultiPatientSupport = "NO",
                    CyberSecurity = "NO"
                },
                new MonitoringItems
                {
                    ProductNumber = "MX750",
                    ProductName = "IntelliVue",
                    Description =
                        "The Philips IntelliVue MX750 bedside patient monitor directly addresses the evolving security needs of the healthcare IT landscape, with a range of capabilities that support your cybersecurity strategies. In addition, this outstanding monitor offers advanced functionality and an extensive range of measurements",
                    ProductSpecficTraining = "NO",
                    Price = "50000",
                    Wearable = "NO",
                    SoftwareUpdateSupport = "YES",
                    Portability = "NO",
                    Compact = "NO",
                    BatterySupport = "NO",
                    ThirdPartyDeviceSupport = "NO",
                    SafeToFlyCertification = "NO",
                    TouchScreenSupport = "YES",
                    ScreenSize = "19",
                    MultiPatientSupport = "NO",
                    CyberSecurity = "YES"
                },
                new MonitoringItems
                {
                    ProductNumber = "MP2",
                    ProductName = "IntelliVue",
                    Description =
                        "The IntelliVue MP2 is a remarkably light, flexible, and durable wearable transport monitor that’s easy to use during transport or in low acuity settings, both in and out of the hospital.",
                    ProductSpecficTraining = "NO",
                    Price = "60000",
                    Wearable = "YES",
                    SoftwareUpdateSupport = "NO",
                    Portability = "YES",
                    Compact = "YES",
                    BatterySupport = "NO",
                    ThirdPartyDeviceSupport = "NO",
                    SafeToFlyCertification = "YES",
                    TouchScreenSupport = "YES",
                    ScreenSize = "3.5",
                    MultiPatientSupport = "NO",
                    CyberSecurity = "NO"
                },
                new MonitoringItems
                {
                    ProductNumber = "MP5",
                    ProductName = "IntelliVue",
                    Description =
                        "Philips IntelliVue MP5 bedside patient monitor provides actionable information about your patients. It delivers IntelliVue monitoring power and functionality in a compact, rugged housing to serve a wide range of care environments.",
                    ProductSpecficTraining = "YES",
                    Price = "38599",
                    Wearable = "NO",
                    SoftwareUpdateSupport = "NO",
                    Portability = "NO",
                    Compact = "YES",
                    BatterySupport = "NO",
                    ThirdPartyDeviceSupport = "NO",
                    SafeToFlyCertification = "NO",
                    TouchScreenSupport = "YES",
                    ScreenSize = "8.4",
                    MultiPatientSupport = "NO",
                    CyberSecurity = "NO"
                },
                new MonitoringItems
                {
                    ProductNumber = "MX450",
                    ProductName = "IntelliVue",
                    Description =
                        "The IntelliVue MX450 combines powerful monitoring with flexible portability in one compact unit. Supplying comprehensive patient information at a glance, it can make a real difference when multiple patients and priorities need attention.",
                    ProductSpecficTraining = "YES",
                    Price = "19990",
                    Wearable = "NO",
                    SoftwareUpdateSupport = "NO",
                    Portability = "YES",
                    Compact = "NO",
                    BatterySupport = "NO",
                    ThirdPartyDeviceSupport = "NO",
                    SafeToFlyCertification = "NO",
                    TouchScreenSupport = "YES",
                    ScreenSize = "12",
                    MultiPatientSupport = "YES",
                    CyberSecurity = "NO"
                },
                new MonitoringItems
                {
                    ProductNumber = "MX700",
                    ProductName = "IntelliVue",
                    Description =
                        "Philips IntelliVue MX700 bedside patient monitor offers an expanded, real-time view of your patients’ vital signs. The integrated PC (iPC) option brings a host of clinically relevant information from your hospital’s intranet & applications.",
                    ProductSpecficTraining = "YES",
                    Price = "35500",
                    Wearable = "NO",
                    SoftwareUpdateSupport = "YES",
                    Portability = "NO",
                    Compact = "NO",
                    BatterySupport = "NO",
                    ThirdPartyDeviceSupport = "YES",
                    SafeToFlyCertification = "NO",
                    TouchScreenSupport = "YES",
                    ScreenSize = "15",
                    MultiPatientSupport = "NO",
                    CyberSecurity = "NO"
                },
                new MonitoringItems
                {
                    ProductNumber = "MMSX2",
                    ProductName = "IntelliVue",
                    Description =
                        "Philips IntelliVue X2 is a combined multi-measurement module and transport monitor, ingeniously lightening the load when it comes to patient transport. Small enough and powerful enough to go virtually anywhere.",
                    ProductSpecficTraining = "NO",
                    Price = "14500",
                    Wearable = "YES",
                    SoftwareUpdateSupport = "YES",
                    Portability = "YES",
                    Compact = "YES",
                    BatterySupport = "YES",
                    ThirdPartyDeviceSupport = "YES",
                    SafeToFlyCertification = "YES",
                    TouchScreenSupport = "YES",
                    ScreenSize = "3.5",
                    MultiPatientSupport = "NO",
                    CyberSecurity = "NO"
                },
                new MonitoringItems
                {
                    ProductNumber = "MX500",
                    ProductName = "IntelliVue",
                    Description =
                        "The IntelliVue MX500 combines powerful monitoring with flexible portability in one compact unit. Supplying comprehensive patient information at a glance, it can make a real difference when multiple patients and priorities need attention.",
                    ProductSpecficTraining = "YES",
                    Price = "47999",
                    Wearable = "NO",
                    SoftwareUpdateSupport = "NO",
                    Portability = "YES",
                    Compact = "YES",
                    BatterySupport = "NO",
                    ThirdPartyDeviceSupport = "NO",
                    SafeToFlyCertification = "NO",
                    TouchScreenSupport = "YES",
                    ScreenSize = "12",
                    MultiPatientSupport = "YES",
                    CyberSecurity = "NO"
                },
                new MonitoringItems
                {
                    ProductNumber = "MP90",
                    ProductName = "IntelliVue",
                    Description =
                        "The IntelliVue MP90 patient monitor is designed for the fast-paced, highest acuity care environments. It provides event surveillance, parameter histograms, sepsis screening, and diverse clinical measurements to support informed decisions.",
                    ProductSpecficTraining = "NO",
                    Price = "37000",
                    Wearable = "NO",
                    SoftwareUpdateSupport = "NO",
                    Portability = "NO",
                    Compact = "NO",
                    BatterySupport = "NO",
                    ThirdPartyDeviceSupport = "YES",
                    SafeToFlyCertification = "NO",
                    TouchScreenSupport = "YES",
                    ScreenSize = "15",
                    MultiPatientSupport = "NO",
                    CyberSecurity = "NO"
                },
                new MonitoringItems
                {
                    ProductNumber = "MX550",
                    ProductName = "IntelliVue",
                    Description =
                        "The IntelliVue MX550 pairs powerful bedside monitoring with the reassurance of a battery backup. Supplying comprehensive patient information at a glance, it can make a real difference when multiple patients and priorities need attention.",
                    ProductSpecficTraining = "YES",
                    Price = "35999",
                    Wearable = "NO",
                    SoftwareUpdateSupport = "NO",
                    Portability = "YES",
                    Compact = "YES",
                    BatterySupport = "YES",
                    ThirdPartyDeviceSupport = "YES",
                    SafeToFlyCertification = "NO",
                    TouchScreenSupport = "YES",
                    ScreenSize = "15",
                    MultiPatientSupport = "YES",
                    CyberSecurity = "NO"
                },
                new MonitoringItems
                {
                    ProductNumber = "MX400",
                    ProductName = "IntelliVue",
                    Description =
                        "The IntelliVue MX400 provides powerful monitoring in a highly compact, highly transportable unit. Supplying comprehensive patient information at a glance, it can make a real difference when multiple patients and priorities need attention.",
                    ProductSpecficTraining = "YES",
                    Price = "37000",
                    Wearable = "NO",
                    SoftwareUpdateSupport = "YES",
                    Portability = "YES",
                    Compact = "YES",
                    BatterySupport = "NO",
                    ThirdPartyDeviceSupport = "YES",
                    SafeToFlyCertification = "NO",
                    TouchScreenSupport = "YES",
                    ScreenSize = "9",
                    MultiPatientSupport = "YES",
                    CyberSecurity = "NO"
                },
                new MonitoringItems
                {
                    ProductNumber = "MX800",
                    ProductName = "IntelliVue",
                    Description =
                        "The IntelliVue MX800 is Philips first patient care solution to incorporate patient monitoring and clinical informatics. Designed to simplify access to patient information you need to enhance diagnostic confidence throughout the hospital.",
                    ProductSpecficTraining = "YES",
                    Price = "35500",
                    Wearable = "NO",
                    SoftwareUpdateSupport = "NO",
                    Portability = "NO",
                    Compact = "NO",
                    BatterySupport = "NO",
                    ThirdPartyDeviceSupport = "YES",
                    SafeToFlyCertification = "NO",
                    TouchScreenSupport = "YES",
                    ScreenSize = "19",
                    MultiPatientSupport = "NO",
                    CyberSecurity = "NO"
                },
                new MonitoringItems
                {
                    ProductNumber = "MP5T",
                    ProductName = "IntelliVue",
                    Description =
                        "Philips IntelliVue MP5T patient monitor expands telemetry capabilities, offering parameters and functionality for vital signs spot checks, bedside monitoring, and transport.",
                    ProductSpecficTraining = "YES",
                    Price = "37000",
                    Wearable = "NO",
                    SoftwareUpdateSupport = "NO",
                    Portability = "YES",
                    Compact = "YES",
                    BatterySupport = "YES",
                    ThirdPartyDeviceSupport = "YES",
                    SafeToFlyCertification = "NO",
                    TouchScreenSupport = "YES",
                    ScreenSize = "8.4",
                    MultiPatientSupport = "NO",
                    CyberSecurity = "NO"
                },
                new MonitoringItems
                {
                    ProductNumber = "MX100",
                    ProductName = "IntelliVue",
                    Description =
                        "The MX100 is a flexible, reliable way to monitor patients on the move - and at the bedside - with a single, portable, stand-alone monitor, It is small and light, yet offers a broad, scalable set of clinical measurements. This rugged, battery-powered device features a built-in 15.5cm (6.1 inch) touchscreen and familiar smartphone-like operation for ease of use.",
                    ProductSpecficTraining = "NO",
                    Price = "15000",
                    Wearable = "YES",
                    SoftwareUpdateSupport = "YES",
                    Portability = "YES",
                    Compact = "YES",
                    BatterySupport = "YES",
                    ThirdPartyDeviceSupport = "NO",
                    SafeToFlyCertification = "YES",
                    TouchScreenSupport = "YES",
                    ScreenSize = "6.1",
                    MultiPatientSupport = "NO",
                    CyberSecurity = "NO"
                },
                new MonitoringItems
                {
                    ProductNumber = "CM",
                    ProductName = "Efficia",
                    Description =
                        "When both budget and quality matter, the choice is Efficia CM Series patient monitors. In tune with your needs, we offer a value range of patient monitors backed by our time-tested measurement algorithms.",
                    ProductSpecficTraining = "NO",
                    Price = "24599",
                    Wearable = "NO",
                    SoftwareUpdateSupport = "YES",
                    Portability = "YES",
                    Compact = "YES",
                    BatterySupport = "NO",
                    ThirdPartyDeviceSupport = "YES",
                    SafeToFlyCertification = "NO",
                    TouchScreenSupport = "YES",
                    ScreenSize = "10",
                    MultiPatientSupport = "NO",
                    CyberSecurity = "NO"
                },
                new MonitoringItems
                {
                    ProductNumber = "G40E",
                    ProductName = "Goldway",
                    Description =
                        "Clinicians need to respond swiftly to rapid changes in their patient's condition. Having a highly reliable, versatile patient monitoring solution on hand saves precious time in determining the best course of care. G40E is your choice for a cost-effective, easy to learn, pre-configured bedside monitor that provides reliable measurements (Philips ST/AR ECG and FAST-SpO₂).",
                    ProductSpecficTraining = "NO",
                    Price = "18000",
                    Wearable = "NO",
                    SoftwareUpdateSupport = "YES",
                    Portability = "YES",
                    Compact = "YES",
                    BatterySupport = "NO",
                    ThirdPartyDeviceSupport = "NO",
                    SafeToFlyCertification = "NO",
                    TouchScreenSupport = "YES",
                    ScreenSize = "12.1",
                    MultiPatientSupport = "NO",
                    CyberSecurity = "NO"
                }
            };
            this.Products = monitoringItems;
        }
    }
}
