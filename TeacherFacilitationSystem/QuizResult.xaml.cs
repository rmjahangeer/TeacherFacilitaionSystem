using System;
using System.Globalization;
using System.Windows;

namespace TeacherFacilitationSystem
{
    /// <summary>
    /// Interaction logic for QuizResult.xaml
    /// </summary>
    public partial class QuizResult : Window
    {
        public QuizResult()
        {
            InitializeComponent();
        }

        public void ComputeResult(int totalQuestions, int attempted, int correctAnswers, int incorrectAnswers, int skipped)
        {
            int marks = correctAnswers*10;
            double x = totalQuestions*1.00;
            double correctness = Math.Round((correctAnswers/x),3)*100;
            TotalTextBlock.Text = totalQuestions.ToString();
            AttemtedTextBlock.Text = attempted.ToString();
            SkippedTextBlock.Text = skipped.ToString();
            CorrectAnswersTextBlock.Text = correctAnswers.ToString();
            IncorrectTextBlock.Text = incorrectAnswers.ToString();
            MarksTextBlock.Text = marks.ToString();
            CorrectnessTextBlock.Text = correctness.ToString(CultureInfo.InvariantCulture);
        }
    }
}
