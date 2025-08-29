using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantAndLeaseManagement.Controllers.Request
{
    public class RenewLeaseAgreement
    {
        public required DateTime RenewDate { get; set; }
        public double? NewMonthlyRent { get; set; }
    }
}
