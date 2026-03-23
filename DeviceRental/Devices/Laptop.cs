namespace DeviceRental.Devices;

public class Laptop : Device
{
    private uint ScreenSize { get; }
    private uint YearProduced { get; } 
    
    public Laptop(string name, uint screenSize, uint yearProduced) : base(name)
    {
        ScreenSize = screenSize;
        YearProduced = yearProduced;
    }

    public override string ToString()
    {
        return $"{base.ToString()} Laptop [ScreenSize: {ScreenSize}, YearProduced: {YearProduced}]";
    }
}