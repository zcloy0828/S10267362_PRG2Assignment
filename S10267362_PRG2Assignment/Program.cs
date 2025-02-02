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

    using (StreamReader sr = new StreamReader("airlines.csv"))
    {
        sr.ReadLine();
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            string[] parts = line.Split(',');
            string airlineCode = parts[1];
            string airlineName = parts[0];
            Airline airline = new Airline(airlineName, airlineCode);
            terminal5.Airlines.Add(airlineCode, airline);
        }
    }
}


void LoadBoardingGates(Dictionary<string, BoardingGate> boardingGates)
{
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



//Feature 3
void DisplayFlightInfo(Terminal terminal, Dictionary<string, Flight> flight)
{
    // this checks whether the flights dictionary is empty or not
    if (flights == null || flights.Count == 0)
    {
        Console.WriteLine("No flights available.");
        return;
    }

    // Display header
    Console.WriteLine("=============================================");
    Console.WriteLine("List of Flights for Changi Airport Terminal 5");
    Console.WriteLine("=============================================");
    Console.WriteLine("{0, -15}{1, -25}{2, -20}{3, -20}{4, -25}",
        "Flight Number", "Airline Name", "Origin", "Destination", "Expected Time");

    foreach (KeyValuePair<string, Flight> flightEntry in flights)
    {
        {
            // display the flight details
            Console.WriteLine("{0, -15}{1, -25}{2, -20}{3, -20}{4, -25}",
                flightEntry.Key, terminal.GetAirlineFromFlight(flightEntry.Value).Name, flightEntry.Value.Origin, flightEntry.Value.Destination,
                flightEntry.Value.ExpectedTime.ToString("g")); // format the date/time
        }
    }
}




//Feature 4 
void DisplayBoardingGates()
{
    if (terminal5.BoardingGates == null || terminal5.BoardingGates.Count == 0)
    {
        Console.WriteLine("No boarding gates available.");
        return;
    }

    Console.WriteLine("=============================================");
    Console.WriteLine("List of Boarding Gates for Changi Airport Terminal 5");
    Console.WriteLine("=============================================");
    Console.WriteLine("{0, -15}{1, -25}{2, -20}{3, -20}", "Gate Name", "CFFT", "DDJB", "LWTT");

    foreach (var gateEntry in terminal5.BoardingGates)
    {
        var gate = gateEntry.Value;
        if (gate != null)
        {
            Console.WriteLine("{0, -15}{1, -25}{2, -20}{3, -20}",
                gate.GateName, gate.SupportsCFFT, gate.SupportsDDJB, gate.SupportsLWTT);
        }
    }

}





//feature 6
void NewFlight()
{
    string[] validAirlineCodes = { "SQ", "MH", "JL", "CX", "QF", "TR", "EK", "BA" };
    while (true)
    {
        Console.WriteLine("=============================================");
        Console.WriteLine("Add a New Flight");
        Console.WriteLine("=============================================");

        // Prompt for flight details
        Console.Write("Enter Flight Number: ");
        string flightNumber = Console.ReadLine();

        if (flightNumber.Length < 4)
        {
            Console.WriteLine("Error: Flight number must have 5 characters (Eg SQ 115). Please try again.");
            continue;
        }

        string airlineCode = flightNumber.Substring(0, 2).ToUpper();  //this is to retrive the first two letters

        if (!validAirlineCodes.Contains(airlineCode))
        {
            Console.WriteLine("Error: Invalid airline code. Please try again.");
            continue;
        }

        if (flights.ContainsKey(flightNumber))
        {
            Console.WriteLine("Error: Flight number already exists. Please try again.");
            continue; 
        }

        Console.Write("Enter Origin: ");
        string origin = Console.ReadLine();
        if (string.IsNullOrEmpty(origin))
        {
            Console.WriteLine("Error: Origin cannot be empty. Please try again.");
            return;  
        }

        Console.Write("Enter Destination: ");
        string destination = Console.ReadLine();
        if (string.IsNullOrEmpty(destination))
        {
            Console.WriteLine("Error: Destination cannot be empty. Please try again.");
            return; 
        }

        Console.Write("Enter Expected Departure/Arrival Time (e.g., 11:30 AM): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime expectedTime))
        {
            Console.WriteLine("Invalid time format. Please try again.");
            return; 
        }

        Console.Write("Enter Flight Status (leave blank for 'On Time'): ");
        string status = Console.ReadLine();
        status = string.IsNullOrEmpty(status) ? "On Time" : status;

        string[] validStatuses = { "On Time", "Delayed", "Boarding" };
        while (!validStatuses.Contains(status))
        {
            Console.Write("Invalid status! Enter 'On Time', 'Delayed', or 'Boarding': ");
            status = Console.ReadLine();
        }


        // ask user for special request code
        Console.Write("Enter Special Request Code (leave blank for none): ");
        string specialRequestCode = Console.ReadLine();

        Flight newFlight;

        if (specialRequestCode == "DDJB")
        {
            newFlight = new DDJBFlight(flightNumber, origin, destination, expectedTime, status);
        }
        else if (specialRequestCode == "CFFT")
        {
            newFlight = new CFFTFlight(flightNumber, origin, destination, expectedTime, status);
        }
        else if (specialRequestCode == "LWTT")
        {
            newFlight = new LWTTFlight(flightNumber, origin, destination, expectedTime, status);
        }
        else
        {
            newFlight = new NORMFlight(flightNumber, origin, destination, expectedTime, status);
        }

        flights.Add(flightNumber, newFlight);
        terminal5.GetAirlineFromFlight(newFlight).AddFlight(newFlight);
        Console.WriteLine($"Flight {flightNumber} has been added!");
        Console.WriteLine("Would you like to add another flight? (Y/N): ");
        string repeat = Console.ReadLine();
        if (repeat == "Y")
        {
            NewFlight();
        }
        break;

    }
}





//feature 7
void DisplayFullFlightDetails()
{
    Console.WriteLine("=============================================");
    Console.WriteLine("List of Airlines for Changi Airport Terminal 5");
    Console.WriteLine("=============================================");
    Console.WriteLine("{0, -15}{1, -30}", "Airline Code", "Airline Name");


    foreach (var airline in terminal5.Airlines.Values)
    {
        Console.WriteLine("{0, -15}{1, -30}", airline.Code, airline.Name);
    }


    Console.Write("Enter Airline Code: ");
    string airlineCode = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(airlineCode) || !terminal5.Airlines.ContainsKey(airlineCode))
    {
        Console.WriteLine("Invalid Airline Code. Please try again.");
        return;
    }

    // this is to retrieve the selected airline
    Airline selectedAirline = terminal5.Airlines[airlineCode];

    Console.WriteLine("=============================================");
    Console.WriteLine($"List of Flights for {selectedAirline.Name}");
    Console.WriteLine("=============================================");
    Console.WriteLine("{0, -15}{1, -25}{2, -20}{3, -20}{4, -30}",
        "Flight Number", "Airline Name", "Origin", "Destination", "Expected Time");


    if (selectedAirline.Flight == null || selectedAirline.Flight.Count == 0)
    {
        Console.WriteLine("No flights available for this airline.");
        return;
    }

    foreach (var flight in selectedAirline.Flight.Values)
    {
        Console.WriteLine("{0, -15}{1, -25}{2, -20}{3, -20}{4, -30}",
            flight.FlightNumber, selectedAirline.Name, flight.Origin, flight.Destination,
            flight.ExpectedTime.ToString("dd/MM/yyyy hh:mm:ss tt"));
    }

    Console.Write("Enter a Flight Number to view full details: ");
    string flightNumber = Console.ReadLine();

    // to validate the flight number
    if (string.IsNullOrWhiteSpace(flightNumber) || !selectedAirline.Flight.ContainsKey(flightNumber))
    {
        Console.WriteLine("Invalid Flight Number. Please try again.");
        return;
    }

    Flight selectedFlight = selectedAirline.Flight[flightNumber];

    Console.WriteLine("=============================================");
    Console.WriteLine("Full Flight Details:");
    Console.WriteLine("=============================================");
    Console.WriteLine($"Flight Number:  {selectedFlight.FlightNumber}");
    Console.WriteLine($"Airline Name:   {selectedAirline.Name}");
    Console.WriteLine($"Origin:         {selectedFlight.Origin}");
    Console.WriteLine($"Destination:    {selectedFlight.Destination}");
    Console.WriteLine($"Expected Time:  {selectedFlight.ExpectedTime:dd/MM/yyyy hh:mm:ss tt}");
    Console.WriteLine($"Status:         {selectedFlight.Status}");
    Console.WriteLine($"Special Code:   {(selectedFlight is NORMFlight ? "None" : ((dynamic)selectedFlight).RequestFee)}");
    Console.WriteLine("=============================================");
}











