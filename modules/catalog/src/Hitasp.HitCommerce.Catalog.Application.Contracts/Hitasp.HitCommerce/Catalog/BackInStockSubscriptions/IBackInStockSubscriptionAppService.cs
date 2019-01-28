using System;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.BackInStockSubscriptions.Dtos;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Catalog.BackInStockSubscriptions
{
    public interface IBackInStockSubscriptionAppService
    {
        Task DeleteAsync(Guid subscriptionId);
        
        Task<PagedResultDto<BackInStockSubscriptionDto>> GetListByCustomerIdAsync(BackInStockSubscriptionGetListByCustomerIdInput input);
        
        Task<PagedResultDto<BackInStockSubscriptionDto>> GetListByProductIdAsync(BackInStockSubscriptionGetListByProductIdInput input);

        Task<BackInStockSubscriptionDto> FindAsync(Guid customerId, Guid productId);

        Task<BackInStockSubscriptionDto> GetAsync(Guid subscriptionId);

        Task<BackInStockSubscriptionDto> CreateAsync(BackInStockSubscriptionCreateDto subscription);

        Task<BackInStockSubscriptionDto> UpdateAsync(BackInStockSubscriptionUpdateDto subscription);

        Task<int> SendNotificationsToSubscribersAsync(Guid productId);
    }
}