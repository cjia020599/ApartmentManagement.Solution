namespace TenantAndLeaseManagement.Application.Response
{
    public class LeaseAgreementResponse
    {
        public Guid Id { get; set; }
        public string TenantName { get; set; } = null!;
        public string OwnerName { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public DateTime TerminationDate { get; set; }
        public string Building { get; set; } = null!;
        public string Unit { get; set; } = null!;
        public double MonthlyRent { get; set; }
    }
}
