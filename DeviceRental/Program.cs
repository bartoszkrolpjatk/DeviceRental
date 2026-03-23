using DeviceRental.Devices;
using DeviceRental.Rentals;
using DeviceRental.Users;

var deviceService = new DeviceService();
var rentalService = new RentalService();

var michael = new Student("Michael", "Scott");
var hp = new Laptop("HP Envy 360", 16, 2020);
var dell = new Laptop("Dell 14 Plus", 14, 2024);
var headphones = new Headphones("JBL BTNC600", true, true);
var camera = new Camera("Fuji2024", 1920, "Full HD");

deviceService.ShowDevices();

try
{
    rentalService.Rent(michael, camera);
    rentalService.Rent(michael, camera);
}
catch (RentDeviceException ex)
{
    Console.Error.WriteLine($"ERROR! {ex.Message}");
}
