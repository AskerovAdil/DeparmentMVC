    using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models
{
    public class Employee
    {
        [Key]
        public Decimal ID { get; set; }

        public Guid DepartmentID { get; set; }

        [Required(ErrorMessage = "Поле является обязательным")]
        [MaxLength(50, ErrorMessage = "Поле не может быть больше 50 символов")]
        [Display(Name = "Имя")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Поле является обязательным")]
        [MaxLength(50, ErrorMessage = "Поле не может быть больше 50 символов")]
        [Display(Name = "Фамилия")]

        public string FirstName { get; set; }

        [MaxLength(50, ErrorMessage = "Поле не может быть больше 50 символов")]
        [Display(Name = "Отчество")]

        public string? Patronymic { get; set; }

        [Display(Name = "Дата рождения")]
        public DateTime DateOfBirth { get; set; }

        [MaxLength(4)]
        [Display(Name = "Серия документа")]
        public string? DocSeries { get; set; }

        [MaxLength(6, ErrorMessage = "Поле не может быть больше 6 символов")]
        [Display(Name = "Номер документа")]
        public string? DocNumber { get; set; }

        [Required(ErrorMessage = "Поле является обязательным")]
        [MaxLength(50, ErrorMessage = "Поле не может быть больше 50 символов")]
        [Display(Name = "Должность")]
        public string Position { get; set; }


    }
}
