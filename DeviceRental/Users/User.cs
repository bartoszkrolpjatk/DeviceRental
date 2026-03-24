namespace DeviceRental.Users;

public abstract class User : IdentifiableObject
{
    private string FirstName { get; }
    private string LastName { get; }

    protected User(string firstName, string lastName) : base()
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public abstract int GetDeviceLimit();

    public override string ToString()
    {
        return $"{base.ToString()} User[FirstName: {FirstName}, LastName: {LastName}]";
    }
}