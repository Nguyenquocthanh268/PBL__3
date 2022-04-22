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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtuser.Text == "admin")
            {
                Form1 f = new Form1();
                f.Show();

            }
            if (txtuser.Text == "nv")
            {
                MainNV f = new MainNV();
                this.Hide();
                f.Show();
                this.Activate();

            }
        }
        //hello mai phen 
    }
}
