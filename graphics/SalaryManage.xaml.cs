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
    /// Logique d'interaction pour SalaryManage.xaml
    /// </summary>
    public partial class SalaryManage : Window
    {
        MainWindow mainWindow;
        BitmapImage image;
        DataAdmin data;
        Salaryman salaryman;

        public SalaryManage()
        {
            InitializeComponent();
            mainWindow = (MainWindow)Application.Current.MainWindow;
            image = new BitmapImage();
            data = new DataAdmin();
            Initialization();
        }

        public void Initialization()
        {
            foreach (Salaryman salary in mainWindow.salarymanList)
            {
                salarySelect.Items.Add(new ComboBoxItem { Content = $"{salary.firstName} {salary.lastName}", Tag = salary });
            }
            salarySelect.SelectedIndex = 0;
        }

        void Display(object sender, SelectionChangedEventArgs e)
        {
            
            if ((ComboBoxItem)salarySelect.SelectedItem == null)
            {
                salarySelect.SelectedIndex = 0;
            }

            if((ComboBoxItem)salarySelect.SelectedItem != null)
            {
                image = new BitmapImage();
                salaryman = (Salaryman)((ComboBoxItem)salarySelect.SelectedItem).Tag;

                firstName.Text = salaryman.firstName;
                lastName.Text = salaryman.lastName;
                if (salaryman.gender == 'M')
                {
                    gender.Text = "Homme";
                }
                else if (salaryman.gender == 'M')
                {
                    gender.Text = "Femme";
                }
                email.Text = salaryman.mail;
                image.BeginInit();
                image.UriSource = new Uri(salaryman.imageLink);
                image.EndInit();
                ViewImage.Source = image;
                phone.Text = salaryman.phone;
                mobilePhone.Text = salaryman.mobilePhone;
            }
            else
            {
                firstName.Text = "";
                lastName.Text = "";
                gender.Text = "";
                email.Text = "";
                ViewImage.Source = null;
                phone.Text = "";
                mobilePhone.Text = "";
            }
        }

        private void AddSalary_Click(object sender, RoutedEventArgs e)
        {
            SalaryEdit addSalary = new SalaryEdit();
            addSalary.Show();
        }

        private void EditSalary_Click(object sender, RoutedEventArgs e)
        {
            if(salaryman != null)
            {
                SalaryEdit editSalary = new SalaryEdit((Salaryman)((ComboBoxItem)salarySelect.SelectedItem).Tag);
                editSalary.Show();
            }
        }

        private void DeleteSalary_Click(object sender, RoutedEventArgs e)
        {
            if(salaryman != null)
            {
                var res = MessageBox.Show($"Voulez vous supprimer {salaryman.firstName} {salaryman.lastName}? Cette action sera irréversible.", "Supprimer le salarié", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (res == MessageBoxResult.Yes)
                {
                    data.DeleteSalary(salaryman.id_salary);
                    salarySelect.Items.Remove((ComboBoxItem)salarySelect.SelectedItem);
                    mainWindow.OnReload();
                }
            }
        }
    }
}
