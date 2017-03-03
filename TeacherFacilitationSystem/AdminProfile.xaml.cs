using System.Windows;

namespace TeacherFacilitationSystem
{
    /// <summary>
    /// Interaction logic for AdminProfile.xaml
    /// </summary>
    public partial class AdminProfile : Window
    {
        public AdminProfile()
        {
            InitializeComponent();
        }

        private void Btn_AddStudent(object sender, RoutedEventArgs e)
        {
            var addStudent = new AddStudent();
            addStudent.Show();
        }

        private void Btn_changePassword(object sender, RoutedEventArgs e)
        {
            var change = new ChangePassword();
            change.Show();
        }

        private void Btn_ViewDeatil(object sender, RoutedEventArgs e)
        {
            var view = new ViewStudentDetails();
            view.Show();
        }

        private void Btn_UpdateDetail(object sender, RoutedEventArgs e)
        {
            var updateDetail = new UpdateDetail();
            updateDetail.Show();
        }
    }
}
