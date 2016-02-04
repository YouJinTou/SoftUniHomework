using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurants.Data;

namespace Restaurants.Services.Tests
{
    [TestClass]
    public class MealsIntegrationsTests
    {
        [TestInitialize]
        public void Testinit()
        {
            var db = new RestaurantsContext();
        }

        [TestMethod]
        public void EditExistingMeal_ShouldReturn200Ok()
        {
            
        }
    }
}
