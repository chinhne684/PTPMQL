using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoMVC1.Models
{
    [Table("Employees")]
    public class Employee : Person
    {
        [Required]
        public string EmployeeId { get; set; }

        public int Age { get; set; }
    }
}
