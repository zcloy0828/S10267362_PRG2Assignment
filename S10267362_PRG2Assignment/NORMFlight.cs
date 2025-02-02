using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10267362_PRG2Assignment
{
    class NORMFlight : Flight
    {
        public NORMFlight() { }

        public NORMFlight(string flightNumber, string origin, string destination, DateTime expectedTime, string status = "Scheduled") : base(flightNumber, origin, destination, expectedTime, status)
        {

        }

        public override double CalculateFees()
        {
            return base.CalculateFees(); 
        }

        public override string ToString()
        {
            return base.ToString();
        }


    }
}
