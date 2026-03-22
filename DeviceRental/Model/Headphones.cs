namespace DeviceRental.Model;

public class Headphones : Device
{
    private bool Wireless { get; }
    private bool HasMicrophone { get; }
    
    public Headphones(string name, Status status, bool wireless, bool hasMicrophone) : base(name, status)
    {
        Wireless = wireless;
        HasMicrophone = hasMicrophone;
    }

    public override string ToString()
    {
        return $"{base.ToString()} Headphones: [Wireless:  {Wireless}, HasMicrophone: {HasMicrophone}]";
    }
}