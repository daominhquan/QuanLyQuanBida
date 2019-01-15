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
    public partial class SuaSanPham : Form
    {
        private CodeFirstDBEntities db = new CodeFirstDBEntities();
        public SuaSanPham()
        {
            InitializeComponent();
            txtGiaTien.Maximum = int.MaxValue;
            txtSoLuong.Maximum = int.MaxValue;
        }

        private void SuaSanPham_Load(object sender, EventArgs e)
        {
            SanPham sp = db.SanPhams.Find(FormDanhSachBan.idsanpham);
            txtTenSanPham.Text = sp.TenSanPham;
            txtSoLuong.Text = sp.Soluong.ToString();
            txtGiaTien.Text = sp.GiaTien;
            if (sp.HinhAnh != null && sp.HinhAnh != "")
            {
                txtUrlHinh.Text = sp.HinhAnh;
                Image myimage = new Bitmap(sp.HinhAnh);//tạo biến lưu lại hình ảnh bởi đường dẫn
                pictureBox1.BackgroundImage = myimage;//đổi ảnh nền của button 
                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SanPham sanpham = db.SanPhams.Find(FormDanhSachBan.idsanpham);
            foreach (var item in db.SanPhams)
            {
                if (item.TenSanPham == txtTenSanPham.Text && item.SanPhamId != FormDanhSachBan.idsanpham)
                {
                    MessageBox.Show("Tên Sản phẩm đã tồn tại, vui lòng đặt tên khác");
                    txtTenSanPham.Text = "";
                    return;
                }
            }
            sanpham.TenSanPham = txtTenSanPham.Text;


            int testgiatien;
            if (int.TryParse(txtGiaTien.Text, out testgiatien))
            {
                sanpham.GiaTien = txtGiaTien.Text;
            }
            else
            {
                MessageBox.Show("giá tiền chỉ được nhập số");
                return;
            }
            int testsoluong;
            if (int.TryParse(txtSoLuong.Text, out testsoluong))
            {
                sanpham.Soluong = int.Parse(txtSoLuong.Text);
            }
            else
            {
                MessageBox.Show("Số lượng chỉ được nhập số");
                return;
            }
            sanpham.HinhAnh = txtUrlHinh.Text;

            db.Entry(sanpham).State = EntityState.Modified;
            db.SaveChanges();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                string startupPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Picture\\";
                openFileDialog.InitialDirectory = startupPath;
                openFileDialog.Filter = "hình jpg (*.jpg)|*.jpg|hình png (*.png)|*.png|hình gif (*.gif)|*.png|tất cả (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)//mở hộp thoại chọn file hình ảnh
                {
                    filePath = openFileDialog.FileName; //lấy đường dẫn của file đã chọn
                    var fileStream = openFileDialog.OpenFile(); //Read the contents of the file into a stream
                    if (File.Exists(startupPath + Path.GetFileName(filePath)) == false)//nếu file chưa tồn tại trong thư mục Picture
                    {
                        File.Copy(filePath, startupPath + Path.GetFileName(filePath));//Copy file đã chọn vào thư mục của project
                        Image myimage = new Bitmap(filePath);//tạo biến lưu lại hình ảnh bởi đường dẫn
                        pictureBox1.BackgroundImage = myimage;//đổi ảnh nền của button 
                        pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                        pictureBox1.Size = new Size(90, 90);
                        pictureBox1.Text = startupPath;
                        //MessageBox.Show("đã lưu hình ảnh vào kho hình thành công");
                        txtUrlHinh.Text = startupPath + Path.GetFileName(filePath);
                    }
                    else//nếu file đã tồn tại trong thư mục Picture mở hộp thoại thông báo    
                    {
                        Image myimage = new Bitmap(startupPath + Path.GetFileName(filePath));//tạo biến lưu lại hình ảnh bởi đường dẫn
                        pictureBox1.BackgroundImage = myimage;//đổi ảnh nền của button 
                        pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                        pictureBox1.Size = new Size(90, 90);
                        pictureBox1.Text = startupPath;
                        //MessageBox.Show("đã tồn tại , chương trình sẽ sử dụng hình ảnh có tên tương tự");
                        txtUrlHinh.Text = startupPath + Path.GetFileName(filePath);
                    }


                }
            }
        }
    }
}
