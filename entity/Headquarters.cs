using DotAgro.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotAgro.entity
{
    public class Headquarters
    {
        public int id_headquarter { get; init; }
        public string name { get; set; }

        public Headquarters(int id_headquarter, string name)
        {
            this.id_headquarter = id_headquarter;
            this.name = name;
        }
    }
}
