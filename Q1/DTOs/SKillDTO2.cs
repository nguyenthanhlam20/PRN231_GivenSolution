namespace Q1.DTOs
{
    public class SKillDTO2
    {
        public int SkillId { get; set; }
        public string SkillName { get; set; } = null!;
        public string? Description { get; set; }
        public int numberOfEmployee {  get; set; }  
        public List<EmployeeDTO> employees { get; set; }
    }
}
