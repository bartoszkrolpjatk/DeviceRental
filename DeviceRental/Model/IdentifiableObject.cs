namespace DeviceRental.Model;

public abstract class IdentifiableObject
{
    private static int _objectCounter;

    private int Id { get; }

    protected IdentifiableObject()
    {
        Id = ++_objectCounter;
    }

    public override string ToString()
    {
        return $"IdentifiableObject[Id: {Id.ToString()}]";
    }
}