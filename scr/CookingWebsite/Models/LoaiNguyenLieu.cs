using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookingWebsite.Models
{
    [Table("LOAINGUYENLIEU")]
    public class LoaiNguyenLieu
    {
        [Key]
        [Column("MaLoaiNguyenLieu")]
        public int MaLoaiNguyenLieu { get; set; }

        [Required(ErrorMessage = "{0} là bắt buộc.")]
        [Column("TenLoai")]
        [StringLength(20, ErrorMessage = "{0} không được vượt quá {1} ký tự.")]
        [Display(Name = "Tên loại")]
        public string TenLoai { get; set; } = string.Empty;

        [Column("MoTa")]
        [StringLength(200, ErrorMessage = "{0} không được vượt quá {1} ký tự.")]
        [Display(Name = "Mô tả")]
        public string? MoTa { get; set; }

        // Navigation property
        public virtual ICollection<NguyenLieu> NguyenLieus { get; set; } = new List<NguyenLieu>();
    }
}



