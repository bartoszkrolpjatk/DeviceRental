using DeviceRental.Users;

namespace DeviceRental.Rentals;

public class Rental
{
    private static readonly List<Rental> Rentals = [];
    
    private Devices.Device RentedDevice { get; }
    internal User Renter { get; }
    private DateTime StartDate { get; }
    private DateTime? EndDate { get; set; } = null;
    private bool? ReturnedInTime { get; set; } = null;

    public Rental(Devices.Device rentedDevice, User renter)
    {
        RentedDevice = rentedDevice;
        Renter = renter;
        StartDate = DateTime.Now;
        Rentals.Add(this);
    }

    internal static List<Rental> GetRentals()
    {
        return [..Rentals];
    }

    public override string ToString()
    {
        return $"Rental[RentedDevice: {RentedDevice}, Renter: {Renter}, StartDate: {StartDate}, EndTime: {EndDate}, ReturnedInTime: {ReturnedInTime}]";
    }
}