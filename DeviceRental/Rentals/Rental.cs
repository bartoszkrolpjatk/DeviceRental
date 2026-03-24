using DeviceRental.Devices;
using DeviceRental.Users;

namespace DeviceRental.Rentals;

public class Rental
{
    private static readonly List<Rental> Rentals = [];
    
    public Device RentedDevice { get; }
    public User Renter { get; }
    private DateTime StartDate { get; }
    public DateTime ExpectedEndDate { get; }
    public DateTime? ActualEndDate { get; set; }
    public decimal Fee { get; internal set; }

    public Rental(Device rentedDevice, User renter, DateTime startDate)
    {
        RentedDevice = rentedDevice;
        Renter = renter;
        StartDate = startDate;
        ExpectedEndDate = StartDate.AddDays(1);
        Rentals.Add(this);
    }

    public static List<Rental> GetRentals()
    {
        return [..Rentals];
    }

    public bool Open()
    {
        return ActualEndDate == null;
    }

    public override string ToString()
    {
        var inTime = ExpectedEndDate > ActualEndDate;
        return $"Rental[RentedDevice: {RentedDevice}, Renter: {Renter}, StartDate: {StartDate}, ExpectedEndTime: {ExpectedEndDate} ActualEndTime: {ActualEndDate}, inTime: {inTime}]";
    }
}