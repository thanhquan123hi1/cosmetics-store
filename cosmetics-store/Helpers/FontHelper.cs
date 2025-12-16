using System.Drawing;
using System.Windows.Forms;

namespace cosmetics_store.Helpers
{
    public static class FontHelper
    {
        // Font hỗ trợ tiếng Việt
        public static readonly Font VietnameseFont = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        public static readonly Font VietnameseFontBold = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
        public static readonly Font VietnameseFontLarge = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
        public static readonly Font VietnameseFontTitle = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);

        public static void ApplyVietnameseFont(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                control.Font = VietnameseFont;
                if (control.HasChildren)
                {
                    ApplyVietnameseFont(control);
                }
            }
        }
    }
}