using Q1.Models;

namespace Q1.DTOs
{
    public class SKillDTO
    {
        public int SkillId { get; set; }
        public string SkillName { get; set; } = null!;
        public string? Description { get; set; }
        public int numberOfEmployee {  get; set; }
    }
}
