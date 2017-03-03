using System.Windows;

namespace TeacherFacilitationSystem
{
    /// <summary>
    /// Interaction logic for TeacherDashboard.xaml
    /// </summary>
    public partial class TeacherDashboard : Window
    {
        public TeacherDashboard()
        {
            InitializeComponent();
        }

        private void Btn_Profile(object sender, RoutedEventArgs e)
        {
            var admin = new AdminProfile();
            admin.Show();
        }

        private void Btn_QuizManagement(object sender, RoutedEventArgs e)
        {
            var quizManagement = new QuizManagement();
            quizManagement.Show();
        }

        private void Btn_PostAnnouncement(object sender, RoutedEventArgs e)
        {
            var announcement = new Announcement();
            announcement.Show();
        }

        private void Btn_Report(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Method UnImplemented.");
            var viewReport = new ViewReport();
            viewReport.Show();
        }
    }
}
