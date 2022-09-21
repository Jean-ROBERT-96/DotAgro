using DotAgro.entity;
using DotAgro.graphics;
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
    public partial class MainWindow : Window
    {
        DataConnect data;

        public List<Headquarters> headquartersList { get; set; }
        public List<Services> servicesList { get; set; }
        public List<Salaryman> salarymanList { get; set; }
        public List<ProfileFrame> profileFrames { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Initialization();
        }

        /// <summary>
        /// Initialisation des frames de la page d'accueil.
        /// </summary>
        public void Initialization()
        {
            data = new DataConnect();
            data.PreInitialization();
            
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

            if(SearchBox.Text == "" || SearchBox.Text == "Recherche par nom...")
            {
                searchProfile = profileFrames.Where(pf =>
                (pf.salary.id_headquarter.Equals(Convert.ToInt32(((ComboBoxItem)HeadquartersSelect.SelectedItem).Tag))) &&
                (pf.salary.id_service.Equals(Convert.ToInt32(((ComboBoxItem)ServicesSelect.SelectedItem).Tag)))).ToList();
            }
            else
            {
                searchProfile = profileFrames.Where(pf =>
                (pf.salary.lastName.Equals(SearchBox.Text, StringComparison.OrdinalIgnoreCase) || pf.salary.firstName.Equals(SearchBox.Text, StringComparison.OrdinalIgnoreCase)) &&
                (pf.salary.id_headquarter.Equals(Convert.ToInt32(((ComboBoxItem)HeadquartersSelect.SelectedItem).Tag))) &&
                (pf.salary.id_service.Equals(Convert.ToInt32(((ComboBoxItem)ServicesSelect.SelectedItem).Tag)))).ToList();
            }

            ScreenSalary.Children.Clear();
            foreach(ProfileFrame p in searchProfile)
            {
                ScreenSalary.Children.Add(new Frame() { Margin = new Thickness(2, 5, 2, 5), Height = 120, Width = 525, Content = p });
            }
        }

        private void Reload_Click(object sender, RoutedEventArgs e)
        {
            OnReload();
        }

        public void OnReload()
        {
            ScreenSalary.Children.Clear();
            profileFrames.Clear();
            HeadquartersSelect.Items.Clear();
            headquartersList.Clear();
            ServicesSelect.Items.Clear();
            servicesList.Clear();
            Initialization();
        }

        void AdminMode_KeyDown(object sender, KeyEventArgs e)
        {
            if(Keyboard.IsKeyDown(Key.L) && Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                Login admin = new Login();
                admin.Show();
            }
        }
        
        //Mode administrateur
        public void AdminSwitch()
        {
            ManageServices.Visibility = Visibility.Visible;
            ManageHeadquarters.Visibility = Visibility.Visible;
            ManageSalary.Visibility = Visibility.Visible;
        }

        void ManageServices_Click(object sender, RoutedEventArgs e)
        {
            ManagementEdit manage = new ManagementEdit("services");
            manage.Show();
        }

        void ManageHeadquarters_Click(object sender, RoutedEventArgs e)
        {
            ManagementEdit manage = new ManagementEdit("headquarters");
            manage.Show();
        }

        void ManageSalary_Click(object sender, RoutedEventArgs e)
        {
            SalaryManage salaryManage = new SalaryManage();
            salaryManage.Show();
        }
    }
}
