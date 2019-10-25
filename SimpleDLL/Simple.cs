using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDLL
{
    public class Simple
    {
        public string SayHello(string name) {
            return "สวัดดีคุณ " + name; 
        }
        public Student GetStudent() {
            Student student = new Student();
            student.Name = "Natthawut Chipimol";
            student.ID = "123456";
            student.Gpa = 3.99;
            return student;
        }
    }
    public class Student {
        public string Name { get; set; }
        public string ID { get; set; }
        public Double Gpa { get; set; }

        public override string ToString()
        {
            return "Name: "+Name+" ID: "+ID+" GPA "+ Gpa;
        }
    }
}
