using DeviceRental.Devices;
using DeviceRental.Rentals;
using DeviceRental.Users;

var deviceService = new DeviceService();
var rentalService = new RentalService();

//creating users
var michael = new Student("Michael", "Scott");
var tomaszew = new Employee("Michał", "Tomaszewski");

//creating devices
var hp = new Laptop("HP Envy 360", 16, 2020);
var dell = new Laptop("Dell 14 Plus", 14, 2024);
var headphones = new Headphones("JBL BTNC600", true, true);
var camera = new Camera("Fuji2024", 1920, "Full HD");

deviceService.ShowDevices();

{
    Console.WriteLine("\n-----START TEST CASE 1 - Michael rents a camera-----");
    Rental cameraRentalByMichael = rentalService.RentDevice(michael, camera, DateTime.Now);
    Console.WriteLine($"Michael created rental {cameraRentalByMichael}");    
    try
    {
        rentalService.RentDevice(michael, camera, DateTime.Now); //exception: camera already rented!
    }
    catch (RentDeviceException ex)
    {
        Console.Error.WriteLine($"ERROR! {ex.Message}");
    }
    rentalService.ReturnDevice(cameraRentalByMichael);
    Console.WriteLine($"Michael fee for camera rental: {cameraRentalByMichael.Fee}"); //0 - Not Broken and 'In time'
    Console.WriteLine("-----END TEST CASE 1-----\n");
}

rentalService.ShowSystemReport();

{
    Console.WriteLine("\n-----START TEST CASE 2 - Michael rents devices to his limit-----");
    Rental headphoneRentalByMichael = rentalService.RentDevice(michael, headphones, DateTime.Now);
    Console.WriteLine($"Michael created rental {headphoneRentalByMichael}");
    Rental hpRentalByMichael = rentalService.RentDevice(michael, hp, DateTime.Now); 
    Console.WriteLine($"Michael created rental {hpRentalByMichael}");
    try
    {
        rentalService.RentDevice(michael, dell, DateTime.Now); //exception: michael can not rent more devices!
    }
    catch (RentDeviceException ex)
    {
        Console.Error.WriteLine($"ERROR! {ex.Message}");
    }
    rentalService.ReturnDevice(headphoneRentalByMichael);
    rentalService.ShowDevicesRentedByUser(michael);
    Console.WriteLine("-----END TEST CASE 2-----\n");
}

rentalService.ShowSystemReport();

{
    Console.WriteLine("\n-----START TEST CASE 3 - Tomaszew rents device, breaks it and returns after the deadline -----");
    Rental cameraRentalByTomaszew = rentalService.RentDevice(tomaszew, camera, new DateTime(2026, 3, 22)); 
    Console.WriteLine($"Tomaszew created rental {cameraRentalByTomaszew}");
    rentalService.ReturnDevice(cameraRentalByTomaszew, Status.Broken);
    Console.WriteLine($"Tomaszew fee for hp rental: {cameraRentalByTomaszew.Fee}"); //1004! Broken - 1000, overdue 2 days - 4
    Console.WriteLine("-----END TEST CASE 3-----\n");
}

{
    Console.WriteLine("\n-----START TEST CASE 4 - Tomaszew is trying to rent headphones but they are unavailable-----");
    try
    {
        headphones.Status = Status.Unavailable;
        rentalService.RentDevice(tomaszew, headphones, DateTime.Now); //exception: headphones unavailable!
    }
    catch (RentDeviceException ex)
    {
        Console.Error.WriteLine($"ERROR! {ex.Message}");
    }
    Console.WriteLine("-----END TEST CASE 4-----\n");
}

{
    Console.WriteLine("\n-----START TEST CASE 5 - Tomaszew is trying to rent hp but it is has been rented-----");
    try
    {
        rentalService.RentDevice(tomaszew, hp, DateTime.Now); //exception: hp already rented!
    }
    catch (RentDeviceException ex)
    {
        Console.Error.WriteLine($"ERROR! {ex.Message}");
    }
    Console.WriteLine("-----END TEST CASE 5-----\n");
}

deviceService.ShowDevices(Status.Unavailable); //only headphones printed out
deviceService.ShowDevices();

rentalService.ShowSystemReport();

{
    Console.WriteLine("\n-----START TEST CASE 6 - Michael rents dell and keeps it after the deadline-----");
    Rental dellRentalByMichael = rentalService.RentDevice(michael, dell, new DateTime(2026, 3, 22)); 
    Console.WriteLine($"Micheal created rental {dellRentalByMichael}");
    rentalService.ShowOpenRentalsPastExpectedEndDate();
    Console.WriteLine("-----END TEST CASE 6-----\n");
}

