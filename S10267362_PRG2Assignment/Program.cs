// See https://aka.ms/new-console-template for more information





Dictionary<string, Flight> flights = new Dictionary<string, Flight>();
void LoadFlights()
{
    using (StreamReader sr = new StreamReader("flights.csv"))
    {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            string[] parts = line.Split(',');
            string flightNumber = parts[0];
            string origin = parts[1];
            string destination = parts[2];
            DateTime expectedTime;
            if (!DateTime.TryParse(parts[3], out expectedTime))
            {
                // Log or handle the invalid DateTime string
                continue;
            }
            string status = parts[4];

            DDJBFlight flight = new DDJBFlight(flightNumber, origin, destination, expectedTime, status);
            flights.Add(flightNumber, flight);
        }
    }
}