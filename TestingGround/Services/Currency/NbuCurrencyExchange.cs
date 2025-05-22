using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TestingGround.Services.Currency
{
    public class NbuCurrencyExchange : ICurrencyExchange
    {
        public async Task<List<CurrencyExchange>> GetCurrencyExchangesAsync()
        {
            using HttpClient client = new();
            string json = await client.GetStringAsync("https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json");
        
            var nbuExchange = JsonSerializer.Deserialize<List<NbuExchange>>(json)!;
            return nbuExchange.Select(nbu => new CurrencyExchange
            {
                FullName = nbu.txt,
                ShortName = nbu.cc,
                RateBuy = nbu.rate,
                RateSell = nbu.rate,
                Date = DateOnly.ParseExact(nbu.exchangedate, "dd.MM.yyyy", null)
            }).ToList();
        }

        // ORM
        /*
         {
            "r030": 12,
            "txt": "Алжирський динар",
            "rate": 0.31083,
            "cc": "DZD",
            "exchangedate": "14.05.2025"
          },
        */
        private class NbuExchange
        { 
            public int r030 { get; set; }
            public string txt { get; set; }
            public double rate { get; set; }
            public string cc { get; set; }
            public string exchangedate { get; set; }

        }

    }
}
