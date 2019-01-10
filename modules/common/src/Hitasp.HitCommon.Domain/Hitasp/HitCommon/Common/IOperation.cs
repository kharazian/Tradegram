using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommon.Common
{
    public interface IOperation : IEntity
    {
        string OperationType { get; set; }
        string Number { get; set; }
        bool IsApproved { get; set; }
        string Status { get; set; }
        string Comment { get; set; }
        string Currency { get; set; }
        string ParentOperationId { get; set; }
        IEnumerable<IOperation> ChildrenOperations { get; set; }
    }
}
