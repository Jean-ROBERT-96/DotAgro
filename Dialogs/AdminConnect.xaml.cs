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

namespace DotAgro.Dialogs
{
    /// <summary>
    /// Logique d'interaction pour AdminConnect.xaml
    /// </summary>
    public partial class AdminConnect : Window
    {
        private readonly MainWindow _main;
        private bool _connected = false;

        private AdminConnect()
        {
            _main = (MainWindow)Application.Current.MainWindow;
            InitializeComponent();
        }

        public static new bool Show()
        {
            var instance = new AdminConnect();
            instance.ShowDialog();
            return instance._connected;
        }

        private void ValidButton_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(mailBox.Text) || !String.IsNullOrEmpty(passBox.Password))
            {
                _main.AdminContext.AdminConnection(mailBox.Text, passBox.Password);
                if (_main.AdminContext.AdminMode)
                    Close();
                else
                    MessageBox.Show("Identifiant ou mot de passe incorrect.", "Erreur de connexion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
                MessageBox.Show("Veuillez remplir les champs avant de continuer.", "Champs vide", MessageBoxButton.OK, MessageBoxImage.Stop);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
