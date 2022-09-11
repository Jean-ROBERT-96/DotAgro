using DotAgro.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotAgro.entity
{
    internal class Headquarters : SalaryManageable
    {
        static int id_headquarter;
        public string name { get; set; }
        List<Salaryman> salaryList = new List<Salaryman>();

        public Headquarters(string name)
        {
            id_headquarter++;
            this.name = name;
        }

        public override void AddSalaryman(Salaryman s)
        {
            salaryList.Add(s);
        }

        public override void UpdateSalaryman(Salaryman s)
        {
            throw new NotImplementedException();
        }

        public override void DeleteSalaryman(Salaryman s)
        {
            salaryList.Remove(s);
        }

        public override void SearchSalaryman(Salaryman s)
        {
            throw new NotImplementedException();
        }
    }
}
