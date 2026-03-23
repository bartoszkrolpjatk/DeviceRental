using DeviceRental.Model;
using DeviceRental.Service;

var deviceService = new DeviceService();

var michael = new Student("Michael", "Scott");
var hp = new Laptop("HP Envy 360", 16, 2020);
var dell = new Laptop("Dell 14 Plus", 14, 2024);
var headphones = new Headphones("JBL BTNC600", true, true);
var camera = new Camera("Fuji2024", 1920, "Full HD");

deviceService.ShowDevices();