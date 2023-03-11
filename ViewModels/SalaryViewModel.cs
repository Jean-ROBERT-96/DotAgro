using DotAgro.Interfaces;
using DotAgro.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DotAgro.ViewModels
{
    public class SalaryViewModel : INotifyPropertyChanged
    {
        private readonly IDataManage<Salary> _dataManage;
        private ObservableCollection<Salary> _salariesList = new();

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

        public void InitValue()
        {
            SalariesList.Clear();
            var result = _dataManage.GetData();

            if(result != null)
                SalariesList = result;

            NotifyPropertyChanged(nameof(SalariesList));
        }

        public void AddValue(Salary salary)
        {
            if(_dataManage.AddData(salary))
                MessageBox.Show("Le salarié a été ajouté.", "Ajout réussi", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("L'ajout du salarié a échoué.", "Echec de l'ajout", MessageBoxButton.OK, MessageBoxImage.Error);

            InitValue();
            NotifyPropertyChanged(nameof(SalariesList));
        }

        public void EditValue(Salary salary)
        {
            if(_dataManage.EditData(salary))
                MessageBox.Show("Le salarié a été modifié.", "Modification réussite", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("L'ajout du salarié a échoué.", "Echec de la modification", MessageBoxButton.OK, MessageBoxImage.Error);

            InitValue();
            NotifyPropertyChanged(nameof(SalariesList));
        }

        public void DeleteValue(Salary salary)
        {
            if(_dataManage.DeleteData(salary))
                MessageBox.Show("Le salarié a été supprimé.", "Suppression réussite", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("L'ajout du salarié a échoué.", "Echec de la supression", MessageBoxButton.OK, MessageBoxImage.Error);

            InitValue();
            NotifyPropertyChanged(nameof(SalariesList));
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
