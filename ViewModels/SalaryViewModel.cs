using DotAgro.Interfaces;
using DotAgro.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotAgro.ViewModels
{
    public class SalaryViewModel : INotifyPropertyChanged
    {
        private readonly IDataManage<Salary> _dataManage;
        private ObservableCollection<Salary> _salariesList = new ObservableCollection<Salary>();

        public ObservableCollection<Salary> SalariesList
        {
            get => _salariesList;
            set
            {
                _salariesList = value;
                NotifyPropertyChanged(nameof(SalariesList));
            }
        }

        public SalaryViewModel(IDataManage<Salary> dataManage)
        {
            _dataManage = dataManage;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
