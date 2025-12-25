using System;
using System.Drawing;
using System.Windows.Forms;
using cosmetics_store.Helpers;

namespace cosmetics_store.Forms
{
    public partial class fCostumer : DevExpress.XtraEditors.XtraForm
    {
        public fCostumer()
        {
            InitializeComponent();
            ApplyVietnameseFont();
        }

        private void ApplyVietnameseFont()
        {
            // Áp d?ng font h? tr? ti?ng Vi?t
            this.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Text = "Quản lý khách hàng";

            // Search control
            searchControl.Properties.NullValuePrompt = "Tìm khách hàng theo tên hoặc SĐT...";
            searchControl.Font = new Font("Segoe UI", 9.75F);

            // Radio buttons
            rdoAll.Font = new Font("Segoe UI", 9.75F);
            rdoAll.Text = "Tất cả";

            rdoMale.Font = new Font("Segoe UI", 9.75F);
            rdoMale.Text = "Nam";

            rdoFemale.Font = new Font("Segoe UI", 9.75F);
            rdoFemale.Text = "Nữ";

            // Buttons
            btnAdd.Font = new Font("Segoe UI", 9.75F);
            btnAdd.Text = "Thêm";

            btnEdit.Font = new Font("Segoe UI", 9.75F);
            btnEdit.Text = "Sửa";

            btnDelete.Font = new Font("Segoe UI", 9.75F);
            btnDelete.Text = "Xóa";

            // Grid
            gridView1.Appearance.Row.Font = new Font("Segoe UI", 9.75F);
            gridView1.Appearance.HeaderPanel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
        }

        private void searchControl_TextChanged(object sender, EventArgs e)
        {
        }

        private void rdoAll_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rdoMale_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rdoFemale_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
