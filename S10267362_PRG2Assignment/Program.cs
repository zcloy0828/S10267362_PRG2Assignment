// See https://aka.ms/new-console-template for more information



using S10267362_PRG2Assignment;

Terminal terminal5 = new Terminal("Terminal 5");
Dictionary<string, Flight> flights = new Dictionary<string, Flight>();
LoadAirlines();
LoadBoardingGates(terminal5.BoardingGates);
LoadFlights(flights, terminal5);
while (true)
{

    Console.WriteLine("=============================================");
    Console.WriteLine("1. List All Flights");
    Console.WriteLine("2. List Boarding Gates");
    Console.WriteLine("3. Create Flight");
    Console.WriteLine("4. Display Airline Flights");
    Console.WriteLine("5. Calculate Total Fees Per Airline");
    Console.WriteLine("0. Exit");
    Console.WriteLine("=============================================");
    Console.Write("Please select your option: ");

    string option = Console.ReadLine();

    // Replace the switch with if-else
    if (option == "1")
    {
        Console.Clear();
        DisplayFlightInfo(terminal5, flights);
    }
    else if (option == "2")
    {
        DisplayBoardingGates();
    }

    else if (option == "3")
    {
        NewFlight();
    }
    else if (option == "4")
    {
        DisplayFullFlightDetails();
    }
    else if (option == "5")
    {
        terminal5.CalculateTotalFeesPerAirline();
    }
    else if (option == "0")
    {
        Console.WriteLine("Exiting program...");
        break;
    }
    else
    {
        Console.WriteLine("Invalid option. Please try again.");
    }
}














