using DeviceRental.Devices;
using DeviceRental.Users;

namespace DeviceRental.Rentals;

public class Rental
{
    private static readonly List<Rental> Rentals = [];
    
    internal Device RentedDevice { get; }
    internal User Renter { get; }
    private DateTime StartDate { get; }
    internal DateTime ExpectedEndDate { get; }
    internal DateTime? ActualEndDate { get; set; }
    public decimal Fee { get; internal set; }

    public Rental(Device rentedDevice, User renter, DateTime startDate)
    {
        RentedDevice = rentedDevice;
        Renter = renter;
        StartDate = startDate;
        ExpectedEndDate = StartDate.AddDays(1);
        Rentals.Add(this);
    }

    internal static List<Rental> GetRentals()
    {
        return [..Rentals];
    }

    internal bool Open()
    {
        return ActualEndDate == null;
    }

    public override string ToString()
    {
        var inTime = ExpectedEndDate > ActualEndDate;
        return $"Rental[RentedDevice: {RentedDevice}, Renter: {Renter}, StartDate: {StartDate}, ExpectedEndTime: {ExpectedEndDate} ActualEndTime: {ActualEndDate}, inTime: {inTime}]";
    }
}