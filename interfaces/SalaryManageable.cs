using DotAgro.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotAgro.interfaces
{
    abstract class SalaryManageable
    {
        public abstract void AddSalaryman(Salaryman s);
        public abstract void UpdateSalaryman(Salaryman s);
        public abstract void DeleteSalaryman(Salaryman s);
        public abstract void SearchSalaryman(Salaryman s);
    }
}
