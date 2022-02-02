namespace DemoBlazor.Model
{
    public class Operation
    {
        public int OperationID { get; set; }
        public string? Name { get; set; }
        public int OrderInWhichToPerform { get; set; }
        public byte[]? ImageData { get; set; }
        public Device? Device { get; set; }
    }

    public class Device
    {
        public int DeviceID { get; set; }
        public string? Name { get; set; }
        public DeviceType DeviceType { get; set; }
    }
    public enum DeviceType
    {
        BarcodeScanner,
        Printer,
        Camera,
        SocketTray
    }


}
