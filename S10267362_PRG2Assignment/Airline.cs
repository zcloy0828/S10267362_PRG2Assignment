using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10267362_PRG2Assignment
{
    class Airline
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string code;
        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        private Dictionary<string, Flight> flight;
        public Dictionary<string, Flight> Flight
        {
            get { return flight; }
            set { flight = value; }
        }

        public Airline() { }

        public Airline(string name, string code)
        {
            Name = name;
            Code = code;
            Flight = new Dictionary<string, Flight>();
        }

        public bool AddFlight(Flight flight)
        {
            if (!Flight.ContainsKey(flight.FlightNumber))
            {
                Flight.Add(flight.FlightNumber, flight);
                return true;
            }
            return false;
        }


        public double CalculateFees()
        {
            double totalFees = 0;
            foreach (var flight in Flight.Values)
            {
                totalFees += flight.CalculateFees();
            }
            return totalFees;
        }

        public bool RemoveFlight(Flight flight)
        {
            if (Flight.ContainsKey(flight.FlightNumber))
            {
                Flight.Remove(flight.FlightNumber);
                return true;
            }
            return false;
        }

        public string Tostring()
        {
            return $"Name: {name}\tCode: {code}\tFlights: {flight.Count}";
        }

    }
}
