using Microsoft.Owin.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Owin;
using Restaurants.Data;
using Restaurants.Models;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace Restaurants.Services.Tests
{
    [TestClass]
    public class MealsIntegrationsTests
    {
        private static TestServer server;
        private static HttpClient client;

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            server = TestServer.Create(appBuilder =>
            {
                var config = new HttpConfiguration();
                WebApiConfig.Register(config);
                var webAppStartup = new Startup();
                webAppStartup.Configuration(appBuilder);
                appBuilder.UseWebApi(config);
            });
            client = server.HttpClient;

            Seed();
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            if (server != null)
            {
                server.Dispose();
            }
        }

        private static void Seed()
        {
            var db = new RestaurantsContext();
            db.Restaurants.Add(new Restaurant()
            {
                Name = "Test Restaurant",
                OwnerId = "123owner",
                TownId = 1
            });

            db.Meals.Add(new Meal()
            {
                Name = "Baklava",
                Price = 5.2m,
                RestaurantId = 1,
                TypeId = 2
            });
        }
        
        [TestMethod]
        public void EditExistingMeal_ShouldReturn200Ok_And_MealViewModel()
        {
            var db = new RestaurantsContext();
            var existingMeal = db.Meals.FirstOrDefault();
            if (existingMeal == null)
            {
                Assert.Fail("Failed to add meal to database.");
            }
        }
    }
}
