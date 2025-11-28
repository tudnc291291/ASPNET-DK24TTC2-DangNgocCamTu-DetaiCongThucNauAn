using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookingWebsite.Models
{
    [Table("CONGTHUC_NGUYENLIEU")]
    public class CongThucNguyenLieu
    {
        [Key]
        [Column("ID_CongThuc_NguyenLieu")]
        public int IdCongThucNguyenLieu { get; set; }

        [Column("MaCongThuc")]
        public int MaCongThuc { get; set; }

        [Column("MaNguyenLieu")]
        public int MaNguyenLieu { get; set; }

        // Navigation properties
        [ForeignKey("MaCongThuc")]
        public virtual CongThuc? CongThuc { get; set; }

        [ForeignKey("MaNguyenLieu")]
        public virtual NguyenLieu? NguyenLieu { get; set; }
    }
}



