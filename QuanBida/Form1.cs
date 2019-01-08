using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanBida
{
    
    public partial class Form1 : Form
    {
        private CodeFirstDBEntities1 db = new CodeFirstDBEntities1();
        public Form1()
        {
            
            InitializeComponent();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == txtnhaplaimatkhau.Text)
            {
                var acc = new Account();
                acc.UserName = txtUserName.Text;
                acc.Password = txtPassword.Text;
                db.Accounts.Add(acc);
                db.SaveChanges();
                MessageBox.Show("Thành công");
            }
            else
            {
                MessageBox.Show("Không Khớp");
            }
            
        }

        private void txtnhaplaimatkhau_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            var listAccount = db.Accounts.ToList();
            foreach (var item in listAccount)
            {
                if (item.UserName == txtUserName.Text && item.Password == txtPassword.Text)
                {
                    MessageBox.Show("Đăng nhập thành công");
                    return;
                }
               
            }
            foreach (var item in listAccount)
            {
                if (item.UserName == txtUserName.Text && item.Password != txtPassword.Text)
                {
                    MessageBox.Show("Nhập sai mật khẩu của tài khoản này");
                    return;

                }
            }
            foreach (var item in listAccount)
            {
                if (item.UserName != txtUserName.Text)
                {
                    MessageBox.Show("tài khoản không tồn tại , vui lòng nhập tài khoản khác");
                    return;
                }
            }
        }
    }
}
