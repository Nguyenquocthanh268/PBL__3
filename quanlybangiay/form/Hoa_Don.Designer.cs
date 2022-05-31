
namespace quanlybangiay.form
{
    partial class Hoa_Don
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtgHD = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnDetail = new System.Windows.Forms.Button();
            this.cbbSort = new System.Windows.Forms.ComboBox();
            this.btnSort = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cbbSearch = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dateBegin = new System.Windows.Forms.DateTimePicker();
            this.ID_HoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoDienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayTao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_NhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHD)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.panel2.Controls.Add(this.dtgHD);
            this.panel2.Location = new System.Drawing.Point(12, 95);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(856, 571);
            this.panel2.TabIndex = 10;
            // 
            // dtgHD
            // 
            this.dtgHD.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(33)))), ((int)(((byte)(75)))));
            this.dtgHD.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgHD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgHD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgHD.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.dtgHD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgHD.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgHD.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgHD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgHD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_HoaDon,
            this.TenKhachHang,
            this.SoDienThoai,
            this.NgayTao,
            this.TongTien,
            this.ID_NhanVien});
            this.dtgHD.EnableHeadersVisualStyles = false;
            this.dtgHD.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(112)))), ((int)(((byte)(144)))));
            this.dtgHD.Location = new System.Drawing.Point(12, 12);
            this.dtgHD.Name = "dtgHD";
            this.dtgHD.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(116)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgHD.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgHD.RowHeadersVisible = false;
            this.dtgHD.RowHeadersWidth = 50;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(56)))), ((int)(((byte)(86)))));
            this.dtgHD.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgHD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgHD.Size = new System.Drawing.Size(832, 547);
            this.dtgHD.TabIndex = 10;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.panel4.Controls.Add(this.btnDetail);
            this.panel4.Controls.Add(this.cbbSort);
            this.panel4.Controls.Add(this.btnSort);
            this.panel4.Controls.Add(this.btnDelete);
            this.panel4.Location = new System.Drawing.Point(879, 95);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(178, 571);
            this.panel4.TabIndex = 9;
            // 
            // btnDetail
            // 
            this.btnDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(63)))));
            this.btnDetail.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDetail.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(83)))), ((int)(((byte)(255)))));
            this.btnDetail.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.btnDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(128)))), ((int)(((byte)(144)))));
            this.btnDetail.Location = new System.Drawing.Point(35, 12);
            this.btnDetail.Margin = new System.Windows.Forms.Padding(2);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(109, 41);
            this.btnDetail.TabIndex = 5;
            this.btnDetail.Text = "Xem chi tiết";
            this.btnDetail.UseVisualStyleBackColor = false;
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // cbbSort
            // 
            this.cbbSort.FormattingEnabled = true;
            this.cbbSort.Location = new System.Drawing.Point(35, 152);
            this.cbbSort.Margin = new System.Windows.Forms.Padding(2);
            this.cbbSort.Name = "cbbSort";
            this.cbbSort.Size = new System.Drawing.Size(109, 21);
            this.cbbSort.TabIndex = 2;
            // 
            // btnSort
            // 
            this.btnSort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(63)))));
            this.btnSort.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(83)))), ((int)(((byte)(255)))));
            this.btnSort.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.btnSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(128)))), ((int)(((byte)(144)))));
            this.btnSort.Location = new System.Drawing.Point(35, 106);
            this.btnSort.Margin = new System.Windows.Forms.Padding(2);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(109, 41);
            this.btnSort.TabIndex = 4;
            this.btnSort.Text = "Sắp xếp";
            this.btnSort.UseVisualStyleBackColor = false;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(63)))));
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(83)))), ((int)(((byte)(255)))));
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(128)))), ((int)(((byte)(144)))));
            this.btnDelete.Location = new System.Drawing.Point(35, 59);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(109, 41);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(63)))));
            this.btnSearch.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(83)))), ((int)(((byte)(255)))));
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(128)))), ((int)(((byte)(144)))));
            this.btnSearch.Location = new System.Drawing.Point(893, 25);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(126, 32);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Xem";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(118, 39);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(726, 27);
            this.txtSearch.TabIndex = 3;
            // 
            // cbbSearch
            // 
            this.cbbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbSearch.FormattingEnabled = true;
            this.cbbSearch.Location = new System.Drawing.Point(12, 38);
            this.cbbSearch.Margin = new System.Windows.Forms.Padding(2);
            this.cbbSearch.Name = "cbbSearch";
            this.cbbSearch.Size = new System.Drawing.Size(102, 28);
            this.cbbSearch.TabIndex = 2;
            this.cbbSearch.SelectedIndexChanged += new System.EventHandler(this.cbbSearch_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(35)))), ((int)(((byte)(70)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1069, 678);
            this.panel1.TabIndex = 7;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.panel5.Controls.Add(this.dateEnd);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.dateBegin);
            this.panel5.Controls.Add(this.btnSearch);
            this.panel5.Controls.Add(this.txtSearch);
            this.panel5.Controls.Add(this.cbbSearch);
            this.panel5.Location = new System.Drawing.Point(12, 12);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1045, 72);
            this.panel5.TabIndex = 5;
            // 
            // dateEnd
            // 
            this.dateEnd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateEnd.Location = new System.Drawing.Point(473, 10);
            this.dateEnd.Margin = new System.Windows.Forms.Padding(2);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(204, 20);
            this.dateEnd.TabIndex = 83;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(128)))), ((int)(((byte)(144)))));
            this.label3.Location = new System.Drawing.Point(416, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 85;
            this.label3.Text = "TO";
            // 
            // dateBegin
            // 
            this.dateBegin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateBegin.Location = new System.Drawing.Point(181, 10);
            this.dateBegin.Margin = new System.Windows.Forms.Padding(2);
            this.dateBegin.Name = "dateBegin";
            this.dateBegin.Size = new System.Drawing.Size(204, 20);
            this.dateBegin.TabIndex = 84;
            this.dateBegin.Value = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            // 
            // ID_HoaDon
            // 
            this.ID_HoaDon.DataPropertyName = "ID_HoaDon";
            this.ID_HoaDon.HeaderText = "ID Hoá đơn";
            this.ID_HoaDon.Name = "ID_HoaDon";
            this.ID_HoaDon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TenKhachHang
            // 
            this.TenKhachHang.DataPropertyName = "TenKhachHang";
            this.TenKhachHang.HeaderText = "Tên khách hàng";
            this.TenKhachHang.Name = "TenKhachHang";
            this.TenKhachHang.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SoDienThoai
            // 
            this.SoDienThoai.DataPropertyName = "SoDienThoai";
            this.SoDienThoai.HeaderText = "Số điện thoại";
            this.SoDienThoai.Name = "SoDienThoai";
            this.SoDienThoai.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // NgayTao
            // 
            this.NgayTao.DataPropertyName = "NgayTao";
            this.NgayTao.HeaderText = "Ngày tạo đơn";
            this.NgayTao.Name = "NgayTao";
            this.NgayTao.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TongTien
            // 
            this.TongTien.DataPropertyName = "TongTien";
            this.TongTien.HeaderText = "Tổng tiền";
            this.TongTien.Name = "TongTien";
            this.TongTien.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ID_NhanVien
            // 
            this.ID_NhanVien.DataPropertyName = "ID_NhanVien";
            this.ID_NhanVien.HeaderText = "ID Nhân viên";
            this.ID_NhanVien.Name = "ID_NhanVien";
            this.ID_NhanVien.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Hoa_Don
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.ClientSize = new System.Drawing.Size(1069, 678);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Hoa_Don";
            this.Text = "Hoa_Don";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgHD)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnDetail;
        private System.Windows.Forms.ComboBox cbbSort;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cbbSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateBegin;
        private System.Windows.Forms.DataGridView dtgHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_HoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoDienThoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayTao;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_NhanVien;
    }
}