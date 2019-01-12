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

        }
        public void LoadDanhSachBan()
        {
            panel1.Controls.Clear();
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
                    foreach(HoaDonBan hoadon in db.HoaDonBans)
                    {
                        if(hoadon.idBanbida==item.BanBidaId&&hoadon.TinhTrang=="đang hoạt động")
                        {
                            double sophut = Math.Round((DateTime.Now - hoadon.NgayBan).Value.TotalMinutes);
                            newButton.Text = item.TenBanBida + Environment.NewLine +sophut.ToString() +" phút";
                            break;
                        }
                    }
                    string startupPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Picture\\dacokhach.png";
                    Image myimage = new Bitmap(startupPath);//tạo biến lưu lại hình ảnh bởi đường dẫn
                    newButton.BackgroundImage = myimage;//đổi ảnh nền của button 
                    newButton.BackgroundImageLayout = ImageLayout.Zoom;
                    newButton.ForeColor= newButton.BackColor = Color.Transparent;
                    newButton.FlatStyle = FlatStyle.Flat;

                }
                else
                {
                    string startupPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Picture\\chuacokhach.png";
                    Image myimage = new Bitmap(startupPath);//tạo biến lưu lại hình ảnh bởi đường dẫn
                    newButton.BackgroundImage = myimage;//đổi ảnh nền của button 
                    newButton.BackgroundImageLayout = ImageLayout.Zoom;
                    newButton.ForeColor = newButton.BackColor = Color.Transparent;
                    newButton.FlatStyle = FlatStyle.Flat;
                }
                newButton.Click += btnBan_Click;
                index++;
                left = left + 140;
                if (index % 2 == 0)
                {
                    top = top + 170;
                    left = 10;
                }
                panel1.Controls.Add(newButton);
            }
            panel1.AutoScroll = false;
            panel1.HorizontalScroll.Enabled = false;
            panel1.HorizontalScroll.Visible = false;
            panel1.HorizontalScroll.Maximum = 0;
            panel1.AutoScroll = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            LoadDanhSachBan();
        }

        public void loadDuLieuBanLenHoaDon(int id)
        {
            datagrid_hoadonban.Rows.Clear();
            int index = 0;
            foreach (var item in db.ChiTietHoaDonBans)
            {
                if (item.HoaDonBan.idBanbida == id && item.HoaDonBan.TinhTrang == "đang hoạt động")
                {
                    double sophut = Math.Round((DateTime.Now - item.HoaDonBan.NgayBan).Value.TotalMinutes);
                    datagrid_hoadonban.Rows.Add("", "Tiền giờ", sophut, (25000 / 60), Math.Round(sophut * (25000 / 60) / 1000) * 1000, string.Format("{0:#,##0}", Math.Round(sophut * (25000 / 60) / 1000) * 1000));
                    UpdateTongCongHoaDon();
                    break;
                }
            }
            foreach (var item in db.ChiTietHoaDonBans)
            {
                if (item.HoaDonBan.idBanbida == id && item.HoaDonBan.TinhTrang=="đang hoạt động")
                {
                    datagrid_hoadonban.Rows.Add(item.IdSanPham, item.SanPham.TenSanPham, item.Soluong, item.SanPham.GiaTien, item.Soluong.Value* int.Parse(item.SanPham.GiaTien), string.Format("{0:#,##0}", item.Soluong.Value * int.Parse(item.SanPham.GiaTien)));
                    index++;
                }
            }
            UpdateTongCongHoaDon();
            

        }

        public void LoadDanhSachSanPham()
        {
            db = new CodeFirstDBEntities();
            panelSanPham.Controls.Clear();
            int top = 40;
            int left = 10;
            int index = 0;
            foreach (var item in db.SanPhams)
            {
                Button newButton = new Button();
                newButton.Text = item.TenSanPham;
                newButton.Size = new Size(75, 27);
                newButton.Location = new Point(left, top);
                newButton.Name = "btn_Ban_" + item.SanPhamId;
                newButton.Size = new Size(90, 90);
                if (item.HinhAnh != null && item.HinhAnh != "")
                {
                    //string startupPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Picture\\hinhbanbida.jpg";
                    Image myimage = new Bitmap(item.HinhAnh);//tạo biến lưu lại hình ảnh bởi đường dẫn
                    newButton.BackgroundImage = myimage;//đổi ảnh nền của button 
                    newButton.BackgroundImageLayout = ImageLayout.Zoom;
                }
                newButton.BackColor = Color.White;
                newButton.ForeColor = Color.Black;
                newButton.FlatStyle = FlatStyle.Flat;
                newButton.Click += btnSanPham_Click;

                index++;
                left = left + 100;
                //if (index % 5 == 0)
                //{
                //    top = top + 100;
                //    left = 10;
                //}
                if (left + 100 > panelSanPham.Size.Width)
                {
                    top = top + 100;
                    left = 10;
                }

                panelSanPham.Controls.Add(newButton);
            }
            panelSanPham.AutoScroll = false;
            panelSanPham.HorizontalScroll.Enabled = false;
            panelSanPham.HorizontalScroll.Visible = false;
            panelSanPham.HorizontalScroll.Maximum = 0;
            panelSanPham.AutoScroll = true;
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
            foreach(Button item in panel1.Controls)
            {
                if (item.BackColor == SystemColors.Highlight)
                {
                    item.BackColor = SystemColors.Control;
                }
            }
            btn.BackColor = SystemColors.Highlight;
            loadDuLieuBanLenHoaDon(int.Parse(btn.Name.Split('_')[2]));
            panelMain.Visible = true;
            //UpdateTongCongHoaDon();
        }
        private void btnSanPham_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btnSuaSanPham.Enabled = true;
            selectedSanPham = btn;
            foreach (Button item in panelSanPham.Controls)
            {
                if(item.BackColor == SystemColors.Highlight)
                {
                    item.BackColor = SystemColors.Control;
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
                datagrid_hoadonban.Rows.Add(sp.SanPhamId, sp.TenSanPham, 1, sp.GiaTien, sp.GiaTien);
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
            panelSanPham.Controls.Clear();
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
                    if(row.Cells["Tên sản phẩm"].Value.ToString()=="Tiền giờ"){}
                    //nếu sản phẩm chưa có
                    else if (index>=list.Count())
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

        }

        private void panelSanPham_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == System.Windows.Forms.FormWindowState.Maximized)
            {
                LoadDanhSachSanPham();
            }
            else { LoadDanhSachSanPham(); }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (selectedBan == null)
            {
                MessageBox.Show("chưa chọn bàn");
                return;
            }
            int idBan = int.Parse(selectedBan.Name.Split('_')[2].ToString());
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
            datagrid_hoadonban.Rows.Clear();
            MessageBox.Show("Thanh toán thành công");
        }
    }
}
