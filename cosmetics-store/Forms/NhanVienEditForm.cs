using System;
using System.Windows.Forms;

namespace cosmetics_store.Forms
{
    public partial class NhanVienEditForm : DevExpress.XtraEditors.XtraForm
    {
        public NhanVienEditForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtDiaChi_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
