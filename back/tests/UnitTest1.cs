using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwitterApi.Controllers;

namespace ApiTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var meteo = new WeatherForecastController(null);
            
            var actual = meteo.Get();
            
            Assert.IsInstanceOfType(actual, typeof(Array));
        }
    }
}
