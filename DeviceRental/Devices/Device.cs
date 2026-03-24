namespace DeviceRental.Devices;

public abstract class Device : IdentifiableObject
{
    private static readonly List<Device> AllDevices = [];
    private string Name { get; }
    public Status Status { get; internal set; }
    
    protected Device(string name) : base()
    {
        Name = name;
        Status = Status.Available;
        AllDevices.Add(this);
    }

    internal static List<Device> GetAllDevices()
    {
        return [..AllDevices];        
    }

    internal abstract decimal GetBrokenDeviceFee();

    public override string ToString()
    {
        return $"{base.ToString()} Device[ Name: {Name}, Status: {Status}]";
    }
}