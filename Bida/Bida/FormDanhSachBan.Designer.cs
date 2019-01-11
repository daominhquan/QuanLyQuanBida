namespace Bida
{
    partial class FormDanhSachBan
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.datagrid_hoadonban = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelSanPham = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.lbTongtien = new System.Windows.Forms.Label();
            this.btnLuuHoaDon = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.btnSuaSanPham = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_hoadonban)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(304, 728);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "thêm 1 bàn";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Left;
            this.button2.Location = new System.Drawing.Point(80, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 50);
            this.button2.TabIndex = 1;
            this.button2.Text = "xóa 1 bàn";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(304, 50);
            this.panel2.TabIndex = 2;
            // 
            // datagrid_hoadonban
            // 
            this.datagrid_hoadonban.AllowUserToAddRows = false;
            this.datagrid_hoadonban.AllowUserToDeleteRows = false;
            this.datagrid_hoadonban.AllowUserToResizeColumns = false;
            this.datagrid_hoadonban.AllowUserToResizeRows = false;
            this.datagrid_hoadonban.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.datagrid_hoadonban.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid_hoadonban.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagrid_hoadonban.Enabled = false;
            this.datagrid_hoadonban.Location = new System.Drawing.Point(0, 0);
            this.datagrid_hoadonban.Name = "datagrid_hoadonban";
            this.datagrid_hoadonban.ReadOnly = true;
            this.datagrid_hoadonban.RowHeadersVisible = false;
            this.datagrid_hoadonban.Size = new System.Drawing.Size(403, 685);
            this.datagrid_hoadonban.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(304, 778);
            this.panel3.TabIndex = 4;
            // 
            // panelSanPham
            // 
            this.panelSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSanPham.Location = new System.Drawing.Point(0, 0);
            this.panelSanPham.Name = "panelSanPham";
            this.panelSanPham.Size = new System.Drawing.Size(577, 728);
            this.panelSanPham.TabIndex = 7;
            this.panelSanPham.SizeChanged += new System.EventHandler(this.panelSanPham_SizeChanged);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(304, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(980, 778);
            this.panel4.TabIndex = 6;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(980, 778);
            this.panel5.TabIndex = 8;
            // 
            // panel6
            // 
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel6.Controls.Add(this.panel10);
            this.panel6.Controls.Add(this.panel8);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 50);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(980, 728);
            this.panel6.TabIndex = 9;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.panelSanPham);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(577, 728);
            this.panel10.TabIndex = 8;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panel11);
            this.panel8.Controls.Add(this.panel9);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(577, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(403, 728);
            this.panel8.TabIndex = 6;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.datagrid_hoadonban);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(0, 43);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(403, 685);
            this.panel11.TabIndex = 5;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.panel12);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(403, 43);
            this.panel9.TabIndex = 4;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.btnThanhToan);
            this.panel12.Controls.Add(this.lbTongtien);
            this.panel12.Controls.Add(this.btnLuuHoaDon);
            this.panel12.Controls.Add(this.label1);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(403, 47);
            this.panel12.TabIndex = 12;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnThanhToan.Location = new System.Drawing.Point(219, 0);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(92, 47);
            this.btnThanhToan.TabIndex = 9;
            this.btnThanhToan.Text = "thanh toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // lbTongtien
            // 
            this.lbTongtien.AutoSize = true;
            this.lbTongtien.Location = new System.Drawing.Point(71, 17);
            this.lbTongtien.Name = "lbTongtien";
            this.lbTongtien.Size = new System.Drawing.Size(23, 13);
            this.lbTongtien.TabIndex = 11;
            this.lbTongtien.Text = "0 đ";
            // 
            // btnLuuHoaDon
            // 
            this.btnLuuHoaDon.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLuuHoaDon.Location = new System.Drawing.Point(311, 0);
            this.btnLuuHoaDon.Name = "btnLuuHoaDon";
            this.btnLuuHoaDon.Size = new System.Drawing.Size(92, 47);
            this.btnLuuHoaDon.TabIndex = 8;
            this.btnLuuHoaDon.Text = "Lưu ";
            this.btnLuuHoaDon.UseVisualStyleBackColor = true;
            this.btnLuuHoaDon.Click += new System.EventHandler(this.btnLuuHoaDon_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tổng cộng";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.button4);
            this.panel7.Controls.Add(this.btnSuaSanPham);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(980, 50);
            this.panel7.TabIndex = 6;
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Left;
            this.button4.Location = new System.Drawing.Point(80, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(80, 50);
            this.button4.TabIndex = 7;
            this.button4.Text = "Thêm";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnThemSanPham_Click);
            // 
            // btnSuaSanPham
            // 
            this.btnSuaSanPham.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSuaSanPham.Enabled = false;
            this.btnSuaSanPham.Location = new System.Drawing.Point(0, 0);
            this.btnSuaSanPham.Name = "btnSuaSanPham";
            this.btnSuaSanPham.Size = new System.Drawing.Size(80, 50);
            this.btnSuaSanPham.TabIndex = 6;
            this.btnSuaSanPham.Text = "Sửa";
            this.btnSuaSanPham.UseVisualStyleBackColor = true;
            this.btnSuaSanPham.Click += new System.EventHandler(this.button3_Click);
            // 
            // FormDanhSachBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 778);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Name = "FormDanhSachBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormDanhSachBan";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_hoadonban)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView datagrid_hoadonban;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelSanPham;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnSuaSanPham;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnLuuHoaDon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTongtien;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel12;
    }
}