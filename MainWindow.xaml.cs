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
        public void PreInitialization()
        {
            MySqlConnection connect = new MySqlConnection("server=localhost;database=dotagro;uid=root;pwd=\"\";");
            MySqlDataReader reader;
            MySqlCommand commandHeadquarters = new MySqlCommand("SELECT * FROM headquarters", connect);
            MySqlCommand commandServices = new MySqlCommand("SELECT * FROM services", connect);
            MySqlCommand commandSalaryman = new MySqlCommand("SELECT * FROM salaryman", connect);

            try
            {
                connect.Open();
                commandHeadquarters.Prepare();
                reader = commandHeadquarters.ExecuteReader();
                while(reader.Read())
                {
                    headquartersList.Add(new Headquarters(Convert.ToInt32(reader["id_headquarters"]), Convert.ToString(reader["name"])));
                }
                reader.Close();

                commandServices.Prepare();
                reader = commandServices.ExecuteReader();
                while (reader.Read())
                {
                    servicesList.Add(new Services(Convert.ToInt32(reader["id_services"]), Convert.ToString(reader["name"])));
                }
                reader.Close();

                commandSalaryman.Prepare();
                reader = commandSalaryman.ExecuteReader();
                while (reader.Read())
                {
                    profileFrames.Add(new ProfileFrame(new Salaryman(Convert.ToInt32(reader["id_salary"]), Convert.ToString(reader["image_link"]), Convert.ToString(reader["lastName"]), Convert.ToString(reader["firstName"]), Convert.ToChar(reader["gender"]), Convert.ToString(reader["mobile_phone"]), Convert.ToString(reader["mail"]), Convert.ToInt32(reader["id_headquarters"]), Convert.ToInt32(reader["id_services"]), Convert.ToString(reader["phone"])), headquartersList, servicesList));
                }
                reader.Close();
                connect.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show($"La connexion a échoué : {e}", "Erreur de connexion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Initialization()
        {
            PreInitialization();
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

        public static void Close()
        {
            Close();
        }
    }
}
