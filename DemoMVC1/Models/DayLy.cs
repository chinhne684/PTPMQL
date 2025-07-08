using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoMVC1.Models
{
    public class DaiLy
    {
        [Key]
        public string? MaDaiLy { get; set; }

        public string? TenDaiLy { get; set; }

        public string? DiaChi { get; set; }

        public string? NguoiDaiDien { get; set; }

        public string? DienThoai { get; set; }

        [ForeignKey("HeThongPhanPhoi")]
        public string? MaHTPP { get; set; }

        public HeThongPhanPhoi? HeThongPhanPhoi { get; set; }
    }
}
