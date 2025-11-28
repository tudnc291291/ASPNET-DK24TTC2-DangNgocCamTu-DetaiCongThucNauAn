using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookingWebsite.Models
{
    [Table("CACBUOCNAU")]
    public class CacBuocNau
    {
        [Key]
        [Column("MaBuoc")]
        public int MaBuoc { get; set; }

        [Column("MaCongThuc")]
        public int MaCongThuc { get; set; }

        [Column("BuocThucHien")]
        [Display(Name = "Bước thực hiện")]
        public int? BuocThucHien { get; set; }

        [Column("HuongDan")]
        [Display(Name = "Hướng dẫn")]
        public string? HuongDan { get; set; }

        // Navigation property
        [ForeignKey("MaCongThuc")]
        public virtual CongThuc? CongThuc { get; set; }
    }
}



