using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Data_Access_Layer_QLBH.Models
{
    [Table("Hang")]
    public partial class Hang
    {
        [Key]
        public int MaHang { get; set; }
        [Key]
        [StringLength(50)]
        public string TenHang { get; set; }
        public int SoLuong { get; set; }
        public double DonGiaBan { get; set; }
        [Column("DonGiaNHAP")]
        public double DonGiaNhap { get; set; }
        [Required]
        [StringLength(400)]
        public string HinhAnh { get; set; }
        [Required]
        [Column("ghiChu")]
        [StringLength(20)]
        public string GhiChu { get; set; }
        [Required]
        [Column("MaNV")]
        [StringLength(20)]
        public string MaNv { get; set; }

        [ForeignKey(nameof(MaNv))]
        [InverseProperty(nameof(Nhanvien.Hangs))]
        public virtual Nhanvien MaNvNavigation { get; set; }
    }
}
