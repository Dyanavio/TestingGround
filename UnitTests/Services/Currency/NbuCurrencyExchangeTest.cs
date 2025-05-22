using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingGround.Services.Currency;

namespace UnitTests.Services.Currency
{
    //[TestClass]
    public sealed class NbuCurrencyExchangeTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            NbuCurrencyExchange exchange = new NbuCurrencyExchange();
            Assert.IsNotNull(exchange, "Default constructor must create an object");
        }
        [TestMethod]
        public void InterfaceTest() 
        {
            NbuCurrencyExchange exchange = new();
            Assert.IsInstanceOfType<ICurrencyExchange>(exchange, "The corresponding currency exchange service must implement ICurrencyExchange interface");
            Assert.IsNotInstanceOfType<CurrencyExchange>(exchange, "The corresponding currency exchange service must implement ICurrencyExchange interface\"");
        }
        [TestMethod]
        public void GetCurrencyExchangeAsyncTest()
        {
            NbuCurrencyExchange exchange = new();
            var task = exchange.GetCurrencyExchangesAsync();
            Assert.IsNotNull(task, "GetCurrencyExchangeAsync must not return null");
            Assert.IsInstanceOfType<Task>(task, "GetCurrencyExchangeAsync must return async Task result");

            var rates = task.Result;
            Assert.IsNotNull(rates, "Result of task must not be null");
            Assert.IsInstanceOfType<List<CurrencyExchange>>(rates, "GetCurrencyExchangeAsync task result must be a List of CurrencyExchange");
            Assert.IsTrue(rates.Any(), "The task resulting collection must not be empty");
        }
    }
}
