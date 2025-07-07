namespace DemoMVC.Models
{
    public class DaiLy
    {
        public string? MaDaiLy { get; set; }
        public string? TenDaiLy { get; set; }
        public string? DiaChi { get; set; }
        public string? NguoiDaiDien { get; set; }
        public string? DienThoai { get; set; }

        // Khóa ngoại
        public string? MaHTPP { get; set; }

        // Navigation property (liên kết với HeThongPhanPhoi)
        public HeThongPhanPhoi? HeThongPhanPhoi { get; set; }
    }
}
