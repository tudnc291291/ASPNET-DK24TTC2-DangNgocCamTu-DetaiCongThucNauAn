using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookingWebsite.Models
{
    [Table("CONGTHUC")]
    public class CongThuc
    {
        [Key]
        [Column("MaCongThuc")]
        public int MaCongThuc { get; set; }

        [Column("TenCongThuc")]
        [StringLength(100, ErrorMessage = "{0} không được vượt quá {1} ký tự.")]
        [Display(Name = "Tên công thức")]
        public string? TenCongThuc { get; set; }

        [Column("MoTa")]
        [StringLength(1000, ErrorMessage = "{0} không được vượt quá {1} ký tự.")]
        [Display(Name = "Mô tả")]
        public string? MoTa { get; set; }

        [Column("ThoiGianChuanBi")]
        [Display(Name = "Thời gian chuẩn bị")]
        public int? ThoiGianChuanBi { get; set; }

        [Column("TongThoiGianNau")]
        [Display(Name = "Tổng thời gian nấu")]
        public int? TongThoiGianNau { get; set; }

        [Column("PhucVu")]
        [Display(Name = "Khẩu phần")]
        public int? PhucVu { get; set; }

        [Column("TacGia")]
        [StringLength(50, ErrorMessage = "{0} không được vượt quá {1} ký tự.")]
        [Display(Name = "Tác giả")]
        public string? TacGia { get; set; }

        [Column("Anh")]
        [StringLength(200, ErrorMessage = "{0} không được vượt quá {1} ký tự.")]
        [Display(Name = "Ảnh")]
        public string? Anh { get; set; }

        [Column("AnhChiTiet")]
        [StringLength(100, ErrorMessage = "{0} không được vượt quá {1} ký tự.")]
        [Display(Name = "Ảnh chi tiết")]
        public string? AnhChiTiet { get; set; }

        // Navigation properties
        public virtual ICollection<CacBuocNau> CacBuocNaus { get; set; } = new List<CacBuocNau>();
        public virtual ICollection<CongThucNguyenLieu> CongThucNguyenLieus { get; set; } = new List<CongThucNguyenLieu>();
        public virtual ICollection<CongThucLoaiMonAn> CongThucLoaiMonAns { get; set; } = new List<CongThucLoaiMonAn>();
    }
}



