using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApplication.Infra.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        protected Student()
        { }

        public Student(int id,string name)
        {
            Id = id;
            Name = name;
        }
    }
}
