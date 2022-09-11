using DotAgro.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotAgro.entity
{
    internal class Services : SalaryManageable
    {
        static int id_service;
        public string name { get; set; }
        List<Salaryman> salaryList = new List<Salaryman>();

        public Services(string name)
        {
            id_service++;
            this.name = name;
        }

        public override void AddSalaryman(Salaryman s)
        {
            salaryList.Add(s);
        }

        public override void UpdateSalaryman(Salaryman s)
        {
            salaryList.Remove(s);
            salaryList.Add(s);
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
