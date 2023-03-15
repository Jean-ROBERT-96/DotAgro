using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotAgro.Models
{
    public class Salary
    {
        public int Id { get; init; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Gender { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Image { get; set; }
        public int IdHeadquarter { get; set; }
        public int IdService { get; set; }
        public Headquarters IdHeadquarterNavigation { get; set; }
        public Services IdServiceNavigation { get; set; }
    }
}
