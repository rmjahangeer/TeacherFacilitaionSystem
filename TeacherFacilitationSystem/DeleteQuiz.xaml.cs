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
    /// Interaction logic for DeleteQuiz.xaml
    /// </summary>
    public partial class DeleteQuiz : Window
    {
        Question myQuestion = null;
        public DeleteQuiz()
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
                    myQuestion = question;
                    break;
                }
            }

            if (myQuestion != null)
            {
                QStatemenTextBox.Text = myQuestion.QuestionStatement;
                OptionATextBox.Text = myQuestion.OptionA;
                OptionBTextBox.Text = myQuestion.OptionB;
                OptionCTextBox.Text = myQuestion.OptionC;
                OptionDTextBox.Text = myQuestion.OptionD;
                OptionBox.Text = myQuestion.Answer;
            }
            else
            {
                MessageBox.Show("Nothing found");
            }
        }

        private void Btn_DeleteQuestion(object sender, RoutedEventArgs e)
        {
            
            if (string.IsNullOrEmpty(QuestionIdTextBox.Text))
            {
                MessageBox.Show("Id field is empty");
                return;
            }
            var teacher = new TeacherBll();    

            if (teacher.DeleteQuestionById(int.Parse(QuestionIdTextBox.Text)))
            {
                QStatemenTextBox.Text = "";
                OptionATextBox.Text = "";
                OptionBTextBox.Text = "";
                OptionCTextBox.Text = "";
                OptionDTextBox.Text = "";
                OptionBox.Text = "";
                MessageBox.Show("Question deleted");
                myQuestion = null;
            }
            else
            {
                MessageBox.Show("Something went wrong,Question already deleted or Does not exist");
            }
        }
    }
}
