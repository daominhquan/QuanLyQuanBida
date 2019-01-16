using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bida
{
    public partial class ThemSanPham : Form
    {
        private CodeFirstDBEntities db = new CodeFirstDBEntities();

        public ThemSanPham()
        {
            InitializeComponent();
            txtGiaTien.Maximum = int.MaxValue;
            txtSoLuong.Maximum = int.MaxValue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(var item in db.SanPhams)
            {
                if (item.TenSanPham == txtTenSanPham.Text && item.isDelete==null)
                {
                    MessageBox.Show("Tên Sản phẩm đã tồn tại, vui lòng đặt tên khác");
                    return;
                }
            }
            if (txtTenSanPham.Text.Count() > 0)
            {
                SanPham sanpham = new SanPham();
                sanpham.TenSanPham = txtTenSanPham.Text;
                sanpham.HinhAnh = txtUrlHinh.Text;
                sanpham.GiaTien = txtGiaTien.Text;
                sanpham.Soluong = int.Parse(txtSoLuong.Text);
                db.SanPhams.Add(sanpham);
                db.SaveChanges();
                this.Close();
            }
            else
            {
                MessageBox.Show("vui lòng nhập tên sản phẩm");
            }
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
