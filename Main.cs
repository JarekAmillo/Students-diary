using Microsoft.VisualBasic;
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
using System.Xml.Serialization;

namespace StudentsDiary
{
    public partial class Main : Form
    {
        private string _filePath = Path.Combine(Environment.CurrentDirectory, "students.txt");
            
        public Main()
        {
            InitializeComponent();

            //var students = new List<Student>();
            //students.Add(new Student() { FirstName = "Jan" });
            //students.Add(new Student() { FirstName = "Krzysiek" });
            //students.Add(new Student() { FirstName = "Marcin" });

            //SerializeToFile(students);

            //var students = DeserializeFromFile();
            //foreach (var item in students)
            //{
            //    MessageBox.Show(item.FirstName);
            //}

            //var path = $@"{Path.GetDirectoryName(Application.ExecutablePath)}\..\NowyPlik2.txt";

            //poniższy kod zastępuje AppendAllText
            //if (!File.Exists(path))
            //{
            //    // inna możłiwa lokalizacja pliku
            //    // System.IO.File.Create(@"C:\Users\Jarek\Desktop\Akademia dotNETa\StudentsDiary\NowyPlik.txt");
            //    File.Create(path);
            //}

            //File.Delete(path);
            //File.WriteAllText(path, "Zostań programistą .Net");
            //File.AppendAllText(path, "Akademia .Net");

            //var text = File.ReadAllText(path);

            //MessageBox.Show(text);
            //MessageBox.Show("Test","tytuł", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Error);
        }

        public void SerializeToFile(List<Student> students)
        {
            var serializer = new XmlSerializer(typeof(List<Student>));

            using (var streamWriter = new StreamWriter(_filePath))
            {
                serializer.Serialize(streamWriter, students);
                streamWriter.Close();
            }
        }

        public List<Student> DeserializeFromFile()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Student>();
            }


            var serializer = new XmlSerializer(typeof(List<Student>));
            
            using (var streamReader = new StreamReader(_filePath))
            {
                var students = (List<Student>)serializer.Deserialize(streamReader);
                streamReader.Close();
                return students;
            }


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
