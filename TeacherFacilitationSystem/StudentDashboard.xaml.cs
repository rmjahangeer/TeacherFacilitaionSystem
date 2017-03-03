using System.Windows;

namespace TeacherFacilitationSystem
{
    /// <summary>
    /// Interaction logic for StudentDashboard.xaml
    /// </summary>
    public partial class StudentDashboard : Window
    {
        public StudentDashboard()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var student = new StudentProfile();
            student.Show();
        }

        private void Button_Click_StartQuiz(object sender, RoutedEventArgs e)
        {
            var quiz = new Quiz();
            quiz.Show();

        }

        private void Button_Click_ViewAnnouncement(object sender, RoutedEventArgs e)
        {
            var view = new ViewAnnouncement();
            view.Show();
        }

        private void Button_Click_Result(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
