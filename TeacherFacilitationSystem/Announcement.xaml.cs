using System.Windows;
using BusinessLogicLayer;

namespace TeacherFacilitationSystem
{
    /// <summary>
    /// Interaction logic for Announcement.xaml
    /// </summary>
    public partial class Announcement : Window
    {
        public Announcement()
        {
            InitializeComponent();
        }

        private void Button_PostAnnouncement(object sender, RoutedEventArgs e)
        {
            var announcement = new BusinessObjects.Announcement()
            {
                Title = TitleAnnouncemenTextBox.Text,
                Comments = CommentsTextBox.Text
            };

            var teacher = new TeacherBll();
            if (teacher.AddAnouncement(announcement))
            {
                MessageBox.Show("Announcement Added");
            }

        }
    }
}
