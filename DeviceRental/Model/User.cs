namespace DeviceRental.Model;

public abstract class User : IdentifiableObject
{
    public string FirstName { get; }
    public string LastName { get; }

    protected User(string firstName, string lastName) : base()
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public override string ToString()
    {
        return $"{base.ToString()} User[FirstName: {FirstName}, LastName: {LastName}]";
    }
}