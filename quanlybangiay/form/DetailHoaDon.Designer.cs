
namespace quanlybangiay.form
{
    partial class DetailHoaDon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtgDetailHD = new System.Windows.Forms.DataGridView();
            this.TenGiay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HangGiay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_IDKM = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_tongck = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_TV = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_KM = new System.Windows.Forms.TextBox();
            this.txtTong = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNgaytao = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTen_NV = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTen_KH = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtID_HD = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetailHD)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 561);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(984, 561);
            this.panel3.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.dtgDetailHD);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 241);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(984, 320);
            this.panel4.TabIndex = 4;
            // 
            // dtgDetailHD
            // 
            this.dtgDetailHD.AllowUserToResizeColumns = false;
            this.dtgDetailHD.AllowUserToResizeRows = false;
            this.dtgDetailHD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetailHD.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtgDetailHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetailHD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TenGiay,
            this.HangGiay,
            this.Size,
            this.SoLuong,
            this.GiaNhap,
            this.GiaBan});
            this.dtgDetailHD.Location = new System.Drawing.Point(22, 30);
            this.dtgDetailHD.Name = "dtgDetailHD";
            this.dtgDetailHD.Size = new System.Drawing.Size(941, 266);
            this.dtgDetailHD.TabIndex = 0;
            // 
            // TenGiay
            // 
            this.TenGiay.DataPropertyName = "TenGiay";
            this.TenGiay.HeaderText = "Tên giày";
            this.TenGiay.Name = "TenGiay";
            // 
            // HangGiay
            // 
            this.HangGiay.DataPropertyName = "HangGiay";
            this.HangGiay.HeaderText = "Hãng giày";
            this.HangGiay.Name = "HangGiay";
            // 
            // Size
            // 
            this.Size.DataPropertyName = "Size";
            this.Size.HeaderText = "Size";
            this.Size.Name = "Size";
            // 
            // SoLuong
            // 
            this.SoLuong.DataPropertyName = "SoLuong";
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.Name = "SoLuong";
            // 
            // GiaNhap
            // 
            this.GiaNhap.DataPropertyName = "GiaNhap";
            this.GiaNhap.HeaderText = "Giá nhập";
            this.GiaNhap.Name = "GiaNhap";
            // 
            // GiaBan
            // 
            this.GiaBan.DataPropertyName = "GiaBan";
            this.GiaBan.HeaderText = "Giá bán";
            this.GiaBan.Name = "GiaBan";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txt_IDKM);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txt_tongck);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txt_TV);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txt_KM);
            this.panel2.Controls.Add(this.txtTong);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.txtNgaytao);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtTen_NV);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtTen_KH);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtID_HD);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(984, 241);
            this.panel2.TabIndex = 3;
            // 
            // txt_IDKM
            // 
            this.txt_IDKM.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txt_IDKM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_IDKM.Enabled = false;
            this.txt_IDKM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_IDKM.Location = new System.Drawing.Point(397, 140);
            this.txt_IDKM.Name = "txt_IDKM";
            this.txt_IDKM.Size = new System.Drawing.Size(168, 26);
            this.txt_IDKM.TabIndex = 93;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Info;
            this.label8.Location = new System.Drawing.Point(725, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(140, 20);
            this.label8.TabIndex = 92;
            this.label8.Text = "Chiết khấu KM";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Info;
            this.label5.Location = new System.Drawing.Point(393, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 20);
            this.label5.TabIndex = 91;
            this.label5.Text = "Tổng chiết khấu";
            // 
            // txt_tongck
            // 
            this.txt_tongck.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txt_tongck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_tongck.Enabled = false;
            this.txt_tongck.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tongck.Location = new System.Drawing.Point(397, 207);
            this.txt_tongck.Name = "txt_tongck";
            this.txt_tongck.Size = new System.Drawing.Size(168, 26);
            this.txt_tongck.TabIndex = 90;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Info;
            this.label2.Location = new System.Drawing.Point(61, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 20);
            this.label2.TabIndex = 89;
            this.label2.Text = "Chiết khấu thành viên";
            // 
            // txt_TV
            // 
            this.txt_TV.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txt_TV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_TV.Enabled = false;
            this.txt_TV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TV.Location = new System.Drawing.Point(65, 207);
            this.txt_TV.Name = "txt_TV";
            this.txt_TV.Size = new System.Drawing.Size(178, 26);
            this.txt_TV.TabIndex = 88;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(393, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 87;
            this.label1.Text = "ID_KM";
            // 
            // txt_KM
            // 
            this.txt_KM.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txt_KM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_KM.Enabled = false;
            this.txt_KM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_KM.Location = new System.Drawing.Point(729, 140);
            this.txt_KM.Name = "txt_KM";
            this.txt_KM.Size = new System.Drawing.Size(168, 26);
            this.txt_KM.TabIndex = 86;
            // 
            // txtTong
            // 
            this.txtTong.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtTong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTong.Enabled = false;
            this.txtTong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTong.Location = new System.Drawing.Point(727, 207);
            this.txtTong.Name = "txtTong";
            this.txtTong.Size = new System.Drawing.Size(168, 26);
            this.txtTong.TabIndex = 85;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.Info;
            this.label11.Location = new System.Drawing.Point(725, 184);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 20);
            this.label11.TabIndex = 84;
            this.label11.Text = "Tổng tiền";
            // 
            // txtNgaytao
            // 
            this.txtNgaytao.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtNgaytao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNgaytao.Enabled = false;
            this.txtNgaytao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgaytao.Location = new System.Drawing.Point(397, 62);
            this.txtNgaytao.Name = "txtNgaytao";
            this.txtNgaytao.Size = new System.Drawing.Size(168, 26);
            this.txtNgaytao.TabIndex = 83;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Info;
            this.label6.Location = new System.Drawing.Point(393, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 20);
            this.label6.TabIndex = 82;
            this.label6.Text = "Ngày tạo";
            // 
            // txtTen_NV
            // 
            this.txtTen_NV.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtTen_NV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTen_NV.Enabled = false;
            this.txtTen_NV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen_NV.Location = new System.Drawing.Point(729, 62);
            this.txtTen_NV.Name = "txtTen_NV";
            this.txtTen_NV.Size = new System.Drawing.Size(168, 26);
            this.txtTen_NV.TabIndex = 81;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Info;
            this.label7.Location = new System.Drawing.Point(725, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 20);
            this.label7.TabIndex = 80;
            this.label7.Text = "Tên nhân viên";
            // 
            // txtTen_KH
            // 
            this.txtTen_KH.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtTen_KH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTen_KH.Enabled = false;
            this.txtTen_KH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen_KH.Location = new System.Drawing.Point(65, 140);
            this.txtTen_KH.Name = "txtTen_KH";
            this.txtTen_KH.Size = new System.Drawing.Size(178, 26);
            this.txtTen_KH.TabIndex = 77;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Info;
            this.label3.Location = new System.Drawing.Point(61, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 20);
            this.label3.TabIndex = 76;
            this.label3.Text = "Tên khách hàng";
            // 
            // txtID_HD
            // 
            this.txtID_HD.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtID_HD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID_HD.Enabled = false;
            this.txtID_HD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID_HD.Location = new System.Drawing.Point(65, 62);
            this.txtID_HD.Name = "txtID_HD";
            this.txtID_HD.Size = new System.Drawing.Size(178, 26);
            this.txtID_HD.TabIndex = 75;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label4.Location = new System.Drawing.Point(61, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 20);
            this.label4.TabIndex = 74;
            this.label4.Text = "*ID hóa đơn";
            // 
            // DetailHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(63)))));
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.panel1);
            this.Name = "DetailHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DetailHoaDon";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetailHD)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtTong;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNgaytao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTen_NV;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTen_KH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtID_HD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_TV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_KM;
        private System.Windows.Forms.DataGridView dtgDetailHD;
        private System.Windows.Forms.TextBox txt_IDKM;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_tongck;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenGiay;
        private System.Windows.Forms.DataGridViewTextBoxColumn HangGiay;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBan;
    }
}