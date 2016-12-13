using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class loginclass
    {

        private List<users> userlist = new List<users>();

        public bool passCorrect(users selectedUser)
        {
            return false;
        }
        public void addUserToList(users toAdd)
        {
            userlist.Add(toAdd);
        }
    }
}
