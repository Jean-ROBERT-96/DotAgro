using DotAgro.data;
using DotAgro.entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DotAgro.graphics
{
    /// <summary>
    /// Logique d'interaction pour ManageFrame.xaml
    /// </summary>
    public partial class ManageFrame : Page
    {
        public Headquarters headquarters { get; }
        public Services services { get; }
        DataConnect data;
        List<Salaryman> salary;
        MainWindow mainWindow;
        ManagementEdit manage;

        public ManageFrame(List<Salaryman> salary, Headquarters h)
        {
            InitializeComponent();
            headquarters = h;
            this.salary = salary.Where(sa => sa.id_headquarter == h.id_headquarter).ToList();
            mainWindow = (MainWindow)Application.Current.MainWindow;
            manage = Application.Current.Windows.OfType<ManagementEdit>().LastOrDefault(x => x.IsActive);
            Display();
        }

        public ManageFrame(List<Salaryman> salary, Services s)
        {
            InitializeComponent();
            services = s;
            this.salary = salary.Where(sa => sa.id_service == s.id_service).ToList();
            mainWindow = (MainWindow)Application.Current.MainWindow;
            manage = Application.Current.Windows.OfType<ManagementEdit>().LastOrDefault(x => x.IsActive);
            Display();
        }

        void Display()
        {
            if(headquarters != null)
            {
                infoManage.Text = $"{headquarters.name} - {salary.Count} Attaché(s)";
            }

            if(services != null)
            {
                infoManage.Text = $"{services.name} - {salary.Count} Attaché(s)";
            }
        }

        private void EditManage_Click(object sender, RoutedEventArgs e)
        {
            if(headquarters != null)
            {
                EditName edit = new EditName("headquarters", headquarters.name);
                edit.Show();
            }
            else if(services != null)
            {
                EditName edit = new EditName("services", services.name);
                edit.Show();
            }
        }

        private void DeleteManage_Click(object sender, RoutedEventArgs e)
        {
            data = new DataConnect();

            if (salary.Count != 0)
            {
                MessageBox.Show("Erreur, des personnes sont encores affiliés.", "Erreur de supression", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var result = MessageBox.Show($"Voulez vous supprimer {infoManage.Text}? Cette action sera irréversible.", $"Suppresion de {infoManage.Text}", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            
            if (result == MessageBoxResult.Yes && headquarters != null)
            {
                data.DeleteManage(headquarters.id_headquarter, "headquarters");
                manage.Reload();
            }
            else if(result == MessageBoxResult.Yes && services != null)
            {
                data.DeleteManage(services.id_service, "services");
                manage.Reload();
            }
        }
    }
}
