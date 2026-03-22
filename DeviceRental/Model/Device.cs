namespace DeviceRental.Model;

public abstract class Device : IdentifiableObject
{
    private string Name { get; }
    public Status Status { get; set; }
    
    protected Device(string name, Status status) : base()
    {
        Name = name;
        Status = Status.Available;
    }

    public override string ToString()
    {
        return $"{base.ToString()} Device[ Name: {Name}, Status: {Status}]";
    }
}