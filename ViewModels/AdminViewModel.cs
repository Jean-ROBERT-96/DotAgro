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

        public AdminViewModel(IDataAdmin dataManage)
        {
            _dataManage = dataManage;
        }

        public bool AdminConnection(string mail, string password)
        {
            if (_dataManage.AdminConnect(mail, password))
            {
                return true;
            }
            else
                return false;
        }
    }
}
