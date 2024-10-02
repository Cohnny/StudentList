using Microsoft.VisualBasic;
using System.Xml.Linq;

namespace Task6.Classes
{
    internal class Student
    {
        private string _name;
        public string Name
        {
            get { return _name; }
        }
        private int _birthDate;
        private string _course;
        public string Course
        {
            get { return _course; }
        }
        private int _grade;

        public Student(string name, int birthDate, string course, int grade)
        {
            _name = name;
            _birthDate = birthDate;
            _course = course;
            _grade = grade;
        }

        public override string ToString() 
        {
            return $"Name: {_name}, Grade: {_grade}, Course: {_course}";
        }
    }
}
