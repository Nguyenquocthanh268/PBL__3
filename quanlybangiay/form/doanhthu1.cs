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
    public partial class doanhthu1 : Form
    {
        private Form dad_form;
        public doanhthu1()
        {
            InitializeComponent();
        }

        private void openform(Form childform, object sender)
        {
            if (dad_form != null)
            {
                dad_form.Close();
            }
            
            dad_form = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            this.pn_doanhthu.Controls.Add(childform);
            this.pn_doanhthu.Tag = childform;
            childform.BringToFront();
            childform.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            doanhthu_ngay d = new doanhthu_ngay();
            openform(d, sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            doanhthu_thang d = new doanhthu_thang();
            openform(d, sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            doanhthu_nam d = new doanhthu_nam();
            openform(d, sender);
        }
    }
}
