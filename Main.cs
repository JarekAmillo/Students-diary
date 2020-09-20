using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StudentsDiary
{
    public partial class Main : Form
    {
        private FileHelper <List<Student>> _fileHelper = new FileHelper<List<Student>> (Program.FilePath);


        public Main()
        {
            InitializeComponent();

            RefreshDiary();

            SetColumnsHaeder();

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

        private void RefreshDiary()
        {
            var students = _fileHelper.DeserializeFromFile();
            dgvDiary.DataSource = students;
        }
        private void SetColumnsHaeder()
        {
            dgvDiary.Columns[0].HeaderText = "Numer";
            dgvDiary.Columns[1].HeaderText = "Imię";
            dgvDiary.Columns[2].HeaderText = "Nazwisko";
            dgvDiary.Columns[3].HeaderText = "Uwagi";
            dgvDiary.Columns[4].HeaderText = "Matematyka";
            dgvDiary.Columns[5].HeaderText = "Technologia";
            dgvDiary.Columns[6].HeaderText = "Fizyka";
            dgvDiary.Columns[7].HeaderText = "Język polski";
            dgvDiary.Columns[8].HeaderText = "Język obcy";
        }




        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addEditStudent = new AddEditStudent();
            addEditStudent.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvDiary.SelectedRows.Count == 0)
            {
                MessageBox.Show("Proszę zaznacz ucznia, którego dane chcesz edytować. ");
                return;
            }

            var addEditStudent = new AddEditStudent(Convert.ToInt32(dgvDiary.SelectedRows[0].Cells[0].Value));
            addEditStudent.ShowDialog();


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDiary.SelectedRows.Count == 0)
            {
                MessageBox.Show("Proszę zaznacz ucznia, którego dane chcesz usunąć. ");
                return;
            }

            var selectedSudent = dgvDiary.SelectedRows[0];

            var confirmDelete = 
                MessageBox.Show($"Czy jesteś pewien, że chcesz usunąć ucznia?{(selectedSudent.Cells[1].Value.ToString() + " " + selectedSudent.Cells[2].Value.ToString()).Trim()}", "Usuwanie ucznia", MessageBoxButtons.OKCancel);

            if (confirmDelete == DialogResult.OK)
            {
                DeleteStudent(Convert.ToInt32(selectedSudent.Cells[0].Value));
                RefreshDiary();
            }
        }

        private void DeleteStudent(int id)
        {
            var students = _fileHelper.DeserializeFromFile();
            students.RemoveAll(x => x.Id == id);
            _fileHelper.SerializeToFile(students);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDiary();
        }
    }
}
