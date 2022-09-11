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
    public partial class MainWindow : Window
    {
        List<ProfileFrame> profileFrames;
        List<Frame> newFrame;

        public MainWindow()
        {
            InitializeComponent();
            profileFrames = new List<ProfileFrame>();
            newFrame = new List<Frame>();
            Initialization();
        }

        public void Initialization()
        {
            profileFrames.Add(new ProfileFrame(new Salaryman("https://tiermaker.com/images/templates/overwatch-2-designs-486615/4866151626673279.png", "Dautaj", "Albi", 'M', "0610101010", "aclain@cesi.fr")));
            profileFrames.Add(new ProfileFrame(new Salaryman("https://jf-staeulalia.pt/img/other/76/collection-epic-face-background-18.png", "Normand", "Théo", 'M', "0610101010", "aclain@cesi.fr")));
            profileFrames.Add(new ProfileFrame(new Salaryman("https://jf-staeulalia.pt/img/other/76/collection-epic-face-background-18.png", "Robert", "Jean", 'M', "0610101010", "aclain@cesi.fr")));

            foreach(ProfileFrame p in profileFrames)
            {
                ScreenSalary.Children.Add(new Frame() {Margin = new Thickness(2, 5, 2, 5), Height = 120, Width = 525, Content = p });
            }
        }
    }
}
