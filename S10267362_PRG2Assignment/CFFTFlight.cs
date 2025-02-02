using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10267362_PRG2Assignment
{
    class CFFTFlight : Flight
    {
        private double requestFee;
        public double RequestFee
        {
            get { return requestFee; }
            set { requestFee = value; }
        }

        public CFFTFlight() { }

        public CFFTFlight(string flightNumber, string origin, string destination, DateTime expectedTime, string status = "Scheduled") : base(flightNumber, origin, destination, expectedTime, status)
        {
            RequestFee = requestFee;
        }

        public override double CalculateFees()
        {
            double baseFee = base.CalculateFees();
            baseFee += 150;
            return baseFee;
        }

        public override string ToString()
        {
            return base.ToString() + "RequestFee: " + RequestFee;
        }
    }
}
