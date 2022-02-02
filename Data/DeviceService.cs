using DemoBlazor.Model;

namespace DemoBlazor.Data
{
    public class DeviceService
    {
        /// <summary>
        /// Service to initialized the 5 initial devices record. 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Device>> InitializeDevicesAsync()
        {
            List<Device> LstDevice = new List<Device>();
            Device Device;
            var httpClient = new HttpClient();
            for (int i = 1; i <6; i++)
            {
               
                Device = new Device();
                switch (i)
                {
                    case 1:
                  Device.DeviceType = DeviceType.BarcodeScanner;
                        break;
                    case 2:
                        Device.DeviceType = DeviceType.Camera;
                        break;
                    case 3:
                        Device.DeviceType = DeviceType.Printer;
                        break;
                    case 4:
                        Device.DeviceType = DeviceType.SocketTray;
                        break;
                    case 5:
                        Device.DeviceType = DeviceType.BarcodeScanner;
                        break;
                }
                    
                Device.DeviceID = i;
                Device.Name = "Device " + i;
                
                LstDevice.Add(Device);
            }

            return LstDevice;

        }
    }
}
