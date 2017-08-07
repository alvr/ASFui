using System;
using System.Windows.Forms;

namespace ASFui
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var asf = new ASFui();
            asf.Text += @" - v" + Application.ProductVersion;
            Application.Run(asf);
        }
    }
}
