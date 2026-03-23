using DeviceRental.Model;

namespace DeviceRental.Service;

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