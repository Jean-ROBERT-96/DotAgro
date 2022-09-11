using DotAgro.entity;
using DotAgro.graphics;
using DotAgro.interfaces;
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

namespace DotAgro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IDisplayable
    {
        public List<ProfileFrame> profileFrames { get; }
        

        public MainWindow()
        {
            InitializeComponent();
            Initialization();
        }

        public void Initialization()
        {
            //ProfileFrame frame = new ProfileFrame(new Salaryman("image", "Dautaj", "Albi", 'M', "0610101010", "aclain@cesi.fr"));
            //profileFrames.Add(new ProfileFrame(new Salaryman("image", "Dautaj", "Albi", 'M', "0610101010", "aclain@cesi.fr")));
            //ScreenSalary.Navigate(profileFrames[0]);
            ScreenSalary.Content = new ProfileFrame(new Salaryman("image", "Dautaj", "Albi", 'M', "0610101010", "aclain@cesi.fr"));
        }
    }
}
