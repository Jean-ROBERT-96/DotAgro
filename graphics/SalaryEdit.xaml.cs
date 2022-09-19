using DotAgro.entity;
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
        Salaryman salary;

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
            ComboxInit();
            Display();
        }

        void ComboxInit()
        {
            foreach(Headquarters head in mainWindow.headquartersList)
            {
                selectHeadquarters.Items.Add(new ComboBoxItem { Content = head.name, Tag = head.id_headquarter });
            }
            selectHeadquarters.SelectedIndex = 0;

            foreach (Services serv in mainWindow.servicesList)
            {
                selectServices.Items.Add(new ComboBoxItem { Content = serv.name, Tag = serv.id_service });
            }
            selectServices.SelectedIndex = 0;
        }

        void Display()
        {
            firstName.Text = salary.firstName;
            lastName.Text = salary.lastName;

            email.Text = salary.mail;
            phone.Text = salary.phone;
            mobilePhone.Text = salary.mobilePhone;
        }
    }
}
