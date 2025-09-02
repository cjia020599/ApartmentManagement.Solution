namespace PropertyManagement.Application.Response
{
    public class PropertyResponse
    {
        public Guid Id { get; set; }
        public string Unit { get; set; } = null!;
        public string Building { get; set; } = null!;
        public string Status { get; set; } = null!;
    }
}
