using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingGround.Services.Currency
{
    public interface ICurrencyExchange
    {
        Task<List<CurrencyExchange>> GetCurrencyExchangesAsync();
    }
    // Dependency Inversion Principle
    // Create dependencies from abstraction (interfaces), not from realisation (classes)
}
