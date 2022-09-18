using DotAgro.data;
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
    /// Logique d'interaction pour EditName.xaml
    /// </summary>
    public partial class EditName : Window
    {
        DataConnect data;
        string name;
        string type;
        ManagementEdit manage;

        public EditName(string type, string name)
        {
            this.type = type;
            this.name = name;
            InitializeComponent();
            data = new DataConnect();
            manage = (ManagementEdit)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
        }

        private void EditNamed_Click(object sender, RoutedEventArgs e)
        {
            if(nameEdit.Text != "")
            {
                data.EditManage(type, name, nameEdit.Text);
                Close();
                manage.Reload();
            }
            else
            {
                MessageBox.Show("Veuillez entrez un nouveau nom.", "Champs vide", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
