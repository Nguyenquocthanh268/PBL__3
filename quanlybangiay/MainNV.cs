using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlybangiay
{
    public partial class MainNV : Form
    {
        public MainNV()
        {
            InitializeComponent();
            ShowdtGV_Trangchu();
        }
        private void ShowdtGV_Trangchu()
        {
            DataTable d1 = new DataTable();
            d1.Columns.AddRange(new DataColumn[]
            {
                new DataColumn{ColumnName = "Mã giày",DataType =typeof(string)},
                new DataColumn{ColumnName = "Hãng",DataType =typeof(string)},
                new DataColumn{ColumnName = "Tên SP",DataType =typeof(string)},
                new DataColumn{ColumnName = "Size",DataType =typeof(int)},
                new DataColumn{ColumnName = "Giá(VNĐ)",DataType =typeof(int)},
                new DataColumn{ColumnName = "SL",DataType =typeof(int)},
                new DataColumn{ColumnName = "Thành tiền(VNĐ)",DataType =typeof(int)}
            });
            dtGV_Trangchu.DataSource = d1;
        }

        private void MainNV_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login f = new Login();
            this.Hide();
            f.Show();
            this.Activate();
        }
        //AAAAAA
        //hello
        //thanks
    }
}
