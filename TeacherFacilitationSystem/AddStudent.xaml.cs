using System.Collections.Generic;
using System.Windows;
using BusinessLogicLayer;
using BusinessObjects;

namespace TeacherFacilitationSystem
{
    /// <summary>
    /// Interaction logic for AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {
        private List<Student> list;
        public AddStudent()
        {
            InitializeComponent();
            list = new List<Student>();
            StudentDataGrid.ItemsSource = list;
        }

        private void Btn_Add(object sender, RoutedEventArgs e)
        {
            var studentBll = new StudentBll();
            //var student = new Student()
            //{
            //    Name = TextBoxName.Text,
            //    Address = TextBoxAddres.Text,
            //    RollNumber = TextBoxRollNo.Text,
            //    Password = TextBoxPassword.Text,
            //    UserName = TextBoxUsername.Text
            //};
            //if(studentBll.Add(student))
            //    MessageBox.Show("Student Added.");

            for (int rows = 0; rows < StudentDataGrid.Items.Count - 1; rows++)
            {
                var student = new Student();
                student = (Student)StudentDataGrid.Items[rows];
                studentBll.Add(student);
            }

        }
    }
}
