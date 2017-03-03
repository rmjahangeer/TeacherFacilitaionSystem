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

namespace TeacherFacilitationSystem
{
    /// <summary>
    /// Interaction logic for ChangePasswordStudent.xaml
    /// </summary>
    public partial class ChangePasswordStudent : Window
    {
        public ChangePasswordStudent()
        {
            InitializeComponent();
        }

        private void btn_changePassword(object sender, RoutedEventArgs e)
        {
            string oldPassword = OldPassword.Password;
            string newPassword = NewPassword.Password;
            string confirmPassword = ConfirmPassword.Password;
            var student = new StudentBll();

            if (!newPassword.Equals(confirmPassword))
            {
                MessageBox.Show("Passwords donot match.");
            }
            else if (student.ChangePassword(oldPassword, newPassword))
            {
                MessageBox.Show("Password Changed.");
                this.Close();
            }
            else
                MessageBox.Show("Wrong Old Password.");
        }
    }
}
