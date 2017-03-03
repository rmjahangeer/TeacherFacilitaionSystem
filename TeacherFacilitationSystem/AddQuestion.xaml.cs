using System.Windows;
using System.Windows.Documents;
using BusinessLogicLayer;
using BusinessObjects;
using MessageBox = System.Windows.MessageBox;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;

namespace TeacherFacilitationSystem
{
    /// <summary>
    /// Interaction logic for AddQuestion.xaml
    /// </summary>
    public partial class AddQuestion : Window
    {
        private string BrowseFile;

        public AddQuestion()
        {
            InitializeComponent();
        }

        private void Btn_Browse(object sender, RoutedEventArgs e)
        {
            var fdlg = new OpenFileDialog
            {
                Title = @"Add Questions",
                InitialDirectory = @"c:\",
                Filter = @"Text files (*.txt)|*.txt",
                FilterIndex = 1,
                RestoreDirectory = true,
                AddExtension = true
            };
            if (fdlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                BrowseTextBox.Text = fdlg.FileName;
                BrowseFile = BrowseTextBox.Text;
            }
        }

        private void Btn_AddQuestion(object sender, RoutedEventArgs e)
        {
            var teacherBll = new TeacherBll();
            if (string.IsNullOrEmpty(BrowseFile))
            {
                if (string.IsNullOrEmpty(OptionComboBox.Text) ||
                    string.IsNullOrEmpty(OptionATextBox.Text) ||
                    string.IsNullOrEmpty(OptionBTextBox.Text) ||
                    string.IsNullOrEmpty(OptionCTextBox.Text) ||
                    string.IsNullOrEmpty(OptionDTextBox.Text) ||
                    string.IsNullOrEmpty(QStatemenTextBox.Text))
                {
                    MessageBox.Show("One of the text field is empty.");
                    return;
                }

                
            }
            else
            {
                if (teacherBll.AddQuestionsFromFile(BrowseFile))
                {
                    MessageBox.Show("Questions Added Succlessfully");
                    Close();
                    return;
                }
                else
                {
                    MessageBox.Show("Something went Wrong");
                    return;
                }
            }
            var question = new Question()
            {
                QuestionStatement = QStatemenTextBox.Text,
                Answer = OptionComboBox.Text,
                OptionA = OptionATextBox.Text,
                OptionB = OptionBTextBox.Text,
                OptionC = OptionCTextBox.Text,
                OptionD = OptionDTextBox.Text
            };

            if (teacherBll.AddQuestion(question))
            {
                MessageBox.Show("Question Added");
                Close();
            }
            else
                MessageBox.Show("Sorry. Something went wrong.");
        }
    }
}
