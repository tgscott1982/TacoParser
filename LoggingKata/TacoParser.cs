namespace LoggingKata
{
    /// <summary>
    /// Parses a POI/CSV file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            //logger.LogInfo("Begin parsing");  //commented out to prevent from writing to console for every location

            //Use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            
            if (cells.Length < 3) //checks if each line in cvs file has 3 items after splitting each element
            {
                logger.LogError("Error: List has less than 3 items.");
              
                return null; // returns null versus failing if doesn't pass
            }

            var latitude = double.Parse(cells[0]); //declaring, initializing and/or parsing each line item in array at their index
            var longitude = double.Parse(cells[1]);
            var name = cells[2];

            // creates instance of taco bell and stores name/location info in it to be returned
            var tacoBell = new TacoBell() { Name = name, Location = new Point() { Longitude = longitude, Latitude = latitude } };
            

            return tacoBell;
        }
    }
}