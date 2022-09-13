using DotAgro.graphics;
using MySql.Data.MySqlClient;
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

namespace DotAgro
{
    /// <summary>
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        MySqlConnection connect;
        MySqlCommand command;
        MySqlDataReader reader;

        public Login()
        {
            InitializeComponent();
        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            string id = user.Text;
            string pwd = password.Password;
            

            connect = new MySqlConnection("server=localhost;database=admindotagro;uid=root;pwd=\"\";");
            command = new MySqlCommand("SELECT * FROM administrateur", connect);
            
            try
            {
                connect.Open();
                command.Prepare();
                reader = command.ExecuteReader();
                bool isConnect = false;
                while (reader.Read())
                {
                    if (Convert.ToString(reader["userid"]) == id && Convert.ToString(reader["pass"]) == pwd)
                    {
                        isConnect = true;
                        Admin admin = new Admin();
                        admin.Show();
                        Close();

                        reader.Close();
                        connect.Close();
                        return;
                    }
                }
                MessageBox.Show("L'utilisateur et/ou le mot de passe est incorrect.", "Erreur d'authentification", MessageBoxButton.OK, MessageBoxImage.Warning);

                reader.Close();
                connect.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Erreur de connexion : {ex}", "Erreur de connexion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
