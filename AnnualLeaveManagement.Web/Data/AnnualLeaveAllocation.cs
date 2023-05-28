using System.ComponentModel.DataAnnotations.Schema;

namespace AnnualLeaveManagement.Web.Data
{
    public class AnnualLeaveAllocation : BaseEntity
    {       
        public int NumberOfDays { get; set; }

        [ForeignKey("AnnualLeaveTypeId")]
        public AnnualLeaveType AnnualLeaveType { get; set; }
        public int AnnualLeaveTypeId { get; set; }

        public string EmployeeId { get; set; }
    }
}
