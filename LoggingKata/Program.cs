using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {

            logger.LogInfo("Log initialized");

            // reads all lines from csv file/path and give error if lines are 0 or 1 and returns error based on if-statement
            var lines = File.ReadAllLines(csvPath);

            if (lines.Length == 0)
            {
                logger.LogError("There is no input.");
            }
            if (lines.Length == 1)
            {
                logger.LogWarning("Warning: There is only 1 line of input.");            }
            logger.LogInfo($"Lines: {lines[0]}");

            //instance of TacoParser class
            var parser = new TacoParser();

            //IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            //parse to an array to be sifted through
            var locations = lines.Select(parser.Parse).ToArray();

            ITrackable tacoBell1 = null; //trackables for 2 locations in the following for loops and then overwrites them
            ITrackable tacoBell2 = null;
            double distance = 0.0; // declaring a distance variable to later overwrite result from getDistanceTo
            

            for (int i = 0; i < locations.Length; i++) //starts here for measuring distance
            {
                
                var locA = locations[i]; //instance of first location at index
                var corA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude); //location(coordinate) details for first location
                
                for (int j = 0; j < locations.Length; j++) //compares to first location to determine distance
                {
                    var locB = locations[j]; //instance of second location at index
                    var corB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude); //location(coordinate) details for second location
                    var newDistance = corA.GetDistanceTo(corB);
                                    
                    
                    if (newDistance > distance) //last check to verify new distance is greater than original distance and if
                                                //not it runs the next set - if it is, it updates original distance so we can print to console.
                    {
                        distance = newDistance; //sets 'distance' to now equal new distance
                        tacoBell1 = locA; //updates previously declared Itrackables to equal the two locations
                        tacoBell2 = locB;
                    }
                }
             
            }
            Console.WriteLine($"{tacoBell1.Name} and {tacoBell2.Name} are {Math.Round((distance/1609.344), 2)} miles apart.");
                //writing to console the two locations furthest apart and distance (converted from meters to miles)

            
        }
    }
}
