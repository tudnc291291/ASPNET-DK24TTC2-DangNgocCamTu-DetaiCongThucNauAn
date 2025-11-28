using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookingWebsite.Models
{
    [Table("CONGTHUC_LOAIMONAN")]
    public class CongThucLoaiMonAn
    {
        [Column("MaCongThuc")]
        public int MaCongThuc { get; set; }

        [Column("MaLoaiMonAn")]
        public int MaLoaiMonAn { get; set; }

        // Navigation properties
        [ForeignKey("MaCongThuc")]
        public virtual CongThuc? CongThuc { get; set; }

        [ForeignKey("MaLoaiMonAn")]
        public virtual LoaiMonAn? LoaiMonAn { get; set; }
    }
}



