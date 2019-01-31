using System;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.BackInStockSubscriptions.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.Catalog.BackInStockSubscriptions
{
    public interface IBackInStockSubscriptionAppService : IAsyncCrudAppService<BackInStockSubscriptionDto, Guid,
        BackInStockSubscriptionGetListInput, BackInStockSubscriptionCreateOrUpdateDto>
    {
        Task<PagedResultDto<BackInStockSubscriptionDto>> GetListByCustomerIdAsync(BackInStockSubscriptionGetListByCustomerIdInput input);
        
        Task<PagedResultDto<BackInStockSubscriptionDto>> GetListByProductIdAsync(BackInStockSubscriptionGetListByProductIdInput input);

        Task<BackInStockSubscriptionDto> FindAsync(Guid customerId, Guid productId);

        Task<int> SendNotificationsToSubscribersAsync(Guid productId);
    }
}