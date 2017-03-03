using System.Windows;
using BusinessLogicLayer;

namespace TeacherFacilitationSystem
{
    /// <summary>
    /// Interaction logic for ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void btn_changePassword(object sender, RoutedEventArgs e)
        {
            string oldPassword = OldPassword.Password;
            string newPassword = NewPassword.Password;
            string confirmPassword = ConfirmPassword.Password;
            var teacherBll = new TeacherBll();
            
            if (!newPassword.Equals(confirmPassword))
            {
                MessageBox.Show("Passwords donot match.");
            }
            else if (teacherBll.ChangePassword(oldPassword, newPassword))
            {
                MessageBox.Show("Password Changed.");
                this.Close();
            }
            else
                MessageBox.Show("Wrong Old Password.");
        }
    }
}
