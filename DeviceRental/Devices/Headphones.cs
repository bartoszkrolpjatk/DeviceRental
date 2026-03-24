namespace DeviceRental.Devices;

public class Headphones : Device
{
    private bool Wireless { get; }
    private bool HasMicrophone { get; }
    
    public Headphones(string name, bool wireless, bool hasMicrophone) : base(name)
    {
        Wireless = wireless;
        HasMicrophone = hasMicrophone;
    }

    public override decimal GetBrokenDeviceFee()
    {
        return 500;
    }

    public override string ToString()
    {
        return $"{base.ToString()} Headphones: [Wireless:  {Wireless}, HasMicrophone: {HasMicrophone}]";
    }
}