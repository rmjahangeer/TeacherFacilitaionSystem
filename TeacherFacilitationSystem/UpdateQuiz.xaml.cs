using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BusinessLogicLayer;
using BusinessObjects;

namespace TeacherFacilitationSystem
{
    /// <summary>
    /// Interaction logic for UpdateQuiz.xaml
    /// </summary>
    public partial class UpdateQuiz : Window
    {
        private Question _myQuestion = null;
        public UpdateQuiz()
        {
            InitializeComponent();
        }

        private void Btn_FindQuestion(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(QuestionIdTextBox.Text))
            {
                MessageBox.Show("Id field is empty");
                return;
            }


            var teacher = new TeacherBll();

            List<Question> list = teacher.GetQuestionsList();
            foreach (Question question in list)
            {
                if (question.QuestionNo == QuestionIdTextBox.Text)
                {
                    _myQuestion = question;
                    break;
                }
            }

            if (_myQuestion != null)
            {
                QStatemenTextBox.Text = _myQuestion.QuestionStatement;
                OptionATextBox.Text = _myQuestion.OptionA;
                OptionBTextBox.Text = _myQuestion.OptionB;
                OptionCTextBox.Text = _myQuestion.OptionC;
                OptionDTextBox.Text = _myQuestion.OptionD;
                OptionBox.Text = _myQuestion.Answer;
            }
            else
            {
                MessageBox.Show("Nothing found");
            }
        }

        private void Btn_UpdateQuestion(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(QuestionIdTextBox.Text))
            {
                MessageBox.Show("Id field is empty");
                return;
            }
            var teacher = new TeacherBll();
            _myQuestion.QuestionStatement = QStatemenTextBox.Text;
            _myQuestion.OptionA = OptionATextBox.Text;
            _myQuestion.OptionB = OptionBTextBox.Text;
            _myQuestion.OptionC = OptionCTextBox.Text;
            _myQuestion.OptionD = OptionDTextBox.Text;
            _myQuestion.Answer = OptionBox.Text;
            if (teacher.UpdateQuestionById(_myQuestion))
            {
                MessageBox.Show("Question Updated");
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }
        }
    }
}
