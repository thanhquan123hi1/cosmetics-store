using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using cosmetics_store.Forms;
using BusinessAccessLayer.Services;

namespace cosmetics_store
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Seed dữ liệu mặc định (tài khoản Admin)
            try
            {
                DatabaseSeeder.SeedAll();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Seeding error: {ex.Message}");
            }
            
            Application.Run(new fLogin());
        }
    }
}
