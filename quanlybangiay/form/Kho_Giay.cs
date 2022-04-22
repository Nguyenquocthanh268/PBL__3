using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlybangiay.form
{
    public partial class Kho_Giay : Form
    {
        private Button CurrentButton;
        public Kho_Giay()
        {
            InitializeComponent();
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            DetailKhoGiay a = new DetailKhoGiay("");
            a.Show();
        }

        private void btnAddnew_Click_1(object sender, EventArgs e)
        {
            DetailKhoGiay a = new DetailKhoGiay("");
            a.Show();
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            DetailKhoGiay a = new DetailKhoGiay("");
            a.Show();
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Da xoa thanh cong!!!");
        }

        private void btnInput_Click_1(object sender, EventArgs e)
        {
            NhapKho a = new NhapKho();
            a.Show();
        }

        private void btnSort_Click_1(object sender, EventArgs e)
        {

        }


    }
}
