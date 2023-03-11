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
    public class HeadquarterViewModel : INotifyPropertyChanged
    {
        private readonly IDataManage<Headquarters> _dataManage;
        private ObservableCollection<Headquarters> _headquartersList = new();

        public ObservableCollection<Headquarters> HeadquartersList
        {
            get => _headquartersList;
            set
            {
                _headquartersList = value;
                NotifyPropertyChanged(nameof(HeadquartersList));
            }
        }

        public HeadquarterViewModel(IDataManage<Headquarters> dataManage)
        {
            _dataManage = dataManage;
        }

        public void InitValue()
        {
            HeadquartersList.Clear();
            var result = _dataManage.GetData();

            if (result != null)
                HeadquartersList = result;

            NotifyPropertyChanged(nameof(HeadquartersList));
        }

        public void AddValue(Headquarters headquarter)
        {
            if (_dataManage.AddData(headquarter))
                MessageBox.Show("Le siège a été ajouté.", "Ajout réussi", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("L'ajout du siège a échoué.", "Echec de l'ajout", MessageBoxButton.OK, MessageBoxImage.Error);

            InitValue();
            NotifyPropertyChanged(nameof(HeadquartersList));
        }

        public void EditValue(Headquarters headquarter)
        {
            if (_dataManage.EditData(headquarter))
                MessageBox.Show("Le siège a été modifié.", "Modification réussite", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("L'ajout du siège a échoué.", "Echec de la modification", MessageBoxButton.OK, MessageBoxImage.Error);

            InitValue();
            NotifyPropertyChanged(nameof(HeadquartersList));
        }

        public void DeleteValue(Headquarters headquarter)
        {
            if (_dataManage.DeleteData(headquarter))
                MessageBox.Show("Le siège a été supprimé.", "Suppression réussite", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("L'ajout du siège a échoué.", "Echec de la supression", MessageBoxButton.OK, MessageBoxImage.Error);

            InitValue();
            NotifyPropertyChanged(nameof(HeadquartersList));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
