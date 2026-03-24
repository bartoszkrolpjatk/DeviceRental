namespace DeviceRental.Devices;

public class DeviceService
{
    public void ShowDevices(Status? status = null)
    {
        foreach (var device in Device.GetAllDevices().Where(d => status == null || d.Status == status))
        {
            Console.WriteLine(device);
        }
    }
}