using DemoBlazor.Data;
using DemoBlazor.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace DemoBlazor.Pages
{
    partial class Devices
    {



        [Inject]
        public DeviceService? DeviceService { get; set; }

        /// <summary>
        /// Object to store the collection of Devices
        /// </summary>
        private List<Device> LstDevices = new();

        /// <summary>
        /// Classes Object to store the add/edit classes data.
        /// </summary>
        private Device Device { get; set; } = new();

        List<DeviceType> LstDevicesType = new();

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
            LstDevices = await DeviceService.InitializeDevicesAsync();
            LstDevicesType = Enum.GetValues(typeof(DeviceType)).Cast<DeviceType>().ToList();
        }

       
      
        /// <summary>
        /// Method to delete a record from Operation List. 
        /// </summary>
        /// <param name="id"></param>
        protected void Delete(Device Device)
        {

                LstDevices.Remove(Device);
                StateHasChanged();
            

        }

    }




}
