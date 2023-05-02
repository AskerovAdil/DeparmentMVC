    using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models
{
    public class Employee
    {


        [Key]
        public int ID { get; set; }

        public int DepartmentID { get; set; }
        [Required]
        [MaxLength(50)]
        public string SurName { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string? Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }

        [MaxLength(4)]
        public string? DocSeries { get; set; }

        [MaxLength(6)]
        public string? DocNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string Position { get; set; }


    }
}
