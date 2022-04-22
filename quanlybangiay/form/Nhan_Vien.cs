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
    public partial class Nhan_Vien : Form
    {
        public Nhan_Vien()
        {
            InitializeComponent();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            DetailNV a = new DetailNV();
            a.Show();
        }

        private void btnAddnew_Click(object sender, EventArgs e)
        {
            DetailNV a = new DetailNV();
            a.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DetailNV a = new DetailNV();
            a.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Da xoa thanh cong!!!");
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
