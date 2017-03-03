using System.Windows;
using BusinessLogicLayer;
using BusinessObjects;

namespace TeacherFacilitationSystem
{
    /// <summary>
    /// Interaction logic for UpdateDetail.xaml
    /// </summary>
    public partial class UpdateDetail : Window
    {
        private string rollnumber;
        public UpdateDetail()
        {
            InitializeComponent();
        }

        private void Btn_FindStudent(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(TextBox1.Text) && string.IsNullOrEmpty(TextBox2.Text))
            {
                MessageBox.Show("Search fields, Name or RollNo is empty.");
                return;
            }

            var studentBll = new StudentBll();
            Student student = studentBll.GetStudentData(TextBox1.Text, TextBox2.Text);

            if (student == null)
            {
                MessageBox.Show("No such student exists.");
                return;
            }

            TextBox1.Text = student.Name;
            TextBox2.Text = student.RollNumber;
            TextBox3.Text = student.Address;
            TextBox4.Text = student.UserName;
            TextBox5.Text = student.Password;

            rollnumber = student.RollNumber;
        }

        private void Btn_Update_Detail(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox1.Text) ||
                string.IsNullOrEmpty(TextBox2.Text) ||
                string.IsNullOrEmpty(TextBox3.Text) ||
                string.IsNullOrEmpty(TextBox4.Text) ||
                string.IsNullOrEmpty(TextBox5.Text))
            {
                MessageBox.Show("One of fields are empty.");
                return;
            }

            var student = new Student
            {
                Name = TextBox1.Text,
                Address = TextBox3.Text,
                UserName = TextBox4.Text,
                Password = TextBox5.Text,
                RollNumber = rollnumber
            };
            var studentBll = new StudentBll();
            if (studentBll.UpdateStudent(student))
            {
                MessageBox.Show("Record Updated");
                Close();
            }
            else
            {
                MessageBox.Show("Some thing went wrong.");
                Close();
            }
                
        }
    }
}
