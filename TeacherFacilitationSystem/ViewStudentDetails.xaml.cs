using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using BusinessLogicLayer;
using BusinessObjects;

namespace TeacherFacilitationSystem
{
    /// <summary>
    /// Interaction logic for ViewStudentDetails.xaml
    /// </summary>
    public partial class ViewStudentDetails : Window
    {
        public ViewStudentDetails()
        {
            InitializeComponent();
            AddColumns();
            GetData();
        }

        private void AddColumns()
        {
            if (StudentDataGrid.Columns.Count > 0)
                StudentDataGrid.Columns.Clear();

            var c1 = new DataGridTextColumn()
            {
                Binding = new Binding("Id"),
                Header = "ID",
                Width = 100,
                FontSize = 16
            };

            var c2 = new DataGridTextColumn()
            {
                Binding = new Binding("Name"),
                Header = "Name",
                Width = 100,
                FontSize = 16
            };

            var c3 = new DataGridTextColumn()
            {
                Binding = new Binding("RollNumber"),
                Header = "Roll Number",
                Width = 100,
                FontSize = 16
            };

            var c4= new DataGridTextColumn()
            {
                Binding = new Binding("Address"),
                Header = "Address",
                Width = 100,
                FontSize = 16
            };
            var c5 = new DataGridTextColumn()
            {
                Binding = new Binding("UserName"),
                Header = "UserName",
                Width = 100,
                FontSize = 16
            };
            var c6 = new DataGridTextColumn()
            {
                Binding = new Binding("Password"),
                Header = "Password",
                Width = 100,
                FontSize = 16
            };
            

            StudentDataGrid.Columns.Add(c1);
            StudentDataGrid.Columns.Add(c2);
            StudentDataGrid.Columns.Add(c3);
            StudentDataGrid.Columns.Add(c4);
            StudentDataGrid.Columns.Add(c5);
            StudentDataGrid.Columns.Add(c6);


        }

        private void GetData()
        {
            var studentBll = new StudentBll();
            List<Student> list = studentBll.GetStudents();
            StudentDataGrid.ItemsSource = list;
        }

    }
}
