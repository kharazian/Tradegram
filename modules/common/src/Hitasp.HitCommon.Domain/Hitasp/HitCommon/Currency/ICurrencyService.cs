using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hitasp.HitCommon.Currency
{
    public interface ICurrencyService
    {
        Task<IEnumerable<Currency>> GetAllCurrenciesAsync();
        
        Task SaveChangesAsync(Currency[] currencies);
        
        Task DeleteCurrenciesAsync(string[] codes);
    }
}
