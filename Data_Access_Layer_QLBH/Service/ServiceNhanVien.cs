using System.Collections.Generic;
using System.Linq;

using Data_Access_Layer_QLBH.Context;
using Data_Access_Layer_QLBH.Models;

using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer_QLBH.Service
{
    public class ServiceNhanVien
    {
        private List<Nhanvien> _lstNhanVien;
        private DatabaseContext DB;

        public ServiceNhanVien()
        {
            _lstNhanVien = new List<Nhanvien>();
            DB = new DatabaseContext();
            _lstNhanVien = DB.Nhanviens.AsNoTracking().ToList();
        }


        public List<Nhanvien> GetNhanviens()
        {
            return _lstNhanVien;
        }



        public string Add_NhanVien(Nhanvien nv)
        {
            nv.Id = _lstNhanVien.Max(c => c.Id) + 1;
            nv.MaNv = "NV" + nv.Id;
            if (_lstNhanVien.Any(nc => nc.Id == nv.Id) == false)
            {
                _lstNhanVien.Add(nv);
                DB.Nhanviens.Add(nv);
                return " Thêm Thêm thành công!";
            }

            return "hihi";
        }


        public void Edit_NhanVien(Nhanvien nv)
        {
            int index = _lstNhanVien.FindIndex(c => c.MaNv ==nv.MaNv);
            _lstNhanVien[index] = nv;
            DB.Nhanviens.Update(nv);
        }

        public void Delete_NhanVien(Nhanvien nv)
        {
            _lstNhanVien.RemoveAt(_lstNhanVien.FindIndex(c => c.MaNv == nv.MaNv));
            DB.Nhanviens.Remove(nv);
        }

        public void Save()
        {
            DB.SaveChanges();
        }
    }
}