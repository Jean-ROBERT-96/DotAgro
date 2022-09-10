using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotAgro.entity
{
    internal class Salaryman
    {
        int id;
        public string lastName { get; set; }
        public string firstName { get; set; }
        public char gender { get; set; }
        public string phone { get; set; }
        public string mobilePhone { get; set; }
        public string mail { get; set; }
        public Services service { get; set; }
        public Headquarters headquarter { get; set; }

        public Salaryman(int id, string lastName, string firstName, char gender, string mobilePhone, string mail, Services service, Headquarters headquarter, string phone = null)
        {
            this.id = id;
            this.lastName = lastName;
            this.firstName = firstName;
            this.gender = gender;
            this.mobilePhone = mobilePhone;
            this.mail = mail;
            this.service = service;
            this.headquarter = headquarter;
            this.phone = phone;
        }
    }
}
