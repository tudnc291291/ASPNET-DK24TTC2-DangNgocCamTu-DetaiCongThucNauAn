using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookingWebsite.Models
{
    [Table("TaiKhoan")]
    public class TaiKhoan
    {
        [Key]
        [Column("TenDangNhap")]
        [StringLength(50, ErrorMessage = "{0} không được vượt quá {1} ký tự.")]
        [Display(Name = "Tên đăng nhập")]
        public string TenDangNhap { get; set; } = string.Empty;

        [Column("MatKhau")]
        [StringLength(50, ErrorMessage = "{0} không được vượt quá {1} ký tự.")]
        [Display(Name = "Mật khẩu")]
        public string? MatKhau { get; set; }
    }
}



