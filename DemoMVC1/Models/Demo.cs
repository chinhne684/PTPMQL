using System.ComponentModel.DataAnnotations;

namespace DemoMVC1.Models
{
    public class Demo
    {
        [Key] // Đánh dấu ProductId là khóa chính
        public int Id { get; set; }

        public string? Title { get; set; }
        public DateTime ReleaseDate { get; set; } // Ngày phát hành

        public string? Genre { get; set; } // Thể loại
        public decimal Price { get; set; } // Giá
    }
}
