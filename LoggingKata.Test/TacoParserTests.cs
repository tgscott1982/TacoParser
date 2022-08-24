using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            //stating data can be parsed

            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory] //test data for parsing longitude
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]

        public void ShouldParseLongitude(string line, double expected)
        {
            //"line" represents input data we will Parse to
            //extract the Longitude. csv file will have these lines,
            //each representing a TacoBell location

            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse(line);

            //Assert
            Assert.Equal(expected, actual.Location.Longitude);
        }


        [Theory]  //test data for parsing latitude
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]

        public void ShouldParseLatitude(string line, double expected)
        {

            var tacoParser = new TacoParser();

            var actual = tacoParser.Parse(line);

            Assert.Equal(expected, actual.Location.Latitude);

        }

    }
}
