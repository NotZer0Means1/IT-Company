using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Company
{
    class SoftwareEngineer : Worker
    {  // добавить скиллы к каждому классу, например знание япов и т.д

        public String position;
        public double salary;
        public int term;

        public SoftwareEngineer(String[] fullname, int age, String position, String typeOfProject, double salary, int term) : base(fullname, age, typeOfProject)
        {

            this.position = position;
            this.salary = salary;
            this.term = term;

        }
    }
}
