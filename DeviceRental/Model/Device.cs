namespace DeviceRental.Model;

public abstract class Device : IdentifiableObject
{
    private string _name;
    private Status _status;
    
    protected Device(string name, Status status) : base()
    {
        _name = name;
        _status = status;
    }
}