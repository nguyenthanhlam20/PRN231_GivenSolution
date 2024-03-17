namespace Q1.DTOs
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = null!;
        public int? Department { get; set; }
        public string? ProficiencyLevel { get; set; }
        public DateTime? AcquiredDate { get; set; }
    }
}
