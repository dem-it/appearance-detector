using System.Management;

namespace AppearanceDetector
{
    public class MonitorController
    {
        public static void SetMonitorBrightness(byte brightness)
        {
            try
            {
                ManagementScope scope = new ManagementScope("root\\WMI");
                SelectQuery query = new SelectQuery("WmiMonitorBrightnessMethods");

                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query))
                {
                    using (ManagementObjectCollection objectCollection = searcher.Get())
                    {
                        foreach (ManagementObject mObj in objectCollection)
                        {
                            mObj.InvokeMethod("WmiSetBrightness", new object[] { uint.MaxValue, brightness });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error setting monitor brightness: {ex.Message}");
            }
        }
    }
}
