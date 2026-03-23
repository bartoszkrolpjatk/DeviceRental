using DeviceRental.Devices;
using DeviceRental.Users;

namespace DeviceRental.Rentals;

public class RentalService
{
    public Rental Rent(User user, Device device)
    {
        var rentedDevices = GetNumberOfRentedDevices(user);
        var userLimit = GetRentedDevicesLimit(user);
        if (rentedDevices >= userLimit)
            throw new RentDeviceException($"{user} reached the limit.");
        if (device.Status != Status.Available)
            throw new RentDeviceException($"{device} not available for rental.");
        device.SetUnavailable();
        return new Rental(device, user);
    }

    private int GetNumberOfRentedDevices(User user)
    {
        return Rental.GetRentals().Count(r => r.Renter.Equals(user));
    }

    private int GetRentedDevicesLimit(User user)
    {
        return user switch
        {
            Student => 2,
            Employee => 5,
            _ => 0
        };
    }
}