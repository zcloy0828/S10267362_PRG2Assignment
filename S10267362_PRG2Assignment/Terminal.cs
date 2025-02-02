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
        public Terminal(string terminalName)
        {
            TerminalName = terminalName;
            Airlines = new Dictionary<string, Airline>();
            Flights = new Dictionary<string, Flight>();
            BoardingGates = new Dictionary<string, BoardingGate>();
            GateFees = new Dictionary<string, double>();
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

        public Airline GetAirlineFromFlight(Flight flightNumber)
        {
            string airlinecode = flightNumber.FlightNumber.Substring(0, 2);
            try
            {
                return Airlines[airlinecode];
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Airline not found!");
                return null;
            }
        }



        public override string ToString()
        {
            return $"Terminal: {TerminalName}, Airlines: {airlines.Count}, Boarding Gates: {boardingGates.Count}, Flights: {flights.Count}";
        }



        //Advanced feature (B)
        public void CalculateTotalFeesPerAirline()
        {
            // this is to check that all flights has a assigned boarding gate
            bool allFlightsAssigned = Flights.Values.All(flight => !string.IsNullOrEmpty(flight.BoardingGate));
            if (!allFlightsAssigned)
            {
                Console.WriteLine("Error: Not all flights have been assigned boarding gates. Please assign boarding gates first.");
                return;
            }

            
            Console.WriteLine("=============================================");
            Console.WriteLine("Airline Fees For Changi Airport Terminal 5");
            Console.WriteLine("=============================================");
            Console.WriteLine("{0, -17}{1, -20}{2, -20}{3, -20}{4, -20}", "Airline Code", "Airline Name", "Subtotal Fees", "Subtotal Discounts", "Total Fees");

            foreach (var airline in Airlines.Values)
            {
                double totalFees = 0;
                double totalDiscounts = 0;

                // calculate the fees and discounts for the airline
                foreach (var flight in airline.Flight.Values)
                {
                    totalFees += flight.CalculateFees();
                }

                int flightCount = airline.Flight.Count;

                // discounts for every third flight
                if (flightCount >= 3)
                {
                    totalDiscounts += 350 * (flightCount / 3);
                }

                foreach (var flight in airline.Flight.Values)
                {
                    if (flight.ExpectedTime.Hour < 11 || flight.ExpectedTime.Hour >= 21)
                    {
                        totalDiscounts += 110;
                    }

                    if (flight.Origin == "Dubai (DXB)" || flight.Origin == "Bangkok (BKK)" || flight.Origin == "Tokyo (NRT)")
                    {
                        totalDiscounts += 25;
                    }

                    if (flight is NORMFlight)
                    {
                        totalDiscounts += 50;
                    }
                }

                // give additional discount for more than 5 flights
                if (flightCount > 5)
                {
                    totalDiscounts += totalFees * 0.03;
                }

                double finalTotal = totalFees - totalDiscounts;

                Console.WriteLine("{0, -17}{1, -20}{2, -20:C}{3, -20:C}{4, -20:C}", airline.Code, airline.Name, totalFees, totalDiscounts, finalTotal);
            }

            // This is to calculate and display overall totals for all airlines
            double overallSubtotalFees = Airlines.Values.Sum(airline => airline.Flight.Values.Sum(flight => flight.CalculateFees()));
            double overallSubtotalDiscounts = Airlines.Values.Sum(airline =>
            {
                double discounts = 0;
                if (airline.Flight.Count >= 3)
                {
                    discounts += 350 * (airline.Flight.Count / 3);
                }
                foreach (var flight in airline.Flight.Values)
                {
                    if (flight.ExpectedTime.Hour < 11 || flight.ExpectedTime.Hour >= 21)
                    {
                        discounts += 110;
                    }
                    if (flight.Origin == "Dubai (DXB)" || flight.Origin == "Bangkok (BKK)" || flight.Origin == "Tokyo (NRT)")
                    {
                        discounts += 25;
                    }
                    if (flight is NORMFlight)
                    {
                        discounts += 50;
                    }
                }
                if (airline.Flight.Count > 5)
                {
                    discounts += airline.Flight.Values.Sum(flight => flight.CalculateFees()) * 0.03;
                }
                return discounts;
            });
            double overallFinalTotal = overallSubtotalFees - overallSubtotalDiscounts;
            double discountPercentage = (overallSubtotalDiscounts / overallFinalTotal) * 100;

            Console.WriteLine("\nOverall Totals for All Airlines");
            Console.WriteLine("=============================================");
            Console.WriteLine($"Overall Subtotal Fees: ${overallSubtotalFees:0.00}");
            Console.WriteLine($"Overall Subtotal Discounts: ${overallSubtotalDiscounts:0.00}");
            Console.WriteLine($"Overall Final Total: ${overallFinalTotal:0.00}");
            Console.WriteLine($"Percentage of Discounts over Final Fees: {discountPercentage:0.00}%");
            Console.WriteLine("=============================================");
        }
    }
}