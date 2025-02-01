using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10267362_PRG2Assignment
{
    class BoardingGate
    {
        private string gateName;
        public string GateName
        {
            get { return gateName; }
            set { gateName = value; }
        }

        private bool supportsCFFT;
        public bool SupportsCFFT
        {
            get { return supportsCFFT; }
            set { supportsCFFT = value; }
        }

        private bool supportsDDJB;
        public bool SupportsDDJB
        {
            get { return supportsDDJB; }
            set { supportsDDJB = value; }
        }

        private bool supportsLWTT;
        public bool SupportsLWTT
        {
            get { return supportsLWTT; }
            set { supportsLWTT = value; }
        }


        public Flight Flight { get; set; }


        public BoardingGate() { }

        public BoardingGate(string gateName, bool supportsCFFT, bool supportsDDJB, bool supportsLWTT) //added Flight flight (daygene)
        {
            GateName = gateName;
            SupportsCFFT = supportsCFFT;
            SupportsDDJB = supportsDDJB;
            SupportsLWTT = supportsLWTT;
            Flight = null;
        }



        public double CalculateFees()
        {
            return 0.0;
        }

        public override string ToString()
        {
            return "GateName: " + GateName + "\tSupportsCFFT: " + SupportsCFFT + "\tSupportsDDJB: " + SupportsDDJB + "SupportsLWTT: " + SupportsLWTT;
        }
    }
}

