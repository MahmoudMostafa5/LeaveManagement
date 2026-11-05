using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace LeaveManagement.LeaveRequests
{
    public class LeaveRequest : FullAuditedAggregateRoot<Guid>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
        public LeaveStatus Status { get; set; }

        protected LeaveRequest() { }

        public LeaveRequest(Guid id, DateTime startDate, DateTime endDate, string reason)
            : base(id)
        {
            if (endDate < startDate)
            {
                throw new BusinessException("LeaveManagement:InvalidLeaveDates");
            }


            StartDate = startDate;
            EndDate = endDate;
            Reason = Check.NotNullOrWhiteSpace(reason, nameof(reason), maxLength: 500);
            Status = LeaveStatus.Pending;
        }

        public void Approve()
        {
            EnsurePending();
            Status = LeaveStatus.Approved;
        }

        public void Reject()
        {
            EnsurePending();
            Status = LeaveStatus.Rejected;
        }

        private void EnsurePending()
        {
            if (Status != LeaveStatus.Pending)
            {
                throw new BusinessException("LeaveManagement:LeaveAlreadyProcessed");
            }
        }

    }
}
