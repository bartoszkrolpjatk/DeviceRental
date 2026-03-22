namespace DeviceRental.Model;

public class Laptop : Device
{
    private uint ScreenSize { get; }
    private uint YearProduced { get; } 
    
    public Laptop(string name, Status status, uint screenSize, uint yearProduced) : base(name, status)
    {
        ScreenSize = screenSize;
        YearProduced = yearProduced;
    }

    public override string ToString()
    {
        return $"{base.ToString()} Laptop [ScreenSize: {ScreenSize}, YearProduced: {YearProduced}]";
    }
}