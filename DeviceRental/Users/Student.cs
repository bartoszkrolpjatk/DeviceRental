namespace DeviceRental.Users;

public class Student : User
{
    public Student(string firstName, string lastName) : base(firstName, lastName)
    {
    }

    public override int GetDeviceLimit()
    {
        return 2;
    }
}