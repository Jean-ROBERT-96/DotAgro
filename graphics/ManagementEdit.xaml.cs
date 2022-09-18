using DotAgro.data;
using DotAgro.entity;
using MySqlX.XDevAPI.Common;
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

namespace DotAgro.graphics
{
    /// <summary>
    /// Logique d'interaction pour ManagementEdit.xaml
    /// </summary>
    public partial class ManagementEdit : Window
    {
        DataAdmin data;
        MainWindow mainWindow;
        string parametre;
        public List<ManageFrame> manageFrame { get; set; }

        public ManagementEdit(string parametre)
        {
            InitializeComponent();
            this.parametre = parametre;
            mainWindow = (MainWindow)Application.Current.MainWindow;
            Initialization();
        }

        void Initialization()
        {
            data = new DataAdmin();
            manageFrame = data.PreInitManage(parametre);
            foreach(ManageFrame m in manageFrame)
            {
                ScreenManage.Children.Add(new Frame() { Margin = new Thickness(2, 5, 2, 5), Height = 50, Width = 380, Content = m });
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if(manageText.Text == "")
            {
                MessageBox.Show("Ajoutez un nom pour continuer.", "Ajout d'élément", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            var res = MessageBox.Show($"Voulez vous ajouter {manageText.Text} à la liste?", "Ajout d'élément", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(res == MessageBoxResult.Yes)
            {
                data.AddManage(parametre, manageText.Text);
                Reload();
            }
            manageText.Text = "";
        }

        public void Reload()
        {
            ScreenManage.Children.Clear();
            manageFrame.Clear();
            mainWindow.OnReload();
            Initialization();
        }
    }
}
