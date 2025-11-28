using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookingWebsite.Models
{
    [Table("LOAIMONAN")]
    public class LoaiMonAn
    {
        [Key]
        [Column("MaLoaiMonAn")]
        public int MaLoaiMonAn { get; set; }

        [Column("TenLoaiMonAn")]
        [StringLength(100, ErrorMessage = "{0} không được vượt quá {1} ký tự.")]
        [Display(Name = "Tên loại món ăn")]
        public string? TenLoaiMonAn { get; set; }

        [Column("Mota")]
        [StringLength(200, ErrorMessage = "{0} không được vượt quá {1} ký tự.")]
        [Display(Name = "Mô tả")]
        public string? Mota { get; set; }

        // Navigation property
        public virtual ICollection<CongThucLoaiMonAn> CongThucLoaiMonAns { get; set; } = new List<CongThucLoaiMonAn>();
    }
}



