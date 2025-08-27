using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantAndLeaseManagement.Application.Response
{
    public class TenantResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public List<LeaseAgreementResponse> LeaseAgreements { get; set; } = [];
    }
}
