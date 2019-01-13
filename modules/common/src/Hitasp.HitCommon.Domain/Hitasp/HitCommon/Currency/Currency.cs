using Volo.Abp.Domain.Values;

namespace Hitasp.HitCommon.Currency
{
    public class Currency : ValueObject<Currency>
    {
        public string Code { get; private set; }

        public string Name { get; private set; }

        public decimal ExchangeRate { get; private set; }

        public string Symbol { get; private set; }

        public string CustomFormatting { get; private set; }

        private Currency()
        {
        }

        public Currency(
            string code,
            string name,
            decimal exchangeRate,
            string symbol,
            string customFormatting)
        {
            //TODO: validate inputs
            
            Code = code;
            Name = name;
            ExchangeRate = exchangeRate;
            Symbol = symbol;
            CustomFormatting = customFormatting;
        }
    }
}
