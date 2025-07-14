using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoMVC1.Models
{
    [Table("HeThongPhanPhoi")]
    public class HeThongPhanPhoi
    {
        [Key]
        public string MaHTPP { get; set; }

        [Required]
        public string TenHTPP { get; set; }
        
    }
}
