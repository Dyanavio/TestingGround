using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TestingGround.Services.Currency;

namespace TestingGround.Services.Currency
{
    //[TestClass]
    public sealed class MonoCurrencyExchangeTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            var exchange = new MonoCurrencyExchange();
            //exchange = null!;
            Assert.IsNotNull(exchange, "Default constructor must create an object");
            //Assert.IsNull(exchange);
        }

        [TestMethod]
        public void InterfaceTest()
        {
            var exchange = new MonoCurrencyExchange();
            Assert.IsInstanceOfType<ICurrencyExchange>(exchange, "The corresponding service has to implement ICurrencyExchange before providing services");
            Assert.IsNotInstanceOfType<CurrencyExchange>(exchange, "The corresponding service has to implement ICurrencyExchange before providing services");
        }

        [TestMethod]
        public void GetCurrencyExchangesAsyncTest()
        {
            MonoCurrencyExchange exchange = new MonoCurrencyExchange();
            var task = exchange.GetCurrencyExchangesAsync();
            Assert.IsNotNull(task, "GetCurrencyExchangeAsync must not return null result");
            Assert.IsInstanceOfType<Task>(task, "GetCurrencyExchangeAsync must return async Task result");

            var rates = task.Result;
            //rates = null;
            Assert.IsNotNull(rates, "Result of task must not be null");
            Assert.IsInstanceOfType<List<CurrencyExchange>>(rates, "GetCurrencyExchangeAsync task result must be a List of CurrencyExchange");
            Assert.IsTrue(rates.Any(), "The task resulting collection must not be empty");
        }

    }
}
