// See https://aka.ms/new-console-template for more information





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
            ;
            // adding airline object into a dictionary
            Airline airline = new Airline(airlineName, airlineCode);
            terminal5.Airlines.Add(airlineCode, airline);
        }
    }
}



