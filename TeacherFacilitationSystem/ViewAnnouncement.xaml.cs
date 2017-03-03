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
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BusinessLogicLayer;
using BusinessObjects;
namespace TeacherFacilitationSystem
{
    /// <summary>
    /// Interaction logic for ViewAnnouncement.xaml
    /// </summary>
    public partial class ViewAnnouncement : Window
    {
        private List<BusinessObjects.Announcement> list;
        public ViewAnnouncement()
        {
            InitializeComponent();
            GetData();
        }

        private void GetData()
        {
            StudentBll studentBll = new StudentBll();
            list = studentBll.GetAnnouncements();
            AnnouncementComboBox.DataContext = list;
            for (int i = 0; i < list.Count; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = list[i].Title;
                AnnouncementComboBox.Items.Add(item);
            }
        }

        private void Button_Click_ShowAnnouncement(object sender, RoutedEventArgs e)
        {
            ShowAnnouncementDetail show = null;
            string title = AnnouncementComboBox.Text;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Title == title)
                {
                    show = new ShowAnnouncementDetail(list[i].Comments);
                    break;

                }
            }
            if (show != null) show.Show();
        }
    }
}
