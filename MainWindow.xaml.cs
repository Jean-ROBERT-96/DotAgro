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
using System.Collections.ObjectModel;
using DotAgro.ViewModels;
using DotAgro.Interfaces;
using DotAgro.Models;
using DotAgro.Dialogs;

namespace DotAgro
{
    public partial class MainWindow : Window
    {
        public bool AdminMode = false;

        public static RoutedCommand AdminCommand = new();

        public SalaryViewModel SalaryContext { get; set; }
        public ServiceViewModel ServiceContext { get; set; }
        public HeadquarterViewModel HeadquarterContext { get; set; }
        public AdminViewModel AdminContext { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        public void ContextLoaded()
        {
            gridView.ItemsSource = SalaryContext?.SalariesList;
            headSearchCombo.ItemsSource = HeadquarterContext?.HeadquartersList;
            servSearchCombo.ItemsSource = ServiceContext?.ServicesList;
        }

        private void AdminMode_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if(!AdminMode)
                AdminMode = AdminConnect.Show();
            else
            {
                if (MessageBox.Show("Voullez-vous vous déconnecter?", "Déconnexion", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    AdminMode = false;
            }
        }
    }
}
