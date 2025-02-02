// See https://aka.ms/new-console-template for more information






void LoadFlights(Dictionary<string, Flight> flights, Terminal terminal)
{
    using (StreamReader sr = new StreamReader("flights.csv"))

void LoadAirlines()
{
    using (StreamReader sr = new StreamReader("airlines.csv"))

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


            string airlineCode = parts[1];
            string airlineName = parts[0];
            ;
            // adding airline object into a dictionary
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






