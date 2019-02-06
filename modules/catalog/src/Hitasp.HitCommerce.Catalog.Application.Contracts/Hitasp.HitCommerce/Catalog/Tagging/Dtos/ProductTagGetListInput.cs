using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Catalog.Tagging.Dtos
{
    public class ProductTagGetListInput : PagedAndSortedResultRequestDto
    {
        public IEnumerable<Guid> Ids { get; set; }
    }
}