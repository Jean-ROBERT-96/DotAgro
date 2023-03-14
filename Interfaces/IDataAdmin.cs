using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotAgro.Interfaces
{
    public interface IDataAdmin
    {
        bool AdminConnect(string mail,  string password);
    }
}
