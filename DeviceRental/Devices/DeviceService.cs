namespace DeviceRental.Devices;

public class DeviceService
{
    public void ShowDevices()
    {
        foreach (var device in Device.GetAllDevices())
        {
            Console.WriteLine(device);
        }
    }
}