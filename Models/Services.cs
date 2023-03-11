using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotAgro.entity
{
    public class Service
    {
        public int Id { get; init; }
        public string Name { get; set; }
        public ICollection<Salary> Salaries { get; set; } = new ObservableCollection<Salary>();
    }
}
