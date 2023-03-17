using DotAgro.Models;
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
    /// Logique d'interaction pour HeadquarterManager.xaml
    /// </summary>
    public partial class HeadquarterManager : Window
    {
        private readonly MainWindow _main;
        private Headquarters _currentItem;

        private HeadquarterManager(Headquarters item)
        {
            _currentItem = item;
            _main = (MainWindow)Application.Current.MainWindow;
            InitializeComponent();
        }

        public static new void Show(Headquarters item)
        {
            var instance = new HeadquarterManager(item);
            instance.ShowDialog();
        }

        private void VaildButton_Click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrEmpty(cityBox.Text))
            {
                _currentItem.City = cityBox.Text;
                _main.HeadquarterContext.EditValue(_currentItem);
                Close();
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
