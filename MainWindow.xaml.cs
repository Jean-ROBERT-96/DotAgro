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

namespace DotAgro
{
    public partial class MainWindow : Window
    {
        public SalaryViewModel SalaryContext { get; set; }
        public ServiceViewModel ServiceContext { get; set; }
        public HeadquarterViewModel HeadquarterContext { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
