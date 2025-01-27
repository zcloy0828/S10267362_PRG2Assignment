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

        public NORMFlight(string flightNumber, string origin, string destination, DateTime expectedTime, string status) : base(flightNumber, origin, destination, expectedTime, status)
        {

        }

        public override double CalculateFees()
        {
            return base.CalculateFees(); //auto comment ... need to chekc slides see how to do this part
        }

        public override string ToString()
        {
            return base.ToString();
        }


    }
}
