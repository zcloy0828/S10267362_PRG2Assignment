// See https://aka.ms/new-console-template for more information


using S10267362_PRG2Assignment;

Terminal terminal5 = new Terminal("Terminal 5");
Dictionary<string, Flight> flights = new Dictionary<string, Flight>();
LoadAirlines();
LoadBoardingGates(terminal5.BoardingGates);
LoadFlights(flights, terminal5);