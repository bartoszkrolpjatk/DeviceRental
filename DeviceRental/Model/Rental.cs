namespace DeviceRental.Model;

public class Rental
{
    private Device RentedDevice { get; }
    private User Renter { get; }
    private DateTime StartDate { get; }
    private DateTime? EndDate { get; set; } = null;
    private bool? ReturnedInTime { get; set; } = null;

    public Rental(Device rentedDevice, User renter, DateTime startDate)
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