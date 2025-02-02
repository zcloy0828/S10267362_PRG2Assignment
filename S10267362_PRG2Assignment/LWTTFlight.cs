using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10267362_PRG2Assignment
{
    class LWTTFlight : Flight
    {
        private double requestFee;
        public double RequestFee
        {
            get { return requestFee; }
            set { requestFee = value; }
        }

        public LWTTFlight() { }
        public LWTTFlight(string flightNumber, string origin, string destination, DateTime expectedTime, string status = "Scheduled") : base(flightNumber, origin, destination, expectedTime, status)
        {
            RequestFee = 300;
        }


        public override double CalculateFees()
        {
            double baseFee = base.CalculateFees(); 
            baseFee += 500; 
            return baseFee;

        }

        public override string ToString()
        {
            return base.ToString() + "RequestFee: " + RequestFee;
        }
    }
}
