using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;


namespace StudentsDiary
{
    public partial class AddEditStudent : Form
    {
        private int _studentId;
        private Student _strudent;

        private FileHelper<List<Student>> _fileHelper = new FileHelper<List<Student>>(Program.FilePath);


        public AddEditStudent(int id = 0)
        {
            InitializeComponent();
            _studentId = id;

            GetStudentData();
            tbFirstName.Select();
        }

        private void GetStudentData()
       {
            if (_studentId != 0)
            {
                Text = "Edytowanie danych ucznia";

                var students = _fileHelper.DeserializeFromFile();
                _strudent = students.FirstOrDefault(x => x.Id == _studentId);

                if (_strudent == null)
                {
                    throw new Exception("Brak użytkownika o podanym Id");
                }

                FillTextBoxes();

            }
        }

        private void FillTextBoxes()
        {
            tbId.Text = _strudent.Id.ToString();
            tbFirstName.Text = _strudent.FirstName;
            tbLastName.Text = _strudent.LastName;
            tbMath.Text = _strudent.Math;
            tbPhysics.Text = _strudent.Physics;
            tbTechnology.Text = _strudent.Technology;
            tbPolishLang.Text = _strudent.PolishLang;
            tbForeignLang.Text = _strudent.ForeignLang;
            rtbComments.Text = _strudent.Comments;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var students = _fileHelper.DeserializeFromFile();

            if (_studentId != 0)
            {
                students.RemoveAll(x => x.Id == _studentId);
            }
            else
            {
                AssignIdToNewStudent(students);
            }
            AddNewUserToList(students);

            _fileHelper.SerializeToFile(students);

            Close();
        }
        private void AddNewUserToList(List<Student> students)
        {
            var student = new Student
            {
                Id = _studentId,
                FirstName = tbFirstName.Text,
                LastName = tbLastName.Text,
                Comments = rtbComments.Text,
                ForeignLang = tbForeignLang.Text,
                Math = tbMath.Text,
                Physics = tbPhysics.Text,
                PolishLang = tbPolishLang.Text,
                Technology = tbTechnology.Text,
            };

            students.Add(student);
        }
        private void AssignIdToNewStudent(List<Student>students)
        {
            var studentWithHighestId = students.OrderByDescending(x => x.Id).FirstOrDefault();

            var _studentId = 0;

            if (studentWithHighestId == null)
            {
                _studentId = 1;
            }
            else
            {
                _studentId = studentWithHighestId.Id + 1;
            }
        }
    }
}
