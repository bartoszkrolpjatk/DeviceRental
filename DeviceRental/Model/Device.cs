namespace DeviceRental.Model;

public abstract class Device : IdentifiableObject
{
    private static readonly List<Device> AllDevices = [];
    private string Name { get; }
    public Status Status { get; set; }
    
    protected Device(string name) : base()
    {
        Name = name;
        Status = Status.Available;
        AllDevices.Add(this);
    }

    public static List<Device> GetAllDevices()
    {
        return [..AllDevices];        
    }

    public override string ToString()
    {
        return $"{base.ToString()} Device[ Name: {Name}, Status: {Status}]";
    }
}