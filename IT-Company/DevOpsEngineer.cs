using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Company
{
    class DevOpsEngineer : Worker
    {

        public String position;
        public double salary;
        public int term;

        public DevOpsEngineer(String[] fullname, int age, String position, String typeOfProject, double salary, int term) : base(fullname, age, typeOfProject)
        {

            this.position = position;
            this.salary = salary;
            this.term = term;

        }
    }
}
