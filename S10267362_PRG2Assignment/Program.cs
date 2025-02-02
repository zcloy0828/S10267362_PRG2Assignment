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



//feature 1 

void LoadAirlines()
{
    // Load airlines from airlines.csv
    using (StreamReader sr = new StreamReader("airlines.csv"))
    {
        sr.ReadLine();
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            string[] parts = line.Split(',');

            string airlineCode = parts[1];
            string airlineName = parts[0];
            ;
            // Create an Airline object and add it to the dictionary
            Airline airline = new Airline(airlineName, airlineCode);
            terminal5.Airlines.Add(airlineCode, airline);
        }
    }
}


void LoadBoardingGates(Dictionary<string, BoardingGate> boardingGates)
{
    // Load boarding gates from boardinggates.csv
    using (StreamReader sr = new StreamReader("boardinggates.csv"))
    {
        sr.ReadLine();
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            string[] parts = line.Split(',');

            string gateName = parts[0];
            bool supportsCFFT = bool.Parse(parts[1]);
            bool supportsDDJB = bool.Parse(parts[2]);
            bool supportsLWTT = bool.Parse(parts[3]);

            // Create a BoardingGate object and add it to the dictionary
            BoardingGate gate = new BoardingGate(gateName, supportsCFFT, supportsDDJB, supportsLWTT);
            boardingGates.Add(gateName, gate);
        }
    }
}



//feature 2 
void LoadFlights(Dictionary<string, Flight> flights, Terminal terminal)
{
    using (StreamReader sr = new StreamReader("flights.csv"))
    {
        sr.ReadLine();
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            string[] parts = line.Split(',');
            string flightNumber = parts[0];
            string origin = parts[1];
            string destination = parts[2];
            DateTime expectedTime = DateTime.Parse(parts[3]);
            string requestCode = parts[4];

            if (requestCode == "DDJB")
            {
                Flight addFlight = new DDJBFlight(flightNumber, origin, destination, expectedTime);

                flights.Add(flightNumber, addFlight);
                terminal.GetAirlineFromFlight(addFlight).AddFlight(addFlight);
            }
            else if (requestCode == "CFFT")
            {
                Flight addFlight = new CFFTFlight(flightNumber, origin, destination, expectedTime);
                flights.Add(flightNumber, addFlight);
                terminal.GetAirlineFromFlight(addFlight).AddFlight(addFlight);
            }
            else if (requestCode == "LWTT")
            {
                Flight addFlight = new LWTTFlight(flightNumber, origin, destination, expectedTime);
                flights.Add(flightNumber, addFlight);
                terminal.GetAirlineFromFlight(addFlight).AddFlight(addFlight);
            }
            else
            {
                Flight addFlight = new NORMFlight(flightNumber, origin, destination, expectedTime);
                flights.Add(flightNumber, addFlight);
                terminal.GetAirlineFromFlight(addFlight).AddFlight(addFlight);
            }
        }
    }
}










