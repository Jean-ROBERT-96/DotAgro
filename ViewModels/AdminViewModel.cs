using DotAgro.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DotAgro.ViewModels
{
    public class AdminViewModel : BaseViewModels
    {
        private readonly IDataAdmin _dataManage;
        private bool _adminMode = false;

        public bool AdminMode
        {
            get => _adminMode;
            set
            {
                _adminMode = value;
                NotifyPropertyChanged(nameof(AdminMode));
            }
        }

        public AdminViewModel(IDataAdmin dataManage)
        {
            _dataManage = dataManage;
        }

        public void AdminConnection(string mail, string password)
        {
            if (_dataManage.AdminConnect(mail, password))
                AdminMode = true;
            else
                AdminMode = false;
        }
    }
}
