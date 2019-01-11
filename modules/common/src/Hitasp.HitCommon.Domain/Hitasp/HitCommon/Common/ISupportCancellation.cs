using System;

namespace Hitasp.HitCommon.Common
{
    public interface ISupportCancellation
    {
        bool IsCancelled { get; set; }
        DateTime? CancelledDate { get; set; }
        string CancelReason { get; set; }
    }
}
