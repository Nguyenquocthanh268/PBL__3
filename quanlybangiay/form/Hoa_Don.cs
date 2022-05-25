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
    public partial class Hoa_Don : Form
    {
        public Hoa_Don()
        {
            InitializeComponent();
            cbbSearch.Items.AddRange((BLL_HD.Instance.CBBSearch().ToArray()));
            cbbSort.Items.AddRange((BLL_HD.Instance.CBBSort().ToArray()));
        }

        public void ShowDtg()
        {
            dtgHD.DataSource = BLL_HD.Instance.ShowAll();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (dtgHD.SelectedRows.Count == 1)
            {
                string ID = dtgHD.SelectedRows[0].Cells["ID_HoaDon"].Value.ToString();
                DetailHoaDon f = new DetailHoaDon(ID);
                f.d = new DetailHoaDon.Mydel(ShowDtg);
                f.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn chỉnh sửa!");
                ShowDtg();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int index = cbbSearch.SelectedIndex;
            string txt = txtSearch.Text;
            DateTime begin = dateBegin.Value;
            DateTime end = dateEnd.Value;
            dtgHD.DataSource = BLL_HD.Instance.Search(index, txt, begin, end);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dtgHD.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow i in dtgHD.SelectedRows)
                {
                    string ID = i.Cells["ID_HoaDon"].Value.ToString();
                    BLL_HD.Instance.Delete(ID);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hoá đơn muốn xoá!");
            }
            ShowDtg();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            int index = cbbSort.SelectedIndex;
            if(index >= 0)
            {
                dtgHD.DataSource = BLL_HD.Instance.Sort(index);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn Item ...");
            }
            
        }
    }
}
