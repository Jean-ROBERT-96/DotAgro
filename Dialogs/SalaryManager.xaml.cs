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
    /// Logique d'interaction pour SalaryManager.xaml
    /// </summary>
    public partial class SalaryManager : Window
    {
        private readonly MainWindow main;
        private Salary context = new();
        private int mode;

        private SalaryManager(Salary? salary = null)
        {
            main = (MainWindow)Application.Current.MainWindow;
            mode = 0;
            if (salary != null)
            {
                context = salary;
                mode = 1;
            }

            InitializeComponent();
            DataContext = context;
            headquarterCombo.ItemsSource = main.HeadquarterContext.HeadquartersList;
            serviceCombo.ItemsSource = main.ServiceContext.ServicesList;
        }

        public static void Show(Salary? salary = null)
        {
            var instance = salary switch
            {
                null => new SalaryManager(),
                not null => new SalaryManager(salary)
            };

            instance.ShowDialog();
        }

        private void Valid(object sender, RoutedEventArgs e)
        {
            context.Id = context.Id;
            context.LastName = lastnameBox.Text;
            context.FirstName = firstnameBox.Text;
            context.Gender = (string)((ComboBoxItem)genderBox.SelectedValue).Tag;
            context.Mail = mailBox.Text;
            context.Phone = phoneBox.Text;
            context.IdHeadquarter = ((Headquarters)headquarterCombo.SelectedItem).Id;
            context.IdService = ((Models.Services)serviceCombo.SelectedItem).Id;
            //context.IdHeadquarterNavigation = main.HeadquarterContext.HeadquartersList.Where(x => x.Id.Equals(context.IdHeadquarter)).First();
            //context.IdServiceNavigation = main.ServiceContext.ServicesList.Where(x => x.Id.Equals(context.IdService)).First();
            //context.IdServiceNavigation.Salaries.Add(context);
            //context.IdHeadquarterNavigation.Salaries.Add(context);

            if(mode == 0)
                main.SalaryContext.AddValue(context);
            else
                main.SalaryContext.EditValue(context);
            //Close();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
