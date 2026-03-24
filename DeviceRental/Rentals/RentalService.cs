using DeviceRental.Devices;
using DeviceRental.Users;

namespace DeviceRental.Rentals;

public class RentalService
{
    private const int SingleDayLateFee = 2;
    
    public void ReturnDevice(Rental rental, Status status = Status.Available)
    {
        var returnDate = DateTime.Now;
        if (returnDate > rental.ExpectedEndDate)
        {
            var overdueStartedDays = (decimal) Math.Ceiling((returnDate - rental.ExpectedEndDate).TotalDays);
            rental.Fee += overdueStartedDays * SingleDayLateFee;
        }
        if (status == Status.Broken)
        {
            rental.Fee += rental.RentedDevice.GetBrokenDeviceFee();
        }
        rental.ActualEndDate = returnDate;
        rental.RentedDevice.Status = status;
    }
    
    public Rental RentDevice(User user, Device device, DateTime startDate)
    {
        var rentedDevices = GetNumberOfRentedDevices(user);
        if (rentedDevices >= user.GetDeviceLimit())
            throw new RentDeviceException($"{user} reached the limit.");
        if (device.Status != Status.Available)
            throw new RentDeviceException($"{device} not available for rental. Status: {device.Status}");
        device.Status = Status.Rented;
        return new Rental(device, user, startDate);
    }

    private int GetNumberOfRentedDevices(User user)
    {
        return Rental.GetRentals()
            .Where(r => r.ActualEndDate == null)
            .Count(r => r.Renter.Equals(user));
    }
}