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
    public partial class DetailKhoGiay : Form
    {
        //public delegate void Mydel
        public String IDGiay { get; set; }
        public DetailKhoGiay(String s)
        {
            InitializeComponent();
            IDGiay = s;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
