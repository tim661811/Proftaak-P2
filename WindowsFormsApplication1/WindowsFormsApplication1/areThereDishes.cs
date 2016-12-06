using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class areThereDishes
    {
        private bool areThere;
        private List<dishes> dishes = new List<dishes>();


       

        public bool readMessageArduino()
        {
            if (message == "er is vaat")
            {
                return areThere = true;


            }
            else if (message == "er is geen vaat")
            {
                return areThere = false;
            }
        }
    }
}
