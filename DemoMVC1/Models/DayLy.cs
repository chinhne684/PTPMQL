using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoMVC1.Models
{
    [Table("DaiLy")]
    public class DaiLy
    {
        [Key]
        [Required]
        public string MaDaiLy { get; set; } = string.Empty;

        [Required]
        public string TenDaiLy { get; set; } = string.Empty;

        [Required]
        public string DiaChi { get; set; } = string.Empty;

        [Required]
        public string NguoiDaiDien { get; set; } = string.Empty;

        [Required]
        public string DienThoai { get; set; } = string.Empty;

        [Required]
        [ForeignKey("HeThongPhanPhoi")]
        public string MaHTPP { get; set; } = string.Empty;

        public HeThongPhanPhoi HeThongPhanPhoi { get; set; } = new();
    }
}
