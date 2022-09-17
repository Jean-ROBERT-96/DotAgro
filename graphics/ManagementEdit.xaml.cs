using DotAgro.data;
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
    /// Logique d'interaction pour ManagementEdit.xaml
    /// </summary>
    public partial class ManagementEdit : Window
    {
        DataConnect data;
        string parametre;

        public ManagementEdit(string parametre)
        {
            InitializeComponent();
            this.parametre = parametre;
            Initialization();
        }

        void Initialization()
        {
            data = new DataConnect();
            data.PreInitManage(parametre);
            foreach(ManageFrame m in data.manageFrame)
            {
                ScreenManage.Children.Add(new Frame() { Margin = new Thickness(2, 5, 2, 5), Height = 50, Width = 380, Content = m });
            }
        }
    }
}
