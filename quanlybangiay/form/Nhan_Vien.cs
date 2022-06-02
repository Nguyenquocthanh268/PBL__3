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

namespace quanlybangiay.form
{
    public partial class Nhan_Vien : Form
    {
        public Nhan_Vien()
        {
            InitializeComponent();
            cbbSearch.Items.AddRange((BLL_NV.Instance.CBBSearch().ToArray()));
            cbbSort.Items.AddRange((BLL_NV.Instance.CBBSort().ToArray()));
            cbbSearch.SelectedIndex = 0;
            dtgNV.RowTemplate.Height = 40;
            dtgNV.DataSource = BLL_NV.Instance.Search(0, "");
        }

        public void ShowDtg()
        {
            dtgNV.DataSource = BLL_NV.Instance.ShowAll();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (dtgNV.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên muốn xem chi tiết!");
            } 
            else if (dtgNV.SelectedRows.Count == 1)
            {
                string ID = dtgNV.SelectedRows[0].Cells["ID_NhanVien"].Value.ToString();
                DetailNV f = new DetailNV(ID, 1);
                f.d = new DetailNV.Mydel(ShowDtg);
                f.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 nhân viên mà bạn muốn xem chi tiết!");
            }

        }

        private void btnAddnew_Click(object sender, EventArgs e)
        {
            DetailNV f = new DetailNV("", 2);
            f.d = new DetailNV.Mydel(ShowDtg);
            f.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dtgNV.SelectedRows.Count == 1)
            {
                string ID = dtgNV.SelectedRows[0].Cells["ID_NhanVien"].Value.ToString();
                DetailNV f = new DetailNV(ID, 3);
                f.d = new DetailNV.Mydel(ShowDtg);
                f.Show();
            } else
            {
                MessageBox.Show("Vui lòng chọn nhân viên muốn chỉnh sửa!");
                ShowDtg();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int index = cbbSearch.SelectedIndex;
            string txt = txtSearch.Text;
            dtgNV.DataSource = BLL_NV.Instance.Search(index, txt);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dtgNV.SelectedRows.Count > 0)
            {
                String s = "Bạn có muốn xóa nhân viên ??";
                String s1 = "Delete";
                MessageBoxButtons ok = MessageBoxButtons.OKCancel;
                DialogResult d = MessageBox.Show(s, s1, ok);
                if (d == DialogResult.OK)
                {
                    foreach (DataGridViewRow i in dtgNV.SelectedRows)
                    {
                        string ID = i.Cells["ID_NhanVien"].Value.ToString();
                        BLL_NV.Instance.Delete(ID);
                    }
                }
            } else
            {
                MessageBox.Show("Vui lòng chọn nhân viên muốn xoá!");
            }
            ShowDtg();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            int index = cbbSort.SelectedIndex;
            if(index >= 0)
            {
                string txt = cbbSort.SelectedItem.ToString();
                dtgNV.DataSource = BLL_NV.Instance.Sort(txt,index);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn Item ...");
            }
        
        }

        private void cbbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            if (cbbSearch.SelectedIndex <= 0)
            {
                txtSearch.Enabled = false;

            }
            else if (cbbSearch.SelectedIndex > 0)
            {
                txtSearch.Enabled = true;
            }
        }
    }
}
