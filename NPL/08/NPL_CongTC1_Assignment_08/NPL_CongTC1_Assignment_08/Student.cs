using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPL_CongTC1_Assignment_08
{
    class Student
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public string Gender { get; set; }
        public string Relationship { get; set; }
        public DateTime EntryDate { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public decimal Mark { get; set; }
        public string Grade { get; set; }

        public Student()
        {
                
        }

        public Student(string name, string @class, string gender, DateTime entryDate, int age, string address, string relationship = "Single", decimal mark = 0, string grade ="F")
        {
            Name = name;
            Class = @class;
            Gender = gender;
            Relationship = relationship;
            EntryDate = entryDate;
            Age = age;
            Address = address;
            Mark = mark;
            Grade = grade;
        }

        public string Graduate(float gradePoint = 0)
        {
            if (gradePoint > 4 || gradePoint < 0)
            {
                throw new ArgumentException("Grade point input: 0->4");
            }
            else if (gradePoint == 4.0) return "A";
            else if (gradePoint >= 3.7) return "A-";
            else if (gradePoint >= 3.3) return "B+";
            else if (gradePoint >= 3.0) return "B";
            else if (gradePoint >= 2.7) return "B-";
            else if (gradePoint >= 2.3) return "C+";
            else if (gradePoint >= 2.0) return "C";
            else if (gradePoint >= 1.0) return "D";
            return "F";
          
        }

        public string Graduate()
        {
            var mark = this.Mark;
            if (mark > 100 || mark < 0) throw new ArgumentException("Mark input: 0->100");
            else if (mark >= 85 && mark <= 100) return "A";
            else if (mark >= 80) return "A-";
            else if (mark >= 75) return "B+";
            else if (mark >= 70) return "B";
            else if (mark >= 65) return "B-";
            else if (mark >= 60) return "C+";
            else if (mark >= 55) return "C";
            else if (mark >= 50) return "D";
            return "F";
        }

        public string toString(string name, string @class, string gender, string relationship, int age, string grade)
        {
            return string.Format("{0,-20}{1,-10}{2,-10}{3,-20}{4,-10}{5,-10}", name, @class, gender, relationship, age, grade);
        }

        public string toString()
        {
            return string.Format("{0,-20}{1,-10}{2,-10}{3,-20}{4,-10}{5,-10}", this.Name, this.Class, this.Gender, this.Relationship, this.Age, this.Grade);
        }
    }
}
