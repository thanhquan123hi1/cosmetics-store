using System;
using System.Windows.Forms;

namespace cosmetics_store.Forms
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // 2. Ki?m tra tài kho?n và m?t kh?u
            if (username == "admin" && password == "123")
            {
                MessageBox.Show("Ok baby!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);

 
                MainForm frmMain = new MainForm();
                frmMain.Show();
                this.Hide(); 
            }
            else
            {
                // 3. X? lý khi ??ng nh?p sai
                MessageBox.Show("Not correct!", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtPassword.Text = ""; // Xóa m?t kh?u ?? nh?p l?i
                txtPassword.Focus();   // ??a con tr? chu?t v? ô m?t kh?u
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lnkForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void txtUsername_EditValueChanged(object sender, EventArgs e)
        {
           
        }

        private void txtPassword_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
