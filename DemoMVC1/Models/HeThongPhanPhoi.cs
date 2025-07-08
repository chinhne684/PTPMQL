using System.ComponentModel.DataAnnotations;

namespace DemoMVC1.Models
{
    public class HeThongPhanPhoi
    {
        [Key]
        public string? MaHTPP { get; set; }

        public string? TenHTPP { get; set; }
    }
}
