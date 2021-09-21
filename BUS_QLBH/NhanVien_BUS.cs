using System;
using System.Collections.Generic;
using System.Linq;

using Data_Access_Layer_QLBH.Models;
using Data_Access_Layer_QLBH.Service;

using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Business_Logic_Layer_QLBH
{
    public static class NhanVien_BUS
    {
        private static List<Nhanvien> _list;
        private static ServiceNhanVien pt = new ServiceNhanVien();

        public static Nhanvien nv_bus(string email, string tenNv, string diaChi, int vaitro, int tinhTrang, string matKhau)
        {
            Nhanvien nv = new Nhanvien();
            nv.Email = email;
            nv.TenNv = tenNv;
            nv.DiaChi = diaChi;
            nv.VaiTro = vaitro;
            nv.TinhTrang = tinhTrang;
            nv.MatKhau = matKhau;
            return nv;
        }
        public static List<Nhanvien> LoadData()
        {
            return _list = pt.GetNhanviens();
        }

        public static string Add_bus(Nhanvien nv)
        {
            return pt.Add_NhanVien(nv);
        }
        public static string Edit_bus(string key, Nhanvien nv)
        {
            if (LoadData().Any(c => c.MaNv == key))
            {
                Nhanvien nvedit = new Nhanvien();
                nvedit.MaNv = key;
                nvedit.Email = nv.Email;
                nvedit.TenNv = nv.TenNv;
                nvedit.DiaChi = nv.DiaChi;
                nvedit.VaiTro = nv.VaiTro;
                nvedit.TinhTrang = nv.TinhTrang;
                nvedit.MaNv = nv.MatKhau;
                pt.Edit_NhanVien(nvedit);
                return "Sửa Thành Công!";
            }
            else
            {
                return "Lỗi!";
            }

        }
        public static string Remove_bus(string key)
        {
            if (LoadData().Any(c => c.MaNv == key))
            {
                Nhanvien nv = new Nhanvien();
                nv = LoadData().FirstOrDefault(c => c.MaNv == key);
                pt.Delete_NhanVien(nv);
                return " Xóa Thành Công";
            }
            else
            {
                return "Xóa Xịt!";
            }
        }

        public static string SAVE_DB()
        {
            try
            {
                pt.Save();
                return " Lưu thành Công!";
            }
            catch (Exception e)
            {
                return " Lưu Thất Bại!";
            }
        }
    }
}