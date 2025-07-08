using System.ComponentModel.DataAnnotations;

namespace DemoMVC1.Models
{
    public class Employee : Person
    {
        public string? EmployeeId { get; set; }

        public int Age { get; set; }
    }
}
