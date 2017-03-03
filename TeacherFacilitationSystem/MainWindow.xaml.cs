using System.Windows;
using BusinessLogicLayer;
using BusinessObjects;

namespace TeacherFacilitationSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            var teacherBll = new TeacherBll();
            string userName = TxtBoxUserName.Text;
            string password = TxtBoxPassword.Password;

            if (RBtnTeacher.IsChecked == true)
            {
                var teacher = new Teacher()
                {
                    UserName = userName,
                    Password = password
                };

                if (teacherBll.Login(teacher))
                {
                    var teacherDashboard = new TeacherDashboard();
                    //Close();
                    teacherDashboard.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Credentials");
                }

            }
            else if (RBtnStudent.IsChecked == true)
            {
                
                var studentBll = new StudentBll();
                var student = new Student()
                {
                    UserName = userName,
                    Password = password
                };
                if (studentBll.Login(student))
                {
                    var studentDashboard = new StudentDashboard();
                    //Close();
                    studentDashboard.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Credentials");
                }
            }
        }
    }
}
