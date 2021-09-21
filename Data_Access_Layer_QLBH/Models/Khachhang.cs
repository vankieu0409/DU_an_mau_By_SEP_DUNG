using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Data_Access_Layer_QLBH.Models
{
    [Table("KHACHHANG")]
    public partial class Khachhang
    {
        [Key]
        [StringLength(15)]
        public string DienThoai { get; set; }
        [Required]
        [StringLength(50)]
        public string TenKhach { get; set; }
        [Required]
        [StringLength(100)]
        public string DiaChi { get; set; }
        [Required]
        [StringLength(5)]
        public string GioiTinh { get; set; }
        [Required]
        [Column("MaNV")]
        [StringLength(20)]
        public string MaNv { get; set; }

        [ForeignKey(nameof(MaNv))]
        [InverseProperty(nameof(Nhanvien.Khachhangs))]
        public virtual Nhanvien MaNvNavigation { get; set; }
    }
}
