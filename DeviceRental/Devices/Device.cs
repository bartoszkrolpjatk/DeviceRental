namespace DeviceRental.Devices;

public abstract class Device : IdentifiableObject
{
    private static readonly List<Device> AllDevices = [];
    private string Name { get; }
    public Status Status { get; private set; }
    
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

    internal void SetUnavailable()
    {
        Status = Status.Unavailable;
    }

    internal void SetRented()
    {
        Status = Status.Rented;
    }

    internal void SetAvailable()
    {
        Status = Status.Available;
    }

    public override string ToString()
    {
        return $"{base.ToString()} Device[ Name: {Name}, Status: {Status}]";
    }
}