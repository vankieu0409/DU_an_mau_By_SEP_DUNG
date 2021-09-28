using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Business_Logic_Layer_QLBH;
using Data_Access_Layer_QLBH.Models;

namespace GUI_QLBH
{
    public partial class frmQuantri : Form
    {
        private string mess = " Thông báo của UBND Tinh VĨnh Phúc!";
        private string IDwhenClick;
        private NhanVien_BUS nv = new NhanVien_BUS();
        public frmQuantri()
        {
            InitializeComponent();
            LoadDataBase();
        }
        void LoadDataBase()
        {
            DGV_lisst.ColumnCount = 6;
            DGV_lisst.Columns[0].Name = "Email";
            DGV_lisst.Columns[1].Name = "Tên Nhân Viên";
            DGV_lisst.Columns[2].Name = "Địa Chỉ";
            DGV_lisst.Columns[3].Name = "Vai Trò";
            DGV_lisst.Columns[4].Name = "Trạng Thái";
            DGV_lisst.Columns[5].Name = "Mật Khẩu";
            DGV_lisst.Rows.Clear();
            foreach (var x in nv.LoadData())
            {
                DGV_lisst.Rows.Add(x.Email, x.TenNv, x.DiaChi, x.VaiTro == 1 ? "Nhân Viên" : x.VaiTro == 2 ? "Quản trị" : "", x.TinhTrang == 0 ? "Ngừng Hoạt Động" : x.TinhTrang == 1 ? "Hoạt Động" : "", x.MatKhau);
            }

        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            MessageBox.Show(nv.Add_bus(nv.nv_bus(txt_Email.Text, txt_name.Text, txt_Address.Text, rbtn_NhanVien.Checked ? 1 : 2,
                Cbx_HoatDong.Checked ? 1 : 0, txt_PassWord.Text)), mess);
            LoadDataBase();
        }

        private void DGV_lisst_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            if (rowindex == nv.LoadData().Count /*|| rowindex == 0*/) return;
            txt_Email.Text = DGV_lisst.Rows[rowindex].Cells[0].Value.ToString();
            txt_name.Text = DGV_lisst.Rows[rowindex].Cells[1].Value.ToString();
            txt_Address.Text = DGV_lisst.Rows[rowindex].Cells[2].Value.ToString();
            rbtn_NhanVien.Checked = DGV_lisst.Rows[rowindex].Cells[3].Value.ToString() == "Nhân Viên" ? true : false;
            rbtn_QuanTri.Checked = DGV_lisst.Rows[rowindex].Cells[3].Value.ToString() == "Quản trị" ? true : false;
            Cbx_HoatDong.Checked = DGV_lisst.Rows[rowindex].Cells[4].Value.ToString() == "Hoạt Động" ? true : false;
            cbx_KhongHD.Checked = DGV_lisst.Rows[rowindex].Cells[4].Value.ToString() == "Ngừng Hoạt Động" ? true : false;
            txt_PassWord.Text = DGV_lisst.Rows[rowindex].Cells[5].Value.ToString();
            IDwhenClick = nv.LoadData().Where(c => c.Email == txt_Email.Text).Select(c => c.MaNv).FirstOrDefault();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {

            MessageBox.Show(nv.Edit_bus(IDwhenClick, nv.nv_bus(txt_Email.Text, txt_name.Text, txt_Address.Text, rbtn_NhanVien.Checked ? 1 : 2,
                Cbx_HoatDong.Checked ? 1 : 0, txt_PassWord.Text)), mess);
            LoadDataBase();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            MessageBox.Show(nv.Remove_bus(IDwhenClick), mess);
            LoadDataBase();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            MessageBox.Show(nv.SAVE_DB(), mess);
        }

        private void btn_List_Click(object sender, EventArgs e)
        {
            LoadDataBase();
        }

        private void btn_Search_KeyUp(object sender, KeyEventArgs e)
        {
            DGV_lisst.ColumnCount = 6;
            DGV_lisst.Columns[0].Name = "Email";
            DGV_lisst.Columns[1].Name = "Tên Nhân Viên";
            DGV_lisst.Columns[2].Name = "Địa Chỉ";
            DGV_lisst.Columns[3].Name = "Vai Trò";
            DGV_lisst.Columns[4].Name = "Trạng Thái";
            DGV_lisst.Columns[5].Name = "Mật Khẩu";
            DGV_lisst.Rows.Clear();
            foreach (var x in nv.LoadData().Where(c => c.Email == txt_Search.Text))
            {
                DGV_lisst.Rows.Add(x.Email, x.TenNv, x.DiaChi, x.VaiTro == 1 ? "Nhân Viên" : x.VaiTro == 2 ? "Quản trị" : "", x.TinhTrang == 0 ? "Ngừng Hoạt Động" : x.TinhTrang == 1 ? "Hoạt Động" : "", x.MatKhau);
            }
        }
    }
}
