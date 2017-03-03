using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using BusinessLogicLayer;
using BusinessObjects;

namespace TeacherFacilitationSystem
{
    /// <summary>
    /// Interaction logic for ViewQuizez.xaml
    /// </summary>
    public partial class ViewQuizez : Window
    {
        public ViewQuizez()
        {
            InitializeComponent();
            AddColumns();
            GetData();
        }

        private void AddColumns()
        {
            if (QuizDataGrid.Columns.Count > 0)
                QuizDataGrid.Columns.Clear();

            var c1 = new DataGridTextColumn()
            {
                Binding = new Binding("QuestionNo"),
                Header = "Question #",
                Width = 100,
                FontSize = 16
            };

            var c2 = new DataGridTextColumn()
            {
                Binding = new Binding("QuestionStatement"),
                Header = "Statement",
                Width = 100,
                FontSize = 16
            };

            var c3 = new DataGridTextColumn()
            {
                Binding = new Binding("OptionA"),
                Header = "Option A",
                Width = 100,
                FontSize = 16
            };

            var c4 = new DataGridTextColumn()
            {
                Binding = new Binding("OptionB"),
                Header = "Option B",
                Width = 100,
                FontSize = 16
            };
            var c5 = new DataGridTextColumn()
            {
                Binding = new Binding("OptionC"),
                Header = "Option C",
                Width = 100,
                FontSize = 16
            };
            var c6 = new DataGridTextColumn()
            {
                Binding = new Binding("OptionD"),
                Header = "Option D",
                Width = 100,
                FontSize = 16
            };
            
            var c7 = new DataGridTextColumn()
            {
                Binding = new Binding("Answer"),
                Header = "Answer",
                Width = 100,
                FontSize = 16
            };


            QuizDataGrid.Columns.Add(c1);
            QuizDataGrid.Columns.Add(c2);
            QuizDataGrid.Columns.Add(c3);
            QuizDataGrid.Columns.Add(c4);
            QuizDataGrid.Columns.Add(c5);
            QuizDataGrid.Columns.Add(c6);
            QuizDataGrid.Columns.Add(c7);


        }

        private void GetData()
        {
            var teacherBll = new TeacherBll();
            List<Question> list = teacherBll.GetQuestionsList();
            QuizDataGrid.ItemsSource = list;
        }


    }
}
