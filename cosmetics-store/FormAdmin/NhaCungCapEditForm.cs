using System;
using System.Windows.Forms;

namespace cosmetics_store.Forms
{
    public partial class NhaCungCapEditForm : DevExpress.XtraEditors.XtraForm
    {
        public NhaCungCapEditForm()
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

        private void NhaCungCapEditForm_Load(object sender, EventArgs e)
        {

        }
    }
}
