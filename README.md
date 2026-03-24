**Aplikacja stanowi prostą symulację wypożyczalni sprzętu**

  Organizacja kodu
Struktura projektu została podzielona na dedykowane domeny systemu - Users, Devices, Rentals.
Dzięki takiemu podziałowi logika poszczególnych domen jest od siebie odseparowana.

  Model
Klasy modelowe służą tylko do przechowywania danych. Mamy 3 główne typy:
  - Device - klasa abstrakcyjna i jej implementacje Laptop, Camera, Headphones
  - User - klasa abstrakcyjna i jej implemetacje Student, Employee
  - Rental - klasa łączące ze sobą Device i Usera - swoista relacja wiele do wielu.

  Reguły biznesowe
Sercem aplikacji jest RentalService, który zawiera większość logiki biznesowej i mechanizm wypożyczania oraz oddawania sprzętu.
Zadaniem klas modelowych jest przechowywanie i łączenie ze sobą danych - jedyne reguły jakie przechowują, to specyficzne od implementacji:
  - opłata za zniszczenie sprzętu (metoda abstrakcyjna w klasie Device)
  - limit urządzeń na użytkownika (metoda abstrakcyjna w klasie User)

  Klasa ConsoleLoggerService i Program.cs
Metody służące do prezentacji i działania programu znajdują się w oddzielnej klasie.
Tworzenie testowych danych i efekty działania poszczególnych metod znajdują się w pliku Program.cs

  Przykłady kohezji, loose coupling i odpowiedzialności

  Kohezja
Przykładem jest klasa IdentifiableObject - jest klasą abstrakcyjną, której jedynym zadaniem jest nadawanie unikalnych identyfikatorów kolejnym obiektom klas które po niej dziedziczą.

  Loose Coupling
RentalService nie wie jakiego dokładnie użytkownika obsługuje, działa na abstrakcji, a jej implementacja (student lub employee) sama wie jaki ma limit wypożyczonych urządzeń.
Możnaby dodać kolejne typy Usera, a logika serwisu nie uległaby zmianie.
Dodatkowo logika wyświetlania danych została oddzielona od logiki biznesowej.

  Odpowiedzialność Klas
Klasy z modelu nie przechowują w sobie logiki biznesowej. Wiedzą że łączą dane, umieją powstać i dać dostęp do swoich pól.
Cały proces - logika biznesowa - znajduje się w RentalService.
Przykładowo ona wie jak obliczyć karę za zniszczenie sprzętu czy przekroczenie terminu oddania, ale obiekt Rental dostarcza jej wszystkich danych.
