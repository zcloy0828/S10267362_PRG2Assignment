// See https://aka.ms/new-console-template for more information









void LoadBoardingGates(Dictionary<string, BoardingGate> boardingGates)
{
    // Load boarding gates from boardinggates.csv
    using (StreamReader sr = new StreamReader("boardinggates.csv"))
    {
        sr.ReadLine();
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            string[] parts = line.Split(',');

            string gateName = parts[0];
            bool supportsCFFT = bool.Parse(parts[1]);
            bool supportsDDJB = bool.Parse(parts[2]);
            bool supportsLWTT = bool.Parse(parts[3]);

            // Create a BoardingGate object and add it to the dictionary
            BoardingGate gate = new BoardingGate(gateName, supportsCFFT, supportsDDJB, supportsLWTT);
            boardingGates.Add(gateName, gate);
        }
    }
}






