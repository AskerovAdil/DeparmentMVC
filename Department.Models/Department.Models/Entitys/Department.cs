using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models
{
    public class Department
    {

        [Key]
        public Guid ID { get; set; }
        
        public Guid? ParentDepartmentID { get; set; }

        [MaxLength(10)]
        public string? Code { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

    }
}
