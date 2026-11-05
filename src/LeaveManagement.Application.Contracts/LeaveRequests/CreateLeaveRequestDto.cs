using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LeaveManagement.LeaveRequests
{
    public class CreateLeaveRequestDto
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        [StringLength(500)]
        public string Reason { get; set; } = string.Empty;
    }
}
