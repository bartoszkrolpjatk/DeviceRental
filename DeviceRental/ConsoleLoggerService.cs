using DeviceRental.Devices;
using DeviceRental.Rentals;
using DeviceRental.Users;

namespace DeviceRental;

public class ConsoleLoggerService
{
    public void ShowSystemReport()
    {
        Console.WriteLine("---System report---");
        Console.WriteLine("Ongoing rentals");
        foreach (var rental in Rental.GetRentals().Where(r => r.Open()))
        {
            Console.WriteLine(rental);
        }
        Console.WriteLine("Closed rentals");
        foreach (var rental in Rental.GetRentals().Where(r => !r.Open()))
        {
            Console.WriteLine(rental);
        }
    }

    public void ShowOpenRentalsPastExpectedEndDate()
    {
        foreach (var rental in Rental.GetRentals()
                     .Where(rental => rental.Open() && DateTime.Now > rental.ExpectedEndDate))
        {
            Console.WriteLine(rental);
        }
    }
    
    public void ShowDevices(Status? status = null)
    {
        foreach (var device in Device.GetAllDevices().Where(d => status == null || d.Status == status))
        {
            Console.WriteLine(device);
        }
    }
    
    public void ShowDevicesRentedByUser(User user)
    {
        foreach (var device in Rental.GetRentals().Where(rental => rental.Open() && rental.Renter.Equals(user)).Select(rental => rental.RentedDevice))
        {
            Console.WriteLine(device);
        }
    }
}