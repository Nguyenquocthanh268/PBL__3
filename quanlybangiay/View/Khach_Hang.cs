using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using quanlybangiay.BLL.BLL_AD;
using quanlybangiay.DTO;
namespace quanlybangiay.form
{
    public partial class Khach_Hang : Form
    {
        public Khach_Hang()
        {
            InitializeComponent();
            dataGridView1.RowTemplate.Height = 40;
            cbView.Items.AddRange((BLL_QLKH.Instance.CBBView().ToArray()));
            cbSort.Items.AddRange((BLL_QLKH.Instance.CBBSort().ToArray()));
            cbView.SelectedIndex = 0;
            Show();

        }
        public void GUI(string sdt)
        {

            KhachHang a = BLL_QLKH.Instance.Get1KH(sdt);
            tbSdt.Text = a.SoDienThoai;
            tbName.Text= a.TenKhachHang;
            tbDiemTL.Text = a.DiemTichLuy.ToString();
            datetimeNgayDK.Value = a.NgayDangKy.Value;
            tbSdt.BackColor= Color.FromArgb(171, 171, 171);
            tbDiemTL.BackColor = Color.FromArgb(171, 171, 171);
            datetimeNgayDK.BackColor = Color.FromArgb(171, 171, 171);
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                GUI(dataGridView1.SelectedRows[0].Cells["SoDienThoai"].Value.ToString());
            }
        }

        private void Show()
        {
            dataGridView1.DataSource = BLL.BLL_AD.BLL_QLKH.Instance.GetKH(cbView.SelectedIndex, tbSearch.Text);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(cbView.SelectedIndex >= 0)
            {
                Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 thuộc tính cần tìm kiếm...");
            }
            //Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if ( tbSdt.Text !="") {
                if (dataGridView1.SelectedRows.Count == 1)
                {
                  if(tbName.Text != "")
                    {
                        KhachHang s = new KhachHang
                        {
                            SoDienThoai = tbSdt.Text.ToString(),
                            TenKhachHang = tbName.Text.ToString(),
                            DiemTichLuy = Convert.ToInt32(tbDiemTL.Text.ToString()),
                        };
                        BLL_QLKH.Instance.UpdateKH(s);
                        Show();
                        MessageBox.Show("Cập nhật thành công !");
                        
                    }
                    else
                    {
                        MessageBox.Show("*Vui lòng điền đầy đủ thông tin ");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn khách hàng cần cập nhật !");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần cập nhật !");
            }
        }

        private void butDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                String s = "Bạn có muốn xóa Khách Hàng ??";
                String s1 = "Delete";
                MessageBoxButtons ok = MessageBoxButtons.OKCancel;
                DialogResult d = MessageBox.Show(s, s1, ok);
                if (d == DialogResult.OK)
                {
                    foreach (DataGridViewRow i in dataGridView1.SelectedRows)
                    {
                        String Sdt = i.Cells["SoDienThoai"].Value.ToString();
                        BLL_QLKH.Instance.DelKH(Sdt);
                    }
                    Show();
                    MessageBox.Show("Xóa thành công");
                    
                }
               
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa !");
            }
        }

        private void butSort_Click(object sender, EventArgs e)
        {
            if(cbSort.SelectedIndex >= 0)
            {
                dataGridView1.DataSource = BLL_QLKH.Instance.sortKH(cbView.SelectedIndex, tbSearch.Text, cbSort.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn thuộc tính sắp xếp !");
            }
        }

        private void cbView_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbSearch.Text = "";
            if (cbView.SelectedIndex <= 0)
            {
                tbSearch.Enabled = false;
                
            }
            else if(cbView.SelectedIndex > 0)
            {
                tbSearch.Enabled = true;
            }
        }
    }
}
