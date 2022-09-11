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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DotAgro.graphics
{
    /// <summary>
    /// Logique d'interaction pour ProfileFrame.xaml
    /// </summary>
    public partial class ProfileFrame : Page
    {
        Salaryman salary;
        BitmapImage image;

        public ProfileFrame(Salaryman s)
        {
            InitializeComponent();
            salary = s;
            image = new BitmapImage();
            Display();
        }

        void Display()
        {
            name.Text = $"{salary.firstName} {salary.lastName}";
            email.Text = salary.mail;
            phone.Text = salary.mobilePhone;

            if(salary.gender == 'M')
            {
                gender.Text = "Homme";
            }
            else if(salary.gender == 'M')
            {
                gender.Text ="Femme";
            }
            image.BeginInit();
            image.UriSource = new Uri(salary.imageLink);
            image.EndInit();

            imageBox.Source = image;
        }

        public void SetSalary(Salaryman s)
        {
            salary = s;
        }
    }
}
