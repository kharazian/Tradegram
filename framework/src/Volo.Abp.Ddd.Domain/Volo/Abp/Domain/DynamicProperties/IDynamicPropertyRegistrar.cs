using System.Collections.Generic;

namespace Volo.Abp.Domain.DynamicProperties
{
    public interface IDynamicPropertyRegistrar
    {
        IEnumerable<string> AllRegisteredTypeNames { get; }

        void RegisterType<T>() where T : IHasDynamicProperties;
    }
}
