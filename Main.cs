using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentsDiary
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            var path = $@"{Path.GetDirectoryName(Application.ExecutablePath)}\..\NowyPlik2.txt";

            //poniższy kod zastępuje AppendAllText
            //if (!File.Exists(path))
            //{
            //    // inna możłiwa lokalizacja pliku
            //    // System.IO.File.Create(@"C:\Users\Jarek\Desktop\Akademia dotNETa\StudentsDiary\NowyPlik.txt");
            //    File.Create(path);
            //}

            //File.Delete(path);
            //File.WriteAllText(path, "Zostań programistą .Net");
            File.AppendAllText(path, "Akademia .Net");

            var text = File.ReadAllText(path);

            MessageBox.Show(text);
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }
    }
}
