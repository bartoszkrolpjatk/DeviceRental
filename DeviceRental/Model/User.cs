namespace DeviceRental.Model;

public abstract class User : IdentifiableObject
{
    private string _firstName;
    private string _lastName;

    protected User(string firstName, string lastName) : base()
    {
        _firstName = firstName;
        _lastName = lastName;
    }
}