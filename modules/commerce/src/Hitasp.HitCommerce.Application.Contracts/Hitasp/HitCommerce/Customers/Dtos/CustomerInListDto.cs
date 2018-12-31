using System;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Customers.Dtos
{
    public class CustomerInListDto : EntityDto<Guid>
    {
        public string UserName { get; set; }
        
        public string Name { get; set; }
        
        public string SurName { get; set; }
    }
}