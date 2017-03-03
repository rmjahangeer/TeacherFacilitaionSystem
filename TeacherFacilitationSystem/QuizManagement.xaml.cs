using System.Windows;

namespace TeacherFacilitationSystem
{
    /// <summary>
    /// Interaction logic for QuizManagement.xaml
    /// </summary>
    public partial class QuizManagement : Window
    {
        public QuizManagement()
        {
            InitializeComponent();
        }

        private void Btn_AddQuiz(object sender, RoutedEventArgs e)
        {
            var addQuestion = new AddQuestion();
            addQuestion.Show();
        }

        private void Btn_ViewAllQuizzez(object sender, RoutedEventArgs e)
        {
            var view = new ViewQuizez();
            view.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var update = new UpdateQuiz();
            update.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var delete = new DeleteQuiz();
            delete.Show();
        }
    }
}
