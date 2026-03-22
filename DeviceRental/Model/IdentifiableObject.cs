namespace DeviceRental.Model;

public abstract class IdentifiableObject
{
    private static int _objectCounter;
    
    private int _id;
    
    protected IdentifiableObject()
    {
        _id = _objectCounter++;
    }
}