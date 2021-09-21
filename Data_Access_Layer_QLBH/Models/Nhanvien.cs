using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Data_Access_Layer_QLBH.Models
{
    [Table("NHANVIEN")]
    public partial class Nhanvien
    {
        public Nhanvien()
        {
            Hangs = new HashSet<Hang>();
            Khachhangs = new HashSet<Khachhang>();
        }

        [Column("id")]
        public int? Id { get; set; }
        [Key]
        [Column("MaNV")]
        [StringLength(20)]
        public string MaNv { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [Column("TenNV")]
        [StringLength(50)]
        public string TenNv { get; set; }
        [Required]
        [StringLength(100)]
        public string DiaChi { get; set; }
        public int VaiTro { get; set; }
        public int TinhTrang { get; set; }
        [Required]
        [StringLength(50)]
        public string MatKhau { get; set; }

        [InverseProperty(nameof(Hang.MaNvNavigation))]
        public virtual ICollection<Hang> Hangs { get; set; }
        [InverseProperty(nameof(Khachhang.MaNvNavigation))]
        public virtual ICollection<Khachhang> Khachhangs { get; set; }
    }
}
