using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms.VisualStyles;
using BusinessLogicLayer;
using BusinessObjects;

namespace TeacherFacilitationSystem
{
    /// <summary>
    /// Interaction logic for Quiz.xaml
    /// </summary>
    public partial class Quiz : Window
    {
        private readonly List<Question> _list;
        private int _count = -1;
        private int _attempted = 0;
        private int _correctAnswers = 0;
        private int _incorrectAnswers = 0;
        private int _skipped = 0;

        public Quiz()
        {
            InitializeComponent();
            //_count++;
            var stBll = new StudentBll();
            _list = stBll.GetQuestionsList();
            ShowQuestion();
        }

        private void ShowQuestion()
        {
            _count++;
            try
            {
                LabelQuestionNo.Content = "Question# ";
                LabelQuestionNo.Content += _list[_count].QuestionNo;
                QuestionStatement.Text = _list[_count].QuestionStatement;
                RadioBtnOptionA.Content = _list[_count].OptionA;
                RadioBtnOptionB.Content = _list[_count].OptionB;
                RadioBtnOptionC.Content = _list[_count].OptionC;
                RadioBtnOptionD.Content = _list[_count].OptionD;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There are no more questions.Click Result to see results");
                return;
                //throw;
            }
        }

        private void ClearChecks()
        {
            RadioBtnOptionA.IsChecked = false;
            RadioBtnOptionB.IsChecked = false;
            RadioBtnOptionC.IsChecked = false;
            RadioBtnOptionD.IsChecked = false;
        }

        private void UpdateCount()
        {
            if (_list.Count == _count)
                _count--;

            if (RadioBtnOptionA.IsChecked == true)
            {
                _attempted++;
                if (_list[_count].Answer.Equals("A"))
                    _correctAnswers++;
                else
                    _incorrectAnswers++;
                ClearChecks();
            }
            else if (RadioBtnOptionB.IsChecked == true)
            {
                _attempted++;
                if (_list[_count].Answer.Equals("B"))
                    _correctAnswers++;
                else
                    _incorrectAnswers++;
                ClearChecks();
            }
            else if (RadioBtnOptionC.IsChecked == true)
            {
                _attempted++;
                if (_list[_count].Answer.Equals("C"))
                    _correctAnswers++;
                else
                    _incorrectAnswers++;
                ClearChecks();
            }
            else if (RadioBtnOptionD.IsChecked == true)
            {
                _attempted++;
                if (_list[_count].Answer.Equals("D"))
                    _correctAnswers++;
                else
                    _incorrectAnswers++;
                ClearChecks();
            }
            else
                _skipped++;
        }

        private void Button_Click_next(object sender, RoutedEventArgs e)
        {
            if (_count >= _list.Count)
            {
                MessageBox.Show("There are no more questions.Click Result to see results");
                return;
            }
            
            
            UpdateCount();
            ShowQuestion();
        }

        private void Button_click_Result(object sender, RoutedEventArgs e)
        {
            var quizResult = new QuizResult();
            if (_count <= 0)
            {
                MessageBox.Show("No question Attemted.");
                return;
            }
            //_incorrectAnswers = _count - (_correctAnswers+skipped);
            quizResult.ComputeResult(_count, _attempted, _correctAnswers, _incorrectAnswers, _skipped);
            
            quizResult.Show();
            Close();
        }
    }
}
