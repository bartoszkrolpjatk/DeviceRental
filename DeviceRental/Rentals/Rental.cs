using DeviceRental.Users;

namespace DeviceRental.Rentals;

public class Rental
{
    private Devices.Device RentedDevice { get; }
    private User Renter { get; }
    private DateTime StartDate { get; }
    private DateTime? EndDate { get; set; } = null;
    private bool? ReturnedInTime { get; set; } = null;

    public Rental(Devices.Device rentedDevice, User renter, DateTime startDate)
    {
        RentedDevice = rentedDevice;
        Renter = renter;
        StartDate = startDate;
    }

    public override string ToString()
    {
        return $"Rental[RentedDevice: {RentedDevice}, Renter: {Renter}, StartDate: {StartDate}, EndTime: {EndDate}, ReturnedInTime: {ReturnedInTime}]";
    }
}