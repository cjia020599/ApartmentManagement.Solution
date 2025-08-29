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
