using System;
using Volo.Abp.Application.Dtos;

namespace LeaveManagement.LeaveRequests
{
    public class LeaveRequestDto : EntityDto<Guid>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; } = string.Empty;
        public LeaveStatus Status { get; set; }
        public DateTime CreationTime { get; set; }
        public Guid? CreatorId { get; set; }
    }
}
