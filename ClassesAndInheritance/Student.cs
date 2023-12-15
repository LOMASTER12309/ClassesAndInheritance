using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    public class Student : Person
    {
        int course = 1;
        Teacher teacher;
        static public Student[] StudentMas = new Student[] { new Student("Паша", 20, 2), new Student("Маша", 21, 4),
                                                             new Student("Юра", 20, 3), new Student("Илья", 19, 1),
                                                             new Student("Оля", 19, 2), new Student("Миша", 21, 3)};
        public static Student RandomStudent(Random rnd = null)
        {
            if (rnd != null)
                return StudentMas[rnd.Next(StudentMas.Length)];
            else return StudentMas[(new Random()).Next(StudentMas.Length)].Clone();
        }
        public int Course
        {
            get { return course; }
            set
            {
                if ((value < 1) || (value > 5)) course = 1;
                else course = value;
            }
        }

        public Teacher CurrentTeacher
        {
            get { return teacher; }
            set { teacher = value; }
        }
        public Student() : base()
        {
            Course = 1;
            teacher = null;
        }
        public Student(string name, int age, int course, Teacher teacher = null) : base(name, age)
        {
            Course = course;
            CurrentTeacher = teacher;
        }
        public override void Print()
        {
            base.Print();
            Console.Write($"Курс: {Course}; Препод: ");
            if (teacher == null) Console.WriteLine("Отсутствует");
            else Console.WriteLine(teacher);
        }
        public override Student Clone()
        {
            if (teacher == null)
                return new Student(Name, Age, Course, null);
            Teacher TeacherClone = teacher.Clone();
            foreach (var stud in TeacherClone.Students)
                if (this.Equals(stud)) return stud;
            return new Student(Name, Age, Course, TeacherClone);
        }
        public override string ToString()
        {
            return base.ToString();
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Student)) return false;
            else
            {
                Student stud = (Student)obj;
                if ((stud.Name == Name) && (stud.Age == Age) && (stud.Course == Course))
                    if (teacher == null)
                        if (stud.CurrentTeacher == null) return true;
                        else return false;
                    else if (stud.CurrentTeacher == null) return false;
                    else return teacher.Equals(stud.CurrentTeacher);
            }
            return false;
        }
        public override int GetHashCode()
        {
            int sum = base.GetHashCode() + course.GetHashCode();
            if (teacher != null)
                sum += teacher.GetHashCode();
            return sum;
        }

        public static void Ancestors()
        {
            PrintAncestors(typeof(Student));
            Console.WriteLine(typeof(object).Name);
        }
        static void PrintAncestors(Type type)
        {
            Console.WriteLine(type.Name);

            // Рекурсивно вызываем для предка предка, пока не достигнем базового класса (object)
            if (type.BaseType != null && type.BaseType != typeof(object))
            {
                PrintAncestors(type.BaseType);
            }
        }
    }
}
