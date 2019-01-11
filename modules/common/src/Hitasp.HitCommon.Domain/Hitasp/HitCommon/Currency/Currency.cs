using Volo.Abp.Domain.Values;

namespace Hitasp.HitCommon.Currency
{
    public class Currency : ValueObject<Currency>
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public decimal ExchangeRate { get; set; }

        public string Symbol { get; set; }

        public string CustomFormatting { get; set; }
    }
}
