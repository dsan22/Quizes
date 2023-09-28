using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Exceptions
{
    internal class UsernameAlreadyTakenException:Exception
    {
        public UsernameAlreadyTakenException(string username):base("Useraname '"+username+"' already taken") { }
    }
}
