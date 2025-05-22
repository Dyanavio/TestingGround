using System.Text;
using TestingGround.Services.Currency;

namespace TestingGround
{
    public class Program
    {
        static void OutputExchange(List<CurrencyExchange> rates)
        {
            Console.WriteLine("Count: " + rates.Count);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            foreach (var rate in rates)
            {
                Console.WriteLine($"{rate.FullName} - {rate.ShortName} - {rate.RateBuy} / {rate.RateSell}");
            }

            Console.ResetColor();
        }
        public static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Bad asynchronicity
            // Implementing the dependency from ABSTRACTION (interface)
            //ICurrencyExchange currency = new MonoCurrencyExchange();
            //var rates = await currency.GetCurrencyExchangesAsync();
            //OutputExchange(rates);

            var task1 = new NbuCurrencyExchange().GetCurrencyExchangesAsync();
            var task2 = new MonoCurrencyExchange().GetCurrencyExchangesAsync();

            var rates1 = await task1;
            var rates2 = await task2;

            OutputExchange(rates1);
            OutputExchange(rates2);

        }
    }
}
