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
    public class ServiceViewModel : INotifyPropertyChanged
    {
        private readonly IDataManage<Models.Services> _dataManage;
        private ObservableCollection<Models.Services> _servicesList = new();

        public ObservableCollection<Models.Services> ServicesList
        {
            get => _servicesList;
            set
            {
                _servicesList = value;
                NotifyPropertyChanged(nameof(ServicesList));
            }
        }

        public ServiceViewModel(IDataManage<Models.Services> dataManage)
        {
            _dataManage = dataManage;
        }

        public void InitValue()
        {
            ServicesList.Clear();
            var result = _dataManage.GetData();

            if (result != null)
                ServicesList = result;

            NotifyPropertyChanged(nameof(ServicesList));
        }

        public void AddValue(Models.Services service)
        {
            if (_dataManage.AddData(service))
                MessageBox.Show("Le service a été ajouté.", "Ajout réussi", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("L'ajout du service a échoué.", "Echec de l'ajout", MessageBoxButton.OK, MessageBoxImage.Error);

            InitValue();
            NotifyPropertyChanged(nameof(ServicesList));
        }

        public void EditValue(Models.Services service)
        {
            if (_dataManage.EditData(service))
                MessageBox.Show("Le service a été modifié.", "Modification réussite", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("L'ajout du service a échoué.", "Echec de la modification", MessageBoxButton.OK, MessageBoxImage.Error);

            InitValue();
            NotifyPropertyChanged(nameof(ServicesList));
        }

        public void DeleteValue(Models.Services service)
        {
            if (_dataManage.DeleteData(service))
                MessageBox.Show("Le service a été supprimé.", "Suppression réussite", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("L'ajout du service a échoué.", "Echec de la supression", MessageBoxButton.OK, MessageBoxImage.Error);

            InitValue();
            NotifyPropertyChanged(nameof(ServicesList));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
