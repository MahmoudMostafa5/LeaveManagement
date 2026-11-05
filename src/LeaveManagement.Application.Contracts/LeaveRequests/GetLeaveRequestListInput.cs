using Volo.Abp.Application.Dtos;

namespace LeaveManagement.LeaveRequests
{
    public class GetLeaveRequestListInput : PagedAndSortedResultRequestDto
    {
        public LeaveStatus? Status { get; set; }
    }
}
