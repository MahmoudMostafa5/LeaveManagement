using LeaveManagement.LeaveRequests;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LeaveManagement
{
    public interface ILeaveRequestAppService : IApplicationService
    {
        Task<PagedResultDto<LeaveRequestDto>> GetListAsync(GetLeaveRequestListInput input);
        Task<LeaveRequestDto> GetAsync(Guid id);
        Task<LeaveRequestDto> CreateAsync(CreateLeaveRequestDto input);
        Task<LeaveRequestDto> ApproveAsync(Guid id);
        Task<LeaveRequestDto> RejectAsync(Guid id);
        Task DeleteAsync(Guid id);
    }
}
