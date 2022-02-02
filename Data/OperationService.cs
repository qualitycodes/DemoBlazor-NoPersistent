using DemoBlazor.Model;
using System.Net;

namespace DemoBlazor.Data
{
    public class OperationService
    {
        
        /// <summary>
        /// Service to initialized the 10 initial operations record. 
        /// </summary>
        /// <returns></returns>
        public  async Task<List<Operation>> InitializeOperationsAsync()
        {
            List<Operation> lstOperations = new List<Operation>();
            Operation operation;
            var httpClient = new HttpClient();
            for (int i = 1; i < 11; i++)
            {
                operation = new Operation();
                operation.Device = new Device { DeviceID = i, DeviceType = DeviceType.BarcodeScanner, Name = "Device-" + i };
                operation.Name = "Operation-" + i;
                operation.OperationID = i;
                operation.OrderInWhichToPerform = i;
                
                byte[] imageBytes = await httpClient.GetByteArrayAsync("https://ieventrics.blob.core.windows.net/itrics/Jaipur-Mumbai.jpg");
                operation.ImageData = imageBytes;
                lstOperations.Add(operation);
            }
            
            return lstOperations;
        
        }
    }
}
