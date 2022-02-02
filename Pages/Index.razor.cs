using DemoBlazor.Data;
using DemoBlazor.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace DemoBlazor.Pages
{
    partial class Index
    {

        [Inject]
        public OperationService? OperationService { get; set; }


        [Inject]
        public DeviceService? DeviceService { get; set; }


        /// <summary>
        /// Object to store the collection of Operation
        /// </summary>
        private List<Operation> LstOperation = new();

        /// <summary>
        /// DeviceType enum list.
        /// </summary>
        List<DeviceType> LstDevicesType = new();

        /// <summary>
        /// Object to store the collection of Devices
        /// </summary>
        private List<Device> LstDevices = new();

        /// <summary>
        /// Classes Object to store the add/edit classes data.
        /// </summary>
        private Operation Operation { get; set; } = new();

        /// <summary>
        /// Classes Object to store the add/edit classes data.
        /// </summary>
        private Device Device { get; set; } = new();

        byte[]? OperationImage;

       /// <summary>
       /// Method to upload the image.
       /// </summary>
       /// <param name="e"></param>
       /// <returns></returns>
       private async Task UploadImage(InputFileChangeEventArgs e)
        {
            long maxFileSize = 5120000;
            foreach (var file in e.GetMultipleFiles(1))
            {

                
                var buffers = new byte[file.Size];
                await file.OpenReadStream(maxFileSize).ReadAsync(buffers);
                
                OperationImage = buffers;
                Operation.ImageData = OperationImage;
            }
        }
        /// <summary>
        /// Method to save the operation
        /// </summary>
        private void SaveOperation()
        {
            LstOperation.Insert(0, Operation);
            Operation = new();
            StateHasChanged();
        }


        /// <summary>
        /// Method to save the device
        /// </summary>
        private void SaveDevice()
        {
            LstDevices.Insert(0, Device);
            Device = new();
            StateHasChanged();
        }

        /// <summary>
        /// Method which will initialized when component will load and list 10 default operations
        /// </summary>
        protected override async Task OnInitializedAsync()
        {
            LstOperation = await OperationService.InitializeOperationsAsync();
            LstDevices = await DeviceService.InitializeDevicesAsync();
            LstDevicesType = Enum.GetValues(typeof(DeviceType)).Cast<DeviceType>().ToList();
        }

       
      
        /// <summary>
        /// Method to delete a record from Operation List. 
        /// </summary>
        /// <param name="id"></param>
        protected void Delete(Operation Operation)
        {

                LstOperation.Remove(Operation);
                StateHasChanged();
            

        }

    }




}
