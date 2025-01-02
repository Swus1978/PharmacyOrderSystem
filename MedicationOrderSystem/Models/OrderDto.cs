namespace MedicationOrderSystem.Models
{
    public class OrderDto
    {
        public string? MedicationName { get; set; }
        public string? MedicationType { get; set; }
        public int? Quantity { get; set; }
        public string? Distributor { get; set; }
        public string? PharmacyBranch { get; set; }
    }
}
