using System;
using System.Drawing;
using System.Windows.Forms;
using cosmetics_store.Helpers;

namespace cosmetics_store.Forms
{
    public partial class KhachHangForm : DevExpress.XtraEditors.XtraForm
    {
        public KhachHangForm()
        {
            InitializeComponent();
            ApplyVietnameseFont();
        }

        private void ApplyVietnameseFont()
        {
            // Áp d?ng font h? tr? ti?ng Vi?t
            this.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Text = "Qu?n l? khách hàng";

            // Search control
            searchControl.Properties.NullValuePrompt = "T?m khách hàng theo tên ho?c SÐT...";
            searchControl.Font = new Font("Segoe UI", 9.75F);

            // Radio buttons
            rdoAll.Font = new Font("Segoe UI", 9.75F);
            rdoAll.Text = "T?t c?";

            rdoMale.Font = new Font("Segoe UI", 9.75F);
            rdoMale.Text = "Nam";

            rdoFemale.Font = new Font("Segoe UI", 9.75F);
            rdoFemale.Text = "N?";

            // Buttons
            btnAdd.Font = new Font("Segoe UI", 9.75F);
            btnAdd.Text = "Thêm";

            btnEdit.Font = new Font("Segoe UI", 9.75F);
            btnEdit.Text = "S?a";

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
