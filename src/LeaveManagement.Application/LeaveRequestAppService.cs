using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using LeaveManagement.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace LeaveManagement.LeaveRequests;

[Authorize(LeaveManagementPermissions.LeaveRequests.Default)]
public class LeaveRequestAppService : LeaveManagementAppService, ILeaveRequestAppService
{
    private readonly IRepository<LeaveRequest, Guid> _repository;

    public LeaveRequestAppService(IRepository<LeaveRequest, Guid> repository)
    {
        _repository = repository;
    }

    public async Task<PagedResultDto<LeaveRequestDto>> GetListAsync(GetLeaveRequestListInput input)
    {
        var canSeeAll = await AuthorizationService.IsGrantedAsync(
            LeaveManagementPermissions.LeaveRequests.Approve);

        var query = (await _repository.GetQueryableAsync())
            .WhereIf(input.Status.HasValue, x => x.Status == input.Status!.Value)
            .WhereIf(!canSeeAll, x => x.CreatorId == CurrentUser.Id);

        var totalCount = await AsyncExecuter.CountAsync(query);

        var items = await AsyncExecuter.ToListAsync(
            query.OrderByDescending(x => x.CreationTime)
                 .Skip(input.SkipCount)
                 .Take(input.MaxResultCount));

        return new PagedResultDto<LeaveRequestDto>(
            totalCount,
            items.Select(ToDto).ToList());
    }

    public async Task<LeaveRequestDto> GetAsync(Guid id)
    {
        var entity = await _repository.GetAsync(id);
        return ToDto(entity);
    }

    [Authorize(LeaveManagementPermissions.LeaveRequests.Create)]
    public async Task<LeaveRequestDto> CreateAsync(CreateLeaveRequestDto input)
    {
        var entity = new LeaveRequest(
            GuidGenerator.Create(), input.StartDate, input.EndDate, input.Reason);

        await _repository.InsertAsync(entity);
        return ToDto(entity);
    }

    [Authorize(LeaveManagementPermissions.LeaveRequests.Approve)]
    public async Task<LeaveRequestDto> ApproveAsync(Guid id)
    {
        var entity = await _repository.GetAsync(id);
        entity.Approve();
        await _repository.UpdateAsync(entity);
        return ToDto(entity);
    }

    [Authorize(LeaveManagementPermissions.LeaveRequests.Approve)]
    public async Task<LeaveRequestDto> RejectAsync(Guid id)
    {
        var entity = await _repository.GetAsync(id);
        entity.Reject();
        await _repository.UpdateAsync(entity);
        return ToDto(entity);
    }

    [Authorize(LeaveManagementPermissions.LeaveRequests.Delete)]
    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }

    private static LeaveRequestDto ToDto(LeaveRequest x) => new()
    {
        Id = x.Id,
        StartDate = x.StartDate,
        EndDate = x.EndDate,
        Reason = x.Reason,
        Status = x.Status,
        CreationTime = x.CreationTime,
        CreatorId = x.CreatorId
    };
}