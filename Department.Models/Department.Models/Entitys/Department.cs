using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models
{
    public class Department
    {

        [Key]
        public Guid ID { get; set; }
        
        public Guid? ParentDepartmentID { get; set; }

        [MaxLength(10, ErrorMessage = "Поле не может быть больше 10 символов")]
        public string? Code { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [MaxLength(50, ErrorMessage = "Поле не может быть больше 50 символов")]
        public string Name { get; set; }

    }
}
