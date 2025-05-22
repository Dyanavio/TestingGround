using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingGround.Services.Currency
{
    public class CurrencyExchange
    {
        public string FullName { get; set; } = null!;
        public string ShortName { get; set; } = null!;
        public double RateBuy { get; set; }
        public double RateSell { get; set; }
        public DateOnly Date { get; set; }
    }
}
