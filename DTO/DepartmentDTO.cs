using System.ComponentModel.DataAnnotations;

namespace Task.DTO
{
    public class DepartmentDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
