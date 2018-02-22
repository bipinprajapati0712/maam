using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentmgmt_BO
{
  public  class Student
    {
        private int id;
        private string name;
        private string city;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string City
        {
            get
            {
                return city;
            }

            set
            {
                city = value;
            }
        }
        public Student()
        {

        }


        public Student(string sname,string scity)

        {
           // sname = name;
            name = sname;
            city = scity;
        }
    }
}
