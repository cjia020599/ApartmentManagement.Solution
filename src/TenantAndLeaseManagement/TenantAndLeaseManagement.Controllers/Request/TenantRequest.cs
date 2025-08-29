using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantAndLeaseManagement.Controllers.Request
{
    public class TenantRequest
    {
        public required string Name { get; set; } = null!;
        public required string Email { get; set; } = null!;
        public required string PhoneNumber { get; set; } = null!;
    }
}
