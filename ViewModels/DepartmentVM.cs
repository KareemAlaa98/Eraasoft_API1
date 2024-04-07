using System.ComponentModel.DataAnnotations;

namespace Task.ViewModels
{
    public class DepartmentVM
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
