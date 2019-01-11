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
    public partial class Form1 : Form
    {
        private CodeFirstDBEntities  db = new CodeFirstDBEntities();
        public Form1()
        {
            InitializeComponent();
            ReloadSanPham();
        }
        public void ReloadSanPham()
        {
            int top = 10;
            int left = 10;
            int index = 0;
            foreach (var item in db.SanPhams)
            {
                Button newButton = new Button();
                newButton.Text = item.TenSanPham;
                newButton.Size = new Size(75, 27);
                newButton.Location = new Point(left, top);
                newButton.Name = "btn_SP_"+item.SanPhamId;
                newButton.Size = new Size(90, 90);
                index++;
                left = left + 100;
                if (index % 4 == 0)
                {
                    top = top + 100;
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
        private void button1_Click(object sender, EventArgs e)
        {
            int parsedValue;
            if (int.TryParse(txtSoLuong.Text, out parsedValue))
            {
                foreach (var item in db.SanPhams)
                {
                    if(txtTenSP.Text == item.TenSanPham)
                    {
                        MessageBox.Show("sản phẩm này đã có trong danh sách");
                        return;
                    }
                }
                SanPham sanpham = new SanPham();
                sanpham.TenSanPham = txtTenSP.Text;
                sanpham.Soluong = int.Parse(txtSoLuong.Text);
                db.SanPhams.Add(sanpham);
                db.SaveChanges();
                MessageBox.Show("Thêm Thành công");
                ReloadSanPham();
                return;
            }
            else
            {
                MessageBox.Show("Số lượng chỉ được nhập số");
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if(button2.Text== "Thêm")
            {
                PanelThemSanPham.Visible = true;
                button2.Text = "Đóng";
            }
            else
            {
                PanelThemSanPham.Visible = false;
                button2.Text = "Thêm";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                string startupPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName+ "\\Picture\\";
                openFileDialog.InitialDirectory = startupPath;
                openFileDialog.Filter = "hình jpg (*.jpg)|*.jpg|hình png (*.png)|*.png";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)//mở hộp thoại chọn file hình ảnh
                {
                    filePath = openFileDialog.FileName; //lấy đường dẫn của file đã chọn
                    var fileStream = openFileDialog.OpenFile(); //Read the contents of the file into a stream
                    if (File.Exists(startupPath + Path.GetFileName(filePath)) ==false)//nếu file chưa tồn tại trong thư mục Picture
                    {
                        File.Copy(filePath, startupPath + Path.GetFileName(filePath));//Copy file đã chọn vào thư mục của project
                        Image myimage = new Bitmap(filePath);//tạo biến lưu lại hình ảnh bởi đường dẫn
                        button3.BackgroundImage = myimage;//đổi ảnh nền của button 
                        button3.BackgroundImageLayout = ImageLayout.Zoom;
                        button3.TextImageRelation = TextImageRelation.ImageBeforeText;
                        button3.Size = new Size(90, 90);
                        textBox1.Text = startupPath;
                    }
                    else//nếu file đã tồn tại trong thư mục Picture mở hộp thoại thông báo    
                    {
                        MessageBox.Show("đã tồn tại một file có tên tương tự, vui lòng đổi tên file bạn vừa chọn.");
                    }
                    
                    
                }
            }
           
            
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            panel1.Size = new Size(this.Size.Width/2, this.Size.Height / 2);
            panel2.Size = new Size(this.Size.Width/2, this.Size.Height / 2);

        }
    }
}
