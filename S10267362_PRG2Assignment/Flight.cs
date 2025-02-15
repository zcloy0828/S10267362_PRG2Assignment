﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10267362_PRG2Assignment
{
    abstract class Flight
    {
        private string flightNumber;
        public string FlightNumber
        {
            get { return flightNumber; }
            set { flightNumber = value; }
        }

        private string origin;
        public string Origin
        {
            get { return origin; }
            set { origin = value; }
        }

        private string destination;
        public string Destination
        {
            get { return destination; }
            set { destination = value; }
        }

        private DateTime expectedTime;
        public DateTime ExpectedTime
        {
            get { return expectedTime; }
            set { expectedTime = value; }
        }

        private string status;
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        private string boardingGate;
        public string BoardingGate
        {
            get { return boardingGate; }
            set { boardingGate = value; }
        }

        public Flight() { }

        public Flight(string flightNumber, string origin, string destination, DateTime expectedTime, string status = "Scheduled")
        {
            FlightNumber = flightNumber;
            Origin = origin;
            Destination = destination;
            ExpectedTime = expectedTime;
            Status = status;
            BoardingGate = "";


        }

        public virtual double CalculateFees()
        {
            double baseFee = 0;
            if (Destination == "Singapore (SIN)")
            {
                baseFee += 500; 
            }
            else if (Origin == "Singapore (SIN)")
            {
                baseFee += 800; 
            }
            baseFee += 300;

            return baseFee;
        }


        public override string ToString()
        {
            return "FlightNumber: " + flightNumber + "\tOrigin: " + origin + "\tDestination: " + destination + "\tExpectedTime: " + expectedTime + "\tStatus: " + status + "\tBoardingGate: " + boardingGate;
        }
    }
}
