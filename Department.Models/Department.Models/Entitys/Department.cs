using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models
{
    public class Department
    {

        [Key]
        public int ID { get; set; }
        
        public int? ParentDepartmentID { get; set; }

        [MaxLength(10)]
        public string? Code { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

    }
}
