using Xunit;

namespace ActiveLogin.Identity.Swedish.Test
{
    /// <remarks>
    /// Tested with offical test Personal Identity Numbers from Skatteverket:
    /// https://skatteverket.entryscape.net/catalog/9/datasets/147
    /// </remarks>
    public class SwedishPersonalIdentityNumber_Constructor
    {
        [Fact]
        public void CSharp_Should_Have_No_Public_Constructor()
        {
            var type = typeof(SwedishPersonalIdentityNumber);
            var constructors = type.GetConstructors();

            Assert.Empty(constructors);
        }

        [Fact]
        public void FSharp_Should_Have_No_Public_Constructor()
        {
            var type = typeof(FSharp.SwedishPersonalIdentityNumber);
            var constructors = type.GetConstructors();

            Assert.Empty(constructors);
        }
    }
}
