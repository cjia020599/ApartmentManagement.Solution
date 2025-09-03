using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantAndLeaseManagement.Controllers.Request
{
    public class CreateLeaseAgreementRequest
    {
        public required string TenantName { get; set; } = null!;
        public required string OwnerName { get; set; } = null!;
        public required DateTime CreationDate { get; set; }
        public required Guid IndividualUnitId { get; set; }
        public required double MonthlyRent { get; set; }

    }
}
