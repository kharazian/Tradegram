using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Widgets
{
    public interface IWidgetRepository : IRepository<Widget, Guid>
    {
        Task<Widget> FindByName(string name);
    }
}