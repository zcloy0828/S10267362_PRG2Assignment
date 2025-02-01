using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10267362_PRG2Assignment
{
    class Terminal
    {
        private string terminalName;
        public string TerminalName
        {
            get { return terminalName; }
            set { terminalName = value; }
        }

        private Dictionary<string, Airline> airlines;
        public Dictionary<string, Airline> Airlines
        {
            get { return airlines; }
            set { airlines = value; }
        }

        private Dictionary<string, Flight> flights;
        public Dictionary<string, Flight> Flights
        {
            get { return flights; }
            set { flights = value; }
        }

        private Dictionary<string, BoardingGate> boardingGates;
        public Dictionary<string, BoardingGate> BoardingGates
        {
            get { return boardingGates; }
            set { boardingGates = value; }
        }

        private Dictionary<string, double> gateFees;
        public Dictionary<string, double> GateFees
        {
            get { return gateFees; }
            set { gateFees = value; }
        }


        public Terminal() { }
        public Terminal(string terminalName, Dictionary<string, Airline> airlines, Dictionary<string, Flight> flights, Dictionary<string, BoardingGate> boardingGates, Dictionary<string, double> gateFees)
        {
            TerminalName = terminalName;
            Airlines = airlines;
            Flights = flights;
            BoardingGates = boardingGates;
            GateFees = gateFees;
        }

        public bool AddAirline(Airline a)
        {
            try
            {
                airlines.Add(a.Code, a); return true;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Airline already exists in the terminal.");
                return false;
            }
        }



        public void AddBoardingGate(BoardingGate gate)
        {
            try
            {
                boardingGates.Add(gate.GateName, gate);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Boarding gate already exists in the terminal.");
            }
        }

        public Airline GetAirlineFromFlight(string flightNumber)
        {
            foreach (var airline in airlines.Values)
            {
                if (airline.Flight.ContainsKey(flightNumber))
                {
                    return airline;
                }
            }
            return null; // Return null if the flight is not associated with any airline
        }

        public override string ToString()
        {
            return $"Terminal: {TerminalName}, Airlines: {airlines.Count}, Boarding Gates: {boardingGates.Count}, Flights: {flights.Count}";
        }
    }
}
