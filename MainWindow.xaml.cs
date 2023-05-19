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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Learn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            learnContext db = Helper.GetContext();
            string defImage = "Resources/picture.png";
            var res = from s in db.Services
                      select new
                      {
                          Title = s.Title,
                          Logo = s.MainImagePath == "" ? defImage : "/Resources/" + s.MainImagePath,
                          Description = (int) s.Cost + " рублей  за " + s.DurationInSeconds/60 +" минут"
                      };


            listViewDB.ItemsSource = res.ToList();
            SortCB.SelectedIndex = 0;
            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateData();
        }

        void UpdateData()
        {
            string defImage = "Resources/picture.png";
            learnContext db = Helper.GetContext();
            var services = db.Services.ToList();
            services = services.Where(x => x.Title.Contains(SearchTB.Text ?? "")).ToList();
            services = SortCB.SelectedIndex switch
            {
                0 => services.ToList(),
                1 => services.OrderBy(x => x.Cost).ToList(),
                2 => services.OrderByDescending(x => x.Cost).ToList(),
                _ => services

            };
            var res = from s in services
                      select new
                      {
                          Title = s.Title,
                          Logo = s.MainImagePath == "" ? defImage : "/Resources/" + s.MainImagePath,
                          Description = (int)s.Cost + " рублей  за " + s.DurationInSeconds / 60 + " минут"
                      };

            listViewDB.ItemsSource = res;


        }

        private void SortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }
    }
}
