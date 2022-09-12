using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotAgro.entity
{
    public class Salaryman
    {
        static int id_salary;
        public string imageLink { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public char gender { get; set; }
        public string phone { get; set; }
        public string mobilePhone { get; set; }
        public string mail { get; set; }
        public int id_headquarter { get; set; }
        public int id_service { get; set; }

        public Salaryman(string imageLink, string lastName, string firstName, char gender, string mobilePhone, string mail, int id_headquarter, int id_service, string phone = null)
        {
            id_salary++;
            this.imageLink = imageLink;
            this.lastName = lastName;
            this.firstName = firstName;
            this.gender = gender;
            this.mobilePhone = mobilePhone;
            this.mail = mail;
            this.id_headquarter = id_headquarter;
            this.id_service = id_service;
            this.phone = phone;
        }
    }
}
