using System;
using Xunit;

namespace ActiveLogin.Identity.Swedish.Test
{
    /// <summary>
    /// Tested with offical test Personal Identity Numbers from Skatteverket:
    /// https://skatteverket.entryscape.net/catalog/9/datasets/147
    /// </summary>
    public class SwedishPersonalIdentityNumber_DateOfBirth
    {
        [Theory]
        [InlineData(1899, 09, 13, 980, 1)]
        [InlineData(1912, 02, 11, 998, 6)]
        public void Year_Equals_Year(int year, int month, int day, int serialNumber, int checksum)
        {
            var personalIdentityNumber = new SwedishPersonalIdentityNumber(year, month, day, serialNumber, checksum);
            var dateOfBirth = personalIdentityNumber.DateOfBirth;
            Assert.Equal(year, dateOfBirth.Year);
        }

        [Theory]
        [InlineData(1899, 09, 13, 980, 1)]
        [InlineData(1912, 02, 11, 998, 6)]
        public void Month_Equals_Month(int year, int month, int day, int serialNumber, int checksum)
        {
            var personalIdentityNumber = new SwedishPersonalIdentityNumber(year, month, day, serialNumber, checksum);
            var dateOfBirth = personalIdentityNumber.DateOfBirth;
            Assert.Equal(month, dateOfBirth.Month);
        }

        [Theory]
        [InlineData(1899, 09, 13, 980, 1)]
        [InlineData(1912, 02, 11, 998, 6)]
        public void Day_Equals_Day(int year, int month, int day, int serialNumber, int checksum)
        {
            var personalIdentityNumber = new SwedishPersonalIdentityNumber(year, month, day, serialNumber, checksum);
            var dateOfBirth = personalIdentityNumber.DateOfBirth;
            Assert.Equal(day, dateOfBirth.Day);
        }
    }
}
