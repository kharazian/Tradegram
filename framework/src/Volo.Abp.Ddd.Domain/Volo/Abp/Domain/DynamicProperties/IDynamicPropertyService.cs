using System.Threading.Tasks;

namespace Volo.Abp.Domain.DynamicProperties
{
    public interface IDynamicPropertyService
    {
        Task<DynamicProperty[]> GetDynamicPropertiesAsync(string[] ids);
        
        Task<DynamicProperty[]> SaveDynamicPropertiesAsync(DynamicProperty[] properties);
        
        Task DeleteDynamicPropertiesAsync(string[] propertyIds);

        Task<DynamicPropertyDictionaryItem[]> GetDynamicPropertyDictionaryItemsAsync(string[] ids);
        
        Task SaveDictionaryItemsAsync(DynamicPropertyDictionaryItem[] items);
        
        Task DeleteDictionaryItemsAsync(string[] itemIds);

        Task LoadDynamicPropertyValuesAsync(params IHasDynamicProperties[] owner);

        Task SaveDynamicPropertyValuesAsync(IHasDynamicProperties owner);
        
        Task DeleteDynamicPropertyValuesAsync(IHasDynamicProperties owner);
    }
}
