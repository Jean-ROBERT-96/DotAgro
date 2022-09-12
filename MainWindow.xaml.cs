using DotAgro.entity;
using DotAgro.graphics;
using DotAgro.interfaces;
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

namespace DotAgro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<ProfileFrame> profileFrames;
        List<Headquarters> headquartersList;
        List<Services> servicesList;

        public MainWindow()
        {
            InitializeComponent();
            profileFrames = new List<ProfileFrame>();
            headquartersList = new List<Headquarters>();
            servicesList = new List<Services>();
            Initialization();
        }

        public void Initialization()
        {
            
            headquartersList.Add(new Headquarters(1, "Bordeaux"));
            headquartersList.Add(new Headquarters(2, "Toulouse"));
            headquartersList.Add(new Headquarters(3, "Lyon"));
            servicesList.Add(new Services(1, "Informatique"));
            servicesList.Add(new Services(2, "Comptabilité"));
            servicesList.Add(new Services(3, "Direction"));
            profileFrames.Add(new ProfileFrame(new Salaryman("https://tiermaker.com/images/templates/overwatch-2-designs-486615/4866151626673279.png", "Dautaj", "Albi", 'M', "0610101010", "aclain@cesi.fr", 2, 2), headquartersList, servicesList));
            profileFrames.Add(new ProfileFrame(new Salaryman("https://jf-staeulalia.pt/img/other/76/collection-epic-face-background-18.png", "Normand", "Théo", 'M', "0610101010", "aclain@cesi.fr", 1, 1), headquartersList, servicesList));
            profileFrames.Add(new ProfileFrame(new Salaryman("https://jf-staeulalia.pt/img/other/76/collection-epic-face-background-18.png", "Robert", "Jean", 'M', "0610101010", "aclain@cesi.fr", 3, 2), headquartersList, servicesList));

            foreach (ProfileFrame p in profileFrames)
            {
                ScreenSalary.Children.Add(new Frame() {Margin = new Thickness(2, 5, 2, 5), Height = 120, Width = 525, Content = p });
            }

            foreach(Headquarters h in headquartersList)
            {
                HeadquartersSelect.Items.Add(new ComboBoxItem { Content = h.name, Tag = h.id_headquarter });
            }
            HeadquartersSelect.SelectedIndex = 0;

            foreach(Services s in servicesList)
            {
                ServicesSelect.Items.Add(new ComboBoxItem { Content = s.name, Tag = s.id_service });
            }
            ServicesSelect.SelectedIndex = 0;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var searchProfile = new List<ProfileFrame>();
            searchProfile = profileFrames.Where(pf => 
            (pf.salary.lastName.Equals(SearchBox.Text, StringComparison.OrdinalIgnoreCase)) ||
            (pf.salary.id_headquarter.Equals(int.Parse(((ComboBoxItem)HeadquartersSelect.SelectedItem).Tag.ToString()))) &&
            (pf.salary.id_service.Equals(int.Parse(((ComboBoxItem)ServicesSelect.SelectedItem).Tag.ToString())))).ToList();

            ScreenSalary.Children.Clear();
            foreach(ProfileFrame p in searchProfile)
            {
                ScreenSalary.Children.Add(new Frame() { Margin = new Thickness(2, 5, 2, 5), Height = 120, Width = 525, Content = p });
            }
        }

        private void Reload_Click(object sender, RoutedEventArgs e)
        {
            ScreenSalary.Children.Clear();
            profileFrames.Clear();
            headquartersList.Clear();
            servicesList.Clear();
            Initialization();
        }

        void AdminMode_KeyDown(object sender, KeyEventArgs e)
        {
            if(Keyboard.IsKeyDown(Key.F8) && Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                Login admin = new Login();
                admin.Show();
            }
        }
    }
}
