using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bida
{
    public partial class FormDanhSachBan : Form
    {
        private CodeFirstDBEntities db = new CodeFirstDBEntities();
        public static int idsanpham;
        public static Button selectedSanPham;
        private static Button selectedBan;
        Timer timer = new Timer();

        public FormDanhSachBan()
        {
            InitializeComponent();
            timer.Interval = 60000;
            timer.Tick += timer_Tick;
            timer.Enabled = true;
            LoadDanhSachBan();
            LoadDanhSachSanPham();
            datagrid_hoadonban.ColumnCount = 6;
            datagrid_hoadonban.Columns[0].Name = "ID";
            datagrid_hoadonban.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            datagrid_hoadonban.Columns[0].Visible = false;
            datagrid_hoadonban.Columns[1].Name = "Tên Sản phẩm";
            datagrid_hoadonban.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            datagrid_hoadonban.Columns[2].Name = "Số lượng";
            datagrid_hoadonban.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            datagrid_hoadonban.Columns[3].Name = "Đơn giá";
            datagrid_hoadonban.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            datagrid_hoadonban.Columns[4].Name = "Tổng";
            datagrid_hoadonban.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            datagrid_hoadonban.Columns[4].Visible = false;
            datagrid_hoadonban.Columns[5].Name = "Tổng cộng";
            datagrid_hoadonban.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            foreach (DataGridViewColumn column in datagrid_hoadonban.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            fpanelSanPham.Visible = false;
        }
        public void LoadDanhSachBan()
        {
            panelDanhSachBan.Controls.Clear();
            int top = 40;
            int left = 10;
            int index = 0;
            foreach (var item in db.BanBidas)
            {
                Button newButton = new Button();
                newButton.Text = item.TenBanBida;
                newButton.Size = new Size(75, 27);
                newButton.Location = new Point(left, top);
                newButton.Name = "btn_Ban_" + item.BanBidaId;
                newButton.Size = new Size(120, 140);

                if (item.TinhTrang == "đang hoạt động")
                {
                    foreach (HoaDonBan hoadon in db.HoaDonBans)
                    {
                        if (hoadon.idBanbida == item.BanBidaId && hoadon.TinhTrang == "đang hoạt động")
                        {
                            double sophut = Math.Round((DateTime.Now - hoadon.NgayBan).Value.TotalMinutes);
                            int sogio = 0;
                            string thoigian = "";
                            if (sophut >= 60)
                            {
                                sogio = (int)(sophut / 60);
                                sophut = sophut - sogio * 60;
                            }
                            if (sogio < 10 && sophut < 10)
                            {
                                thoigian = "0" + sogio.ToString() + ":0" + sophut.ToString();
                            }
                            else if (sophut < 10)
                            {
                                thoigian = sogio.ToString() + ":0" + sophut.ToString();
                            }
                            else if (sogio < 10)
                            {
                                thoigian = "0" + sogio.ToString() + ":" + sophut.ToString();
                            }
                            else
                            {
                                thoigian = sogio.ToString() + ":" + sophut.ToString();
                            }
                            newButton.Text = item.TenBanBida + " " + Environment.NewLine + thoigian;
                            break;
                        }
                    }
                    string startupPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Picture\\dacokhach.png";
                    Image myimage = new Bitmap(startupPath);//tạo biến lưu lại hình ảnh bởi đường dẫn
                    newButton.BackgroundImage = myimage;//đổi ảnh nền của button 
                    newButton.BackgroundImageLayout = ImageLayout.Zoom;
                    newButton.ForeColor = newButton.BackColor = Color.Transparent;
                    newButton.FlatStyle = FlatStyle.Flat;
                    newButton.FlatAppearance.BorderSize = 0;

                }
                else
                {
                    string startupPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Picture\\chuacokhach.png";
                    Image myimage = new Bitmap(startupPath);//tạo biến lưu lại hình ảnh bởi đường dẫn
                    newButton.BackgroundImage = myimage;//đổi ảnh nền của button 
                    newButton.BackgroundImageLayout = ImageLayout.Zoom;
                    newButton.ForeColor = newButton.BackColor = Color.Transparent;
                    newButton.FlatStyle = FlatStyle.Flat;
                    newButton.FlatAppearance.BorderSize = 0;
                }
                newButton.Click += btnBan_Click;
                index++;
                left = left + 140;
                if (index % 2 == 0)
                {
                    top = top + 170;
                    left = 10;
                }
                panelDanhSachBan.Controls.Add(newButton);
            }
            if (selectedBan != null)
                selectedBan.BackColor = Color.Blue;
            panelDanhSachBan.AutoScroll = false;
            panelDanhSachBan.HorizontalScroll.Enabled = false;
            panelDanhSachBan.HorizontalScroll.Visible = false;
            panelDanhSachBan.HorizontalScroll.Maximum = 0;
            panelDanhSachBan.AutoScroll = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            LoadDanhSachBan();
        }

        public void loadDuLieuBanLenHoaDon(int id)
        {
            datagrid_hoadonban.Rows.Clear();
            int index = 0;
            if (db.BanBidas.Find(id).TinhTrang == "đang hoạt động")
            {
                btnThanhToan.Enabled = true;
                btnLuuHoaDon.Text = "Lưu";
            }
            else
            {
                btnThanhToan.Enabled = false;
                btnLuuHoaDon.Text = "Mở Bàn";
            }

            HoaDonBan hoadon = new HoaDonBan();
            foreach (var item in db.HoaDonBans)
            {
                if (item.idBanbida == id && item.TinhTrang == "đang hoạt động")
                {
                    hoadon = item;
                    break;
                }
            }
            if (db.BanBidas.Find(id).TinhTrang == "đang hoạt động")
            {
                double sophut = Math.Round((DateTime.Now - hoadon.NgayBan).Value.TotalMinutes);
                datagrid_hoadonban.Rows.Add("", "Tiền giờ", sophut, (25000 / 60), Math.Round(sophut * (25000 / 60) / 1000) * 1000, string.Format("{0:#,##0}", Math.Round(sophut * (25000 / 60) / 1000) * 1000));
                UpdateTongCongHoaDon();
            }
            try
            {
                foreach (var item in db.ChiTietHoaDonBans)
                {
                    if (item.HoaDonBan.idBanbida == id && item.HoaDonBan.TinhTrang == "đang hoạt động")
                    {
                        datagrid_hoadonban.Rows.Add(item.IdSanPham, item.SanPham.TenSanPham, item.Soluong, item.SanPham.GiaTien, item.Soluong.Value * int.Parse(item.SanPham.GiaTien), string.Format("{0:#,##0}", item.Soluong.Value * int.Parse(item.SanPham.GiaTien)));
                        index++;
                    }
                }
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("vui lòng cập nhật giá tiền");
            }

            btnLuuHoaDon.Enabled = true;
            UpdateTongCongHoaDon();


        }

        public void LoadDanhSachSanPham()
        {
            db = new CodeFirstDBEntities();
            fpanelSanPham.Controls.Clear();
            int top = 40;
            int left = 0;
            foreach (var item in db.SanPhams)
            {
                if (item.isDelete == null)
                {
                    Button newButton = new Button();
                    newButton.Size = new Size(75, 27);
                    newButton.Location = new Point(left, top);
                    newButton.Text = item.TenSanPham;
                    newButton.Name = "btn_Ban_" + item.SanPhamId;
                    newButton.Size = new Size(150, 150);
                    if (item.HinhAnh != null && item.HinhAnh != "")
                    {
                        //string startupPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Picture\\hinhbanbida.jpg";
                        Image myimage = new Bitmap(item.HinhAnh);//tạo biến lưu lại hình ảnh bởi đường dẫn
                        newButton.BackgroundImage = myimage;//đổi ảnh nền của button 
                        newButton.BackgroundImageLayout = ImageLayout.Zoom;
                        Bitmap bm = (Bitmap)newButton.BackgroundImage;
                        bm.MakeTransparent(bm.GetPixel(0, 0));
                    }
                    //newButton.BackColor = Color.White;
                    newButton.ForeColor = Color.Black;
                    newButton.BackColor = SystemColors.ControlLight;
                    newButton.FlatStyle = FlatStyle.Flat;
                    newButton.FlatAppearance.BorderSize = 0;
                    newButton.Click += btnSanPham_Click;
                    fpanelSanPham.Controls.Add(newButton);
                }
            }

        }


        public void UpdateTongCongHoaDon()
        {
            double tong = 0;
            int testgiatien;
            foreach (DataGridViewRow row in datagrid_hoadonban.Rows)
            {
                if (datagrid_hoadonban.Rows.Count > 0 && row.Cells["Tổng"].Value.ToString() != "" && row.Cells["Tổng"].Value != null)
                {
                    if (int.TryParse(row.Cells["Tổng"].Value.ToString(), out testgiatien))
                    {
                        tong = tong + int.Parse(row.Cells["Tổng"].Value.ToString());
                    }
                }
            }
            lbTongtien.Text = tong.ToString();
            labelTongCong.Text = string.Format("{0:#,##0}", int.Parse(lbTongtien.Text));
        }
        private void btnThemSanPham_Click(object sender, EventArgs e)
        {
            ThemSanPham frm = new ThemSanPham();
            frm.ShowDialog();
            LoadDanhSachSanPham();
        }
        private void btnBan_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            selectedBan = btn;
            foreach (Button item in panelDanhSachBan.Controls)
            {
                if (item.BackColor == SystemColors.Highlight)
                {
                    item.BackColor = btn.BackColor;
                }
            }
            btn.BackColor = SystemColors.Highlight;
            loadDuLieuBanLenHoaDon(int.Parse(btn.Name.Split('_')[2]));
            fpanelSanPham.Visible = true;
            lbTenBan.Text = btn.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.None)[0];
        }
        private void btnSanPham_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btnSuaSanPham.Enabled = true;
            selectedSanPham = btn;
            idsanpham = int.Parse(btn.Name.Split('_')[2]);
            foreach (Button item in fpanelSanPham.Controls)
            {
                if (item.BackColor == SystemColors.Highlight)
                {
                    item.BackColor = SystemColors.ControlLight;
                }
            }
            btn.BackColor = SystemColors.Highlight;



            int id = int.Parse(btn.Name.Split('_')[2]);
            SanPham sp = db.SanPhams.Find(id);
            int index = 0;
            if (datagrid_hoadonban.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in datagrid_hoadonban.Rows)
                {
                    if (btn.Name.Split('_')[2].ToString() == row.Cells["ID"].Value.ToString())
                    {
                        row.Cells["Số lượng"].Value = int.Parse(row.Cells["Số lượng"].Value.ToString()) + 1;
                        if (sp.GiaTien != "" && sp.GiaTien != null)
                        {
                            row.Cells["Tổng"].Value = int.Parse(row.Cells["Số lượng"].Value.ToString()) * int.Parse(sp.GiaTien);
                            row.Cells["Tổng cộng"].Value = string.Format("{0:#,##0}", int.Parse(row.Cells["Số lượng"].Value.ToString()) * int.Parse(sp.GiaTien));

                        }
                        UpdateTongCongHoaDon();
                        return;
                    }
                    index++;
                }
            }
            if (sp.GiaTien != "" && sp.GiaTien != null)
            {
                datagrid_hoadonban.Rows.Add(sp.SanPhamId, sp.TenSanPham, 1, sp.GiaTien, sp.GiaTien, string.Format("{0:#,##0}", int.Parse(sp.GiaTien)));
            }
            else
            {
                datagrid_hoadonban.Rows.Add(sp.SanPhamId, sp.TenSanPham, 1, "vui lòng cập nhật giá ?", "vui lòng cập nhật giá ?");
            }

            UpdateTongCongHoaDon();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sothutu = 0;
            foreach (var item in db.BanBidas)
            {
                sothutu = int.Parse(item.TenBanBida.Split(' ')[2]);
            }
            BanBida ban = new BanBida();
            ban.TenBanBida = "bàn số " + (sothutu + 1).ToString();
            db.BanBidas.Add(ban);
            db.SaveChanges();
            LoadDanhSachBan();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int sothutu = 0;
            foreach (var item in db.BanBidas)
            {
                sothutu = item.BanBidaId;
            }
            BanBida ban = db.BanBidas.Find(sothutu);
            if (ban != null)
            {
                db.BanBidas.Remove(ban);
                db.SaveChanges();
                LoadDanhSachBan();
            }
            else
            {
                MessageBox.Show("không có gì để xóa hết");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            idsanpham = int.Parse(selectedSanPham.Name.Split('_')[2]);
            SuaSanPham frm = new SuaSanPham();
            frm.ShowDialog();
            fpanelSanPham.Controls.Clear();
            LoadDanhSachSanPham();
        }

        private void btnLuuHoaDon_Click(object sender, EventArgs e)
        {
            if (selectedBan == null)
            {
                MessageBox.Show("chưa chọn bàn");
                return;
            }

            int idBan = int.Parse(selectedBan.Name.Split('_')[2].ToString());
            HoaDonBan hoadonban = new HoaDonBan();
            bool banDangHoatDong = false;
            foreach (var item in db.HoaDonBans)
            {
                if (item.idBanbida == idBan && item.TinhTrang == "đang hoạt động")
                {
                    banDangHoatDong = true;
                    hoadonban = item;
                    break;
                }
            }
            if (!banDangHoatDong)
            {
                hoadonban.idBanbida = idBan;
                hoadonban.NgayBan = DateTime.Now;
                hoadonban.TinhTrang = "đang hoạt động";
                db.HoaDonBans.Add(hoadonban);
                db.SaveChanges();
                foreach (DataGridViewRow row in datagrid_hoadonban.Rows)
                {
                    ChiTietHoaDonBan chitiet = new ChiTietHoaDonBan();
                    chitiet.IdSanPham = int.Parse(row.Cells["ID"].Value.ToString());
                    chitiet.Soluong = int.Parse(row.Cells["Số lượng"].Value.ToString());
                    chitiet.IdHoaDonBan = hoadonban.HoaDonBanId;
                    db.ChiTietHoaDonBans.Add(chitiet);
                    db.SaveChanges();
                }
                datagrid_hoadonban.Rows.Clear();
                BanBida banmoi = db.BanBidas.Find(idBan);
                banmoi.TinhTrang = "đang hoạt động";
                db.Entry(banmoi).State = EntityState.Modified;
                db.SaveChanges();
                LoadDanhSachBan();
                MessageBox.Show("Đã thêm vào bàn " + db.BanBidas.Find(idBan).TenBanBida + " thành công");
            }
            else
            {
                int idhoadonban = hoadonban.HoaDonBanId;
                int index = 0;
                List<ChiTietHoaDonBan> list = new List<ChiTietHoaDonBan>();
                //danh sach sản phẩm đã có trong hóa đơn
                foreach (var item in db.ChiTietHoaDonBans)
                {
                    if (item.IdHoaDonBan == idhoadonban)
                    {
                        list.Add(item);
                    }
                }
                foreach (DataGridViewRow row in datagrid_hoadonban.Rows)
                {
                    if (row.Cells["Tên sản phẩm"].Value.ToString() == "Tiền giờ") { }
                    //nếu sản phẩm chưa có
                    else if (index >= list.Count())
                    {
                        ChiTietHoaDonBan chitiet = new ChiTietHoaDonBan();
                        chitiet.IdSanPham = int.Parse(row.Cells["ID"].Value.ToString());
                        chitiet.Soluong = int.Parse(row.Cells["Số lượng"].Value.ToString());
                        chitiet.IdHoaDonBan = hoadonban.HoaDonBanId;
                        db.ChiTietHoaDonBans.Add(chitiet);
                        db.SaveChanges();
                        if (index < list.Count())
                        {
                            index++;
                        }

                    }
                    else
                    {
                        //nếu sản phẩm đã có trong hóa đơn
                        //cộng thêm số lượng vào
                        list[index].Soluong = int.Parse(row.Cells["Số lượng"].Value.ToString());
                        db.Entry(list[index]).State = EntityState.Modified;
                        db.SaveChanges();
                        if (index < list.Count())
                        {
                            index++;
                        }
                    }
                }
                MessageBox.Show("Đã sửa bàn " + db.BanBidas.Find(idBan).TenBanBida + " thành công");
                hoadonban.TinhTrang = "đang hoạt động";
                hoadonban.BanBida.TinhTrang = "đang hoạt động";
                db.Entry(hoadonban).State = EntityState.Modified;
                db.SaveChanges();
                datagrid_hoadonban.Rows.Clear();
                LoadDanhSachBan();
            }
            fpanelSanPham.Visible = false;
            thietLapLaiHoaDon();
        }
        public void thietLapLaiHoaDon()
        {
            datagrid_hoadonban.Rows.Clear();
            lbTenBan.Text = "";
            labelTongCong.Text = "";
            btnLuuHoaDon.Enabled = false;
            btnThanhToan.Enabled = false;
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (selectedBan == null)
            {
                MessageBox.Show("chưa chọn bàn");
                return;
            }
            int idBan = int.Parse(selectedBan.Name.Split('_')[2].ToString());
            string thongTinHoaDon = "---------------------------------------" + Environment.NewLine;
            foreach (DataGridViewRow row in datagrid_hoadonban.Rows)
            {
                thongTinHoaDon = thongTinHoaDon + row.Cells["Tên sản phẩm"].Value.ToString() +
                    " |số lượng: " + row.Cells["Số lượng"].Value.ToString() +
                    " |Đơn giá: " + row.Cells["Đơn giá"].Value.ToString() +
                    " |Tổng cộng: " + row.Cells["Tổng cộng"].Value.ToString() + Environment.NewLine;
            }
            thongTinHoaDon = thongTinHoaDon + "---------------------------------------" + Environment.NewLine;
            thongTinHoaDon = thongTinHoaDon + "Tổng cộng :" + labelTongCong.Text;
            DialogResult dialogResult = MessageBox.Show(thongTinHoaDon, "Thanh toán " + selectedBan.Text + ", bạn có muốn thanh toán hay không", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                foreach (var item in db.HoaDonBans)
                {
                    if (item.idBanbida == idBan && item.TinhTrang == "đang hoạt động")
                    {
                        HoaDonBan hoadon = item;
                        hoadon.TinhTrang = "đã thanh toán";
                        hoadon.TienGio = (DateTime.Now - hoadon.NgayBan).Value.TotalMinutes * (25000 / 60);
                        hoadon.TongTien = int.Parse(lbTongtien.Text);
                        db.Entry(hoadon).State = EntityState.Modified;
                        BanBida banmoi = db.BanBidas.Find(idBan);
                        banmoi.TinhTrang = "";
                        db.Entry(banmoi).State = EntityState.Modified;
                    }
                }
                db.SaveChanges();
                LoadDanhSachBan();
                thietLapLaiHoaDon();
                fpanelSanPham.Visible = false;
                MessageBox.Show("Đã thanh toán thành công !", "Thông báo !");
                
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }


        }

        private void btnCloseApp_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn đóng chương trình hay không ?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnMaximized_Click(object sender, EventArgs e)
        {
            this.WindowState = this.WindowState == System.Windows.Forms.FormWindowState.Maximized ? System.Windows.Forms.FormWindowState.Normal : System.Windows.Forms.FormWindowState.Maximized;
        }

        private void btnMinimized_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Button item = sender as Button;
            fpanelSanPham.Hide();
            if (item.Name == "btnKichThuoc1")
            {
                foreach (Button btn in fpanelSanPham.Controls)
                {
                    btn.Size = new Size(90, 90);
                }
            }
            else if (item.Name == "btnKichThuoc2")
            {
                foreach (Button btn in fpanelSanPham.Controls)
                {
                    btn.Size = new Size(110, 110);
                }
            }
            else if (item.Name == "btnKichThuoc3")
            {
                foreach (Button btn in fpanelSanPham.Controls)
                {
                    btn.Size = new Size(140, 140);
                }
            }
            fpanelSanPham.Show();

        }

        private void btnXoaSanPham_Click(object sender, EventArgs e)
        {
            SanPham sanpham = db.SanPhams.Find(idsanpham);
            if (sanpham != null)
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa " + sanpham.TenSanPham + " không ?", "Xác nhận", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    sanpham.isDelete = true;
                    db.Entry(sanpham).State = EntityState.Modified;
                    db.SaveChanges();
                    LoadDanhSachSanPham();
                    MessageBox.Show("đã xóa thành công!");
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn sản phẩm");
            }
        }

        private void btnPlayMusic_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "file mp3 (*.mp3)|*.mp3|file lossless (*.flac)|*.mp3|tất cả (*.*)|*.*";
            DialogResult ret = dlg.ShowDialog();
            if (ret == DialogResult.OK)
            {
                axWindowsMediaPlayer1.URL = dlg.FileName;

            }

        }

        private void datagrid_hoadonban_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    var hti = datagrid_hoadonban.HitTest(e.X, e.Y);
                    datagrid_hoadonban.ClearSelection();
                    datagrid_hoadonban.Rows[hti.RowIndex].Selected = true;

                    ContextMenu m = new ContextMenu();
                    m.MenuItems.Add(new MenuItem("Xóa " + datagrid_hoadonban.Rows[hti.RowIndex].Cells["Tên sản phẩm"].Value));
                    m.Show(datagrid_hoadonban, new Point(e.X, e.Y));
                    m.MenuItems[0].Click += DeleteRow_Click;
                }
            }
            catch (ArgumentOutOfRangeException) { }

        }

        private void DeleteRow_Click(object sender, EventArgs e)
        {
            Int32 rowToDelete = datagrid_hoadonban.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            
            UpdateTongCongHoaDon();
            ChiTietHoaDonBan chitiet = new ChiTietHoaDonBan();
            SanPham sp = db.SanPhams.Find(datagrid_hoadonban.Rows[rowToDelete].Cells["ID"].Value);
            foreach(var item in db.ChiTietHoaDonBans)
            {
                if (item.IdSanPham == sp.SanPhamId && item.HoaDonBan.TinhTrang == "đang hoạt động" && item.HoaDonBan.BanBida.BanBidaId == int.Parse(selectedBan.Name.Split('_')[2]))
                {
                    item.isDelete = true;
                    chitiet = item;
                    break;
                }
            }
            db.ChiTietHoaDonBans.Remove(chitiet);
            db.SaveChanges();
            datagrid_hoadonban.Rows.RemoveAt(rowToDelete);
            datagrid_hoadonban.ClearSelection();
            
        }

        private void datagrid_hoadonban_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            datagrid_hoadonban.Rows[e.RowIndex].Cells["Tổng cộng"].Value = int.Parse(datagrid_hoadonban.Rows[e.RowIndex].Cells["Đơn giá"].Value.ToString()) * int.Parse(datagrid_hoadonban.Rows[e.RowIndex].Cells["Số lượng"].Value.ToString());
        }

        #region di chuyển cửa sổ
            public const int WM_NCLBUTTONDOWN = 0xA1;
            public const int HT_CAPTION = 0x2;

            [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
            public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
            [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
            public static extern bool ReleaseCapture();

            private void panel7_MouseDown(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            }
        #endregion
    }
}
