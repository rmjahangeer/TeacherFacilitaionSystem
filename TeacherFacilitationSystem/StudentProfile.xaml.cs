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

namespace TeacherFacilitationSystem
{
    /// <summary>
    /// Interaction logic for StudentProfile.xaml
    /// </summary>
    public partial class StudentProfile : Window
    {
        public StudentProfile()
        {
            InitializeComponent();
        }

        private void Btn_changePassword(object sender, RoutedEventArgs e)
        {
            var change = new ChangePasswordStudent();
            change.Show();
        }

        private void Btn_UpdateDetail(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_ViewDeatil(object sender, RoutedEventArgs e)
        {

        }
    }
}
