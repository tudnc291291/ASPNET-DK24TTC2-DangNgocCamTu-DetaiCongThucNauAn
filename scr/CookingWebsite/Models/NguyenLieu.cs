using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookingWebsite.Models
{
    [Table("NGUYENLIEU")]
    public class NguyenLieu
    {
        [Key]
        [Column("MaNguyenLieu")]
        public int MaNguyenLieu { get; set; }

        [Column("MaLoaiNguyenLieu")]
        [Display(Name = "Loại nguyên liệu")]
        public int MaLoaiNguyenLieu { get; set; }

        [Column("TenNguyenLieu")]
        [StringLength(100, ErrorMessage = "{0} không được vượt quá {1} ký tự.")]
        [Display(Name = "Tên nguyên liệu")]
        public string? TenNguyenLieu { get; set; }

        [Column("SoLuong")]
        [Display(Name = "Số lượng")]
        public double? SoLuong { get; set; }

        [Column("DonVi")]
        [StringLength(20, ErrorMessage = "{0} không được vượt quá {1} ký tự.")]
        [Display(Name = "Đơn vị")]
        public string? DonVi { get; set; }

        // Navigation properties
        [ForeignKey("MaLoaiNguyenLieu")]
        public virtual LoaiNguyenLieu? LoaiNguyenLieu { get; set; }
        public virtual ICollection<CongThucNguyenLieu> CongThucNguyenLieus { get; set; } = new List<CongThucNguyenLieu>();
    }
}



