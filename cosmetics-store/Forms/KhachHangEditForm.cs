using System;
using System.Windows.Forms;

namespace cosmetics_store.Forms
{
    public partial class KhachHangEditForm : DevExpress.XtraEditors.XtraForm
    {
        public KhachHangEditForm()
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
    }
}
