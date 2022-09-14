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
using MySql.Data.MySqlClient;
using DotAgro.data;

namespace DotAgro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataConnect data;

        public MainWindow()
        {
            InitializeComponent();
            Initialization();
        }

        public void Initialization()
        {
            data = new DataConnect();
            data.PreInitialization();
            
            foreach (ProfileFrame p in data.profileFrames)
            {
                ScreenSalary.Children.Add(new Frame() {Margin = new Thickness(2, 5, 2, 5), Height = 120, Width = 525, Content = p });
            }

            foreach(Headquarters h in data.headquartersList)
            {
                HeadquartersSelect.Items.Add(new ComboBoxItem { Content = h.name, Tag = h.id_headquarter });
            }
            HeadquartersSelect.SelectedIndex = 0;

            foreach(Services s in data.servicesList)
            {
                ServicesSelect.Items.Add(new ComboBoxItem { Content = s.name, Tag = s.id_service });
            }
            ServicesSelect.SelectedIndex = 0;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var searchProfile = new List<ProfileFrame>();
            searchProfile = data.profileFrames.Where(pf => 
            (pf.salary.lastName.Equals(SearchBox.Text, StringComparison.OrdinalIgnoreCase)) &&
            (pf.salary.id_headquarter.Equals(Convert.ToInt32(((ComboBoxItem)HeadquartersSelect.SelectedItem).Tag))) &&
            (pf.salary.id_service.Equals(Convert.ToInt32(((ComboBoxItem)ServicesSelect.SelectedItem).Tag)))).ToList();

            ScreenSalary.Children.Clear();
            foreach(ProfileFrame p in searchProfile)
            {
                ScreenSalary.Children.Add(new Frame() { Margin = new Thickness(2, 5, 2, 5), Height = 120, Width = 525, Content = p });
            }
        }

        private void Reload_Click(object sender, RoutedEventArgs e)
        {
            ScreenSalary.Children.Clear();
            data.profileFrames.Clear();
            data.headquartersList.Clear();
            data.servicesList.Clear();
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
