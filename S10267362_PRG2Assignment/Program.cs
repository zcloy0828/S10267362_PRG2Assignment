// See https://aka.ms/new-console-template for more information





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
