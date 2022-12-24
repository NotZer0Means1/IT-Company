using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Company
{
    public class Client {

        public String[] fullname;
        public String order;
        public double capital;

        public Client(String[] fullname, String order, double capital) { 
        
            this.fullname = fullname;
            this.order = order;
            this.capital = capital;
        
        }

    }
}
