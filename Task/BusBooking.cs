using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace BusBookingApplication

{
    internal class BusBooking
    {
        //custom exceptions
        public class BusNotFoundException : Exception
        {
            public BusNotFoundException(string message) : base(message) { }
        }

        public class InvalidBookingException : Exception
        {
            public InvalidBookingException(string message) : base(message) { }
        }

        //models

        public class Bus
        {
            private static int idCounter = 101;
            public int BusId { get; }
            public string BusName { get; set; }
            public string StartingPoint { get; set; }
            public string EndingPoint { get; set; }
            public int TotalSeats { get; set; }
            public int AvailableSeats { get; set; }
            public string Timing { get; set; }

            public Bus(string busname, string startingPoint, string endingPoint, int totalSeats, int availableSeats, string timing)
            {
                BusId = idCounter++;
                BusName = busname;
                StartingPoint = startingPoint;
                EndingPoint = endingPoint;
                TotalSeats = totalSeats;
                AvailableSeats = availableSeats;
                Timing = timing;
            }
        }

        public class Passenger
        {
            public int PassengerId { get; set; }
            public string PassengerName { get; set; }
            public string PhoneNo { get; set; }
            public int Age { get; set; }
            public string City { get; set; }
            public int BookedBusId { get; set; }

            public Passenger(int passengerId,string passengerName, string phoneNo, int age, string city, int bookedBusId)
            {
                PassengerId = passengerId;
                PassengerName = passengerName;
                PhoneNo = phoneNo;
                Age = age;
                City = city;
                BookedBusId = bookedBusId;
            }
        }

        class Program
        {
            private static List<Bus> buses = new List<Bus>();
            private static List<Passenger> passengers = new List<Passenger>();

            static void Main(string[] args)
            {
                SeedInitialData();

                bool exit = false;

                while (!exit)
                {
                    Console.Clear();
                    Console.WriteLine("===================================");
                    Console.WriteLine("BUS BOOKING APPLICATION");
                    Console.WriteLine("===================================");
                    Console.WriteLine("1.View Bus Details");
                    Console.WriteLine("2.Search Bus");
                    Console.WriteLine("3.Check Seat Availability");
                    Console.WriteLine("4.Book Ticket");
                    Console.WriteLine("5.View Passenger Details");
                    Console.WriteLine("6.Update Passenger Details");
                    Console.WriteLine("7.Cancel Ticket");
                    Console.WriteLine("8.Admin");
                    Console.WriteLine("9.Exit");
                    Console.WriteLine("Enter your choice:");

                    string choice = Console.ReadLine();
                    Console.WriteLine();

                    try
                    {
                        switch (choice)
                        {
                            case "1":
                                ViewAllBuses();
                                break;
                            case "2":
                                SearchBus();
                                break;
                            case "3":
                                CheckSeatAvailability();
                                break;
                            case "4":
                                BookTicket();
                                break;
                            case "5":
                                ViewPassenger();
                                break;
                            case "6":
                                UpdatePassenger();
                                break;
                            case "7":
                                CancelTicket();
                                break;
                            case "8":
                                AdminMenu();
                                break;
                            case "9":
                                exit = true;
                                Console.WriteLine("Thankyou for using the Bus Booking System!");
                                break;
                            default:
                                Console.WriteLine("Invalid choice. Please try again.");
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[Error]: {ex.Message}");
                    }

                    if (!exit)
                    {
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                    }

                }
            }
            private static void SeedInitialData()
            {
                buses.Add(new Bus("Express Line", "Chennai", "Coimbatore", 40, 40, "08:00 AM"));
                buses.Add(new Bus("Rapid Transit", "Madurai", "Chennai", 30, 30, "09:30 AM"));
                buses.Add(new Bus("Luxury Coach", "Nagercoil", "Chennai", 20, 20, "11:00 AM"));
            }

            //option 1 - View Bus Details

            private static void ViewAllBuses()
            {
                Console.WriteLine(new string('-', 65));
                Console.WriteLine($"{"Bus ID":<10} {"Bus Name":<20} {"Source":<15} {"Destination":<15} {"Total Seats":<12} {"Seats":<15} {"Timing"}");
                Console.WriteLine(new string('-', 65));
                foreach (var b in buses)
                {
                    Console.WriteLine($"{b.BusId,-8} {b.BusName,-16} {b.StartingPoint,-12} {b.EndingPoint,-12} {b.TotalSeats,-12} {b.AvailableSeats,-15} {b.Timing}");
                }
                Console.WriteLine(new string('-', 65));
            }

            //option 2 - Search Bus

            private static void SearchBus()
            {
                Console.WriteLine("Enter Starting Point:");
                string start = Console.ReadLine().Trim();
                Console.WriteLine("Enter Destination");
                string end = Console.ReadLine().Trim();

                var matchingBuses = buses.Where(b =>
                b.StartingPoint.Equals(start, StringComparison.OrdinalIgnoreCase) &&
                b.EndingPoint.Equals(end, StringComparison.OrdinalIgnoreCase)).ToList();

                if (matchingBuses.Count == 0)
                {
                    throw new BusNotFoundException("No buses found for the given route.");
                }

                Console.WriteLine("\n Buses Available: ");
                foreach (var b in matchingBuses)
                {
                    Console.WriteLine($"Bus ID : {b.BusId}");
                    Console.WriteLine($"Bus Name : {b.BusName}");
                    Console.WriteLine($"From : {b.StartingPoint}");
                    Console.WriteLine($"To : {b.EndingPoint}");
                    Console.WriteLine($"Seats : {b.AvailableSeats}");
                    Console.WriteLine($"Timing : {b.Timing}");
                }

            }

            //option 3 - check seat availability

            private static void CheckSeatAvailability()
            {
                Console.Write("Enter Bus ID:");
                if (!int.TryParse(Console.ReadLine(), out int busId)) return;

                var bus = buses.FirstOrDefault(b => b.BusId == busId);

                if (bus == null) throw new BusNotFoundException("Bus not found.");

                int bookedSeats = bus.TotalSeats - bus.AvailableSeats;
                Console.WriteLine($"Bus Name : {bus.BusName}");
                Console.WriteLine($"Total Seats : {bus.TotalSeats}");
                Console.WriteLine($"Available Seats : {bus.AvailableSeats}");
                Console.WriteLine($"Booked Seats : {bookedSeats}");

            }

            //option 4 - book ticket

            private static void BookTicket()
            {
                Console.WriteLine("Enter Starting Point: ");
                string start = Console.ReadLine().Trim();
                Console.WriteLine("Enter Destination: ");
                string end = Console.ReadLine().Trim();

                var routeBuses = buses.Where(b =>
                b.StartingPoint.Equals(start, StringComparison.OrdinalIgnoreCase) &&
                b.EndingPoint.Equals(end, StringComparison.OrdinalIgnoreCase)
                ).ToList();

                if (routeBuses.Count == 0)
                {
                    throw new BusNotFoundException("No buses found for the given route.");
                }

                Console.Write("/nENter Bus ID to book ticket: ");
                if (!int.TryParse(Console.ReadLine(), out int busId)) return;

                var selectedBus = routeBuses.FirstOrDefault(b => b.BusId == busId);
                if (selectedBus == null) throw new BusNotFoundException("Invalid Bus ID Selected");

                Console.WriteLine($"Total Seats : {selectedBus.TotalSeats}");
                Console.WriteLine($"Available Seats : {selectedBus.AvailableSeats}");

                Console.WriteLine("Enter Number of Seats to Book: ");
                if (!int.TryParse(Console.ReadLine(), out int count) || count <= 0)
                {
                    Console.WriteLine("Invalid number of seats.");
                    return;
                }

                if (count > selectedBus.AvailableSeats)
                {
                    throw new InvalidBookingException("Requested seats are not available.");
                }

                List<Passenger> newlyBooked = new List<Passenger>();

                for (int i = 1; i <= count; i++)
                {
                    Console.WriteLine($"\nPassenger {i}");
                    Console.Write("Enter Passenger Name: ");
                    string name = Console.ReadLine().Trim();
                    Console.Write("Enter Phone Number: ");
                    string phone = Console.ReadLine().Trim();
                    Console.Write("Enter Age: ");
                    int age = int.Parse(Console.ReadLine());
                    Console.Write("Enter City: ");
                    string city = Console.ReadLine();

                    int newId = passengers.Count + 1;

                    Passenger P = new Passenger(newId, name, phone, age, city, selectedBus.BusId);
                    passengers.Add(P);
                    newlyBooked.Add(P);
                }

                selectedBus.AvailableSeats -= count;

                foreach (var p in newlyBooked)
                {
                    Console.WriteLine("\n========================================");
                    Console.WriteLine("          BOOKING CONFIRMED");
                    Console.WriteLine("========================================");
                    Console.WriteLine($"Bus ID        : {selectedBus.BusId}");
                    Console.WriteLine($"Bus Name      : {selectedBus.BusName}");
                    Console.WriteLine($"Passenger ID  : {p.PassengerId}");
                    Console.WriteLine($"Passenger Name: {p.PassengerName}");
                    Console.WriteLine($"Starting Point: {selectedBus.StartingPoint}");
                    Console.WriteLine($"Destination   : {selectedBus.EndingPoint}");
                    Console.WriteLine($"Timing        : {selectedBus.Timing}");
                    Console.WriteLine("========================================");
                    Console.WriteLine("          HAPPY JOURNEY!");
                    Console.WriteLine("========================================");
                }
            }

            //option 5 - view passenger details
            private static void ViewPassenger()
            {
                if (passengers.Count == 0)
                {
                    Console.WriteLine("No passengers found.");
                    return;
                }
                Console.WriteLine(new string('-', 60));
                Console.WriteLine($"{"ID",-8} {"Name",-20} {"Phone",-15} {"Age",-5} {"City"}");
                Console.WriteLine(new string('-', 60));
                foreach (var p in passengers)
                {
                    Console.WriteLine($" {p.PassengerId,-8} {p.PassengerName,-20} {p.PhoneNo,-15} {p.Age,-5} {p.City}");

                }
                Console.WriteLine(new string('-', 60));
            }

            ///option6 - update passenger details
            ///
            private static void UpdatePassenger()
            {
                Console.Write("Enter Passenger ID : ");
                if (!int.TryParse(Console.ReadLine(), out int pid)) return;

                var passenger = passengers.FirstOrDefault(p => p.PassengerId == pid);
                if (passenger == null)
                {
                    Console.WriteLine("Passenger not found.");
                    return;
                }

                Console.WriteLine("\nPassenger Found.");
                Console.WriteLine("1. Update Name");
                Console.WriteLine("2. Update Phone Number");
                Console.WriteLine("3. Update Age");
                Console.WriteLine("4. Update City");
                Console.WriteLine("5. Update All Details");
                Console.Write("\nEnter Choice: ");
                string choice = Console.ReadLine();

                switch(choice)
                {
                    case "1":
                        Console.Write("Enter new name: ");
                        passenger.PassengerName = Console.ReadLine();
                        break;
                        case "2":
                        Console.Write("Enter new phone number: ");
                        passenger.PhoneNo = Console.ReadLine();
                        break;
                    case "3":
                        Console.Write("Enter new age: ");
                        passenger.Age = int.Parse(Console.ReadLine());
                        break;
                    case "4":
                        Console.Write("Enter new city: ");
                        passenger.City = Console.ReadLine();
                        break;
                    case "5":
                        Console.Write("Enter new name: ");
                        passenger.PassengerName = Console.ReadLine();
                        Console.Write("Enter new phone number: ");
                        passenger.PhoneNo = Console.ReadLine();
                        Console.Write("Enter new age: ");
                        passenger.Age = int.Parse(Console.ReadLine());
                        Console.Write("Enter new city: ");
                        passenger.City = Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        return;
                }
                Console.WriteLine("\nPassenger details updated successfully.");
            }

            //option 7 - cancel ticket

            private static void CancelTicket()
            {
                Console.Write("Enter Passenger ID: ");
                if(!int.TryParse(Console.ReadLine(),out int pid)) return;
                 var passenger = passengers.FirstOrDefault(p => p.PassengerId == pid);
                if(passenger == null)
                {
                    Console.WriteLine("Passenger not found.");
                    return;
                }
                Console.WriteLine("\nPassenger Found:");
                Console.WriteLine("Are you sure you want to cancel the ticket?");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");
                Console.Write("Enter Choice: ");
                string confirm = Console.ReadLine();

                if(confirm == "1")
                {
                    var bus = buses.FirstOrDefault(b => b.BusId == passenger.BookedBusId);
                    if(bus != null)
                    {
                        bus.AvailableSeats += 1;
                    }
                    passengers.Remove(passenger);
                    Console.WriteLine("Ticket canceled successfully.");

                }
                else
                {
                    Console.WriteLine("Ticket cancellation aborted.");
                }
            }

            //option 8 - admin menu
          
            private static void AdminMenu()
            {
                bool adminExit = false;
                while(!adminExit)
                {
                    Console.Clear();
                    Console.WriteLine("===============================");
                    Console.WriteLine("ADMIN MENU");
                    Console.WriteLine("===============================");
                    Console.WriteLine("1.View All Buses");
                    Console.WriteLine("2. Add New Bus");
                    Console.WriteLine("3. Update Bus");
                    Console.WriteLine("4. Delete Bus");
                    Console.WriteLine("5. Search Bus");
                    Console.WriteLine("6. Exit Admin Menu");
                    Console.Write("\nEnter Choice: ");

                    string choice = Console.ReadLine();
                    Console.WriteLine();

                    try
                    {
                        switch(choice)
                        {
                            case "1":
                                ViewAllBuses();
                                break;

                            case "2":
                                AddBus();
                                break;

                            case "3":
                                UpdateBus();
                                break;

                            case "4":
                                DeleteBus();
                                break;

                            case "5":
                                SearchBus();
                                break;
                            default:
                                Console.WriteLine("Invalid Choice");
                                break;
                        }
                    }

                    catch(Exception ex)
                    {
                        Console.WriteLine($"\n[Error]: {ex.Message}");
                    }

                    if(!adminExit)
                    {
                        Console.WriteLine("\nPress any key to continue.....");
                        Console.ReadKey();
                    }
                }
            }

            private static void AddBus()
            {
               
                Console.Write("Enter Bus Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Starting Point: ");
                string start = Console.ReadLine();
                Console.Write("Enter Ending Point: ");
                string end = Console.ReadLine();
                Console.Write("Enter Total Seats: ");
                int seats = int.Parse(Console.ReadLine());
                Console.Write("Enter Timing: ");
                string timing = Console.ReadLine();

                buses.Add(new Bus(name, start, end, seats, seats, timing));
                Console.WriteLine("\nBus Added successfully.");
            }

            private static void UpdateBus()
            {
                Console.Write("Enter Bus ID to update: ");
                if (!int.TryParse(Console.ReadLine(), out int id)) return;

                var bus = buses.FirstOrDefault(b => b.BusId == id);
                if (bus == null) throw new BusNotFoundException("Bus not found.");

                Console.Write("Enter New Bus Name: ");
                bus.BusName = Console.ReadLine();
                Console.Write("Enter New Starting point: ");
                bus.StartingPoint = Console.ReadLine();
                Console.Write("Enter New Ending Point: ");
                bus.EndingPoint = Console.ReadLine();
                Console.Write("Enter New Total Seats: ");
                int newTotal = int.Parse(Console.ReadLine());

                //Adjusting available seats
                int bookedSeats = bus.TotalSeats - bus.AvailableSeats;
                bus.TotalSeats = newTotal;
                bus.AvailableSeats = Math.Max(0, newTotal - bookedSeats);

                Console.Write("ENter New Timing: ");
                bus.Timing = Console.ReadLine();

                Console.WriteLine("\n Bus Details updated successfully");
            }

            private static void DeleteBus()
            {
                Console.Write("Enter Bus ID to Delete: ");
                if (!int.TryParse(Console.ReadLine(), out int id)) return;

                var bus = buses.FirstOrDefault(b => b.BusId == id);
                if (bus == null) throw new BusNotFoundException("Bus not found");

                Console.WriteLine($"Are you sure you want to delete Bus ID {id} ({bus.BusName})?");
                Console.WriteLine("1 , yes");
                Console.WriteLine("2, no");
                Console.Write("Enter Choice:");
                string confirm = Console.ReadLine();

                if(confirm == "1")
                {
                    buses.Remove(bus);
                    Console.WriteLine("\nBus Deleted Successfully.");
                }
                else
                {
                    Console.WriteLine("Deletion aborted");
                }
            }
        }
    }
}