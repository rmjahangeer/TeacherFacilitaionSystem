using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for ViewReport.xaml
    /// </summary>
    public partial class ViewReport : Window
    {
        public ViewReport()
        {
            InitializeComponent();
            ViewStudentReport();
        }


        private void ViewStudentReport()
        { 
            StudentBll studentBll = new StudentBll();
            List<Student> list= studentBll.GetStudents();

            var student = new DataTable("Students");
            student.Columns.Add("Id");
            student.Columns.Add("Name");
            student.Columns.Add("RollNo");
            student.Columns.Add("Address");
            student.Columns.Add("Username");
            student.Columns.Add("Password");
            foreach (Student c in list)
            {
                DataRow dr = student.NewRow();
                dr["Id"] = c.Id;
                dr["Name"] = c.Name;
                dr["RollNo"] = c.RollNumber;
                dr["Address"] = c.Address;
                dr["Username"] = c.UserName;
                dr["Password"] = c.Password;
                student.Rows.Add(dr);
            }
            ReportViewer.LocalReport.DataSources.Clear();

            ReportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("StudentReportDataSet", student));
            
            ReportViewer.LocalReport.ReportPath = @"C:\Users\M.Jahangeer\documents\visual studio 2013\Projects\TeacherFacilitationSystem\TeacherFacilitationSystem\StudentReport.rdlc";

            ReportViewer.LocalReport.EnableExternalImages = true;

            ReportViewer.RefreshReport();
        }
    }
}
