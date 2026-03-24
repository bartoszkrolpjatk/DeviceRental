namespace DeviceRental.Users;

public class Employee : User
{
    public Employee(string firstName, string lastName) : base(firstName, lastName)
    {
    }

    public override int GetDeviceLimit()
    {
        return 5;
    }
}