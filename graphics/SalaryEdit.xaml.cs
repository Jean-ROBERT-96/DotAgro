using DotAgro.entity;
using Microsoft.Win32;
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
    /// Logique d'interaction pour ManageSalary.xaml
    /// </summary>
    public partial class SalaryEdit : Window
    {
        MainWindow mainWindow;
        BitmapImage image;
        Salaryman salary;
        OpenFileDialog file;

        public SalaryEdit()
        {
            InitializeComponent();
            mainWindow = (MainWindow)Application.Current.MainWindow;
            ComboxInit();
        }

        public SalaryEdit(Salaryman salaryman)
        {
            InitializeComponent();
            mainWindow = (MainWindow)Application.Current.MainWindow;
            salary = salaryman;
            Add.Content = "Modifier";
            ComboxInit();
            Display();
        }

        void ComboxInit()
        {
            foreach(Headquarters head in mainWindow.headquartersList)
            {
                selectHeadquarters.Items.Add(new ComboBoxItem { Content = head.name, Tag = head.id_headquarter });
                if(salary != null && salary.id_headquarter == head.id_headquarter)
                {
                    selectHeadquarters.SelectedIndex = selectHeadquarters.Items.Count - 1;
                }
            }

            foreach(Services serv in mainWindow.servicesList)
            {
                selectServices.Items.Add(new ComboBoxItem { Content = serv.name, Tag = serv.id_service });
                if (salary != null && salary.id_service == serv.id_service)
                {
                    selectServices.SelectedIndex = selectServices.Items.Count - 1;
                }
            }

            if(salary == null)
            {
                selectHeadquarters.SelectedIndex = 0;
                selectServices.SelectedIndex = 0;
                genderSelect.SelectedIndex = 0;
            }
        }

        void Display()
        {
            image = new BitmapImage();
            firstName.Text = salary.firstName;
            lastName.Text = salary.lastName;
            if(salary.gender == 'M')
            {
                genderSelect.SelectedIndex = 0;
            }
            else if(salary.gender == 'F')
            {
                genderSelect.SelectedIndex = 1;
            }
            email.Text = salary.mail;
            phone.Text = salary.phone;
            mobilePhone.Text = salary.mobilePhone;
            image.BeginInit();
            image.UriSource = new Uri(salary.imageLink);
            image.EndInit();
            ViewImage.Source = image;
        }

        private void UploadFile_Click(object sender, RoutedEventArgs e)
        {
            file = new OpenFileDialog() { Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg" };
            if(file.ShowDialog() == true)
            {
                image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(file.FileName);
                image.EndInit();
                ViewImage.Source = image;
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
