using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    public class Teacher : Person
    {
        List<Student> students = new List<Student>();
        public static Teacher[] TeacherMas = new Teacher[]
            {
                new Teacher("Виктор", 30), new Teacher("Мария", 40),
                new Teacher("Елена", 27), new Teacher("Павел", 45),
                new Teacher("Ирина", 35), new Teacher("Николя", 32)
            };
        public static Teacher RandomTeacher(Random rnd = null)
        {
            if (rnd != null)
                return TeacherMas[rnd.Next(TeacherMas.Length)];
            else return TeacherMas[(new Random()).Next(TeacherMas.Length)].Clone();
        }
        public List<Student> Students
        {
            get { return students; }
            set
            {
                students.Clear();
                students.AddRange(value);
            }
        }
        public Teacher() : base() { }
        public Teacher(string name, int age, List<Student> students = null) : base(name, age)
        {
            if (students != null)
            {
                this.students.AddRange(students);
                foreach (var stud in students)
                    stud.CurrentTeacher = this;
            }
        }
        public override void Print()
        {
            base.Print();
            if (students.Count > 0)
                Console.Write("Студенты: ");
            else Console.Write("Студенты: Отсутствуют");
            foreach (var stud in students) Console.Write($"{stud}, ");
            Console.WriteLine();
        }
        public override Teacher Clone()
        {
            Teacher TeacherClone = new Teacher(Name, Age, null);
            List<Student> lst = new List<Student>();
            Student StudentClone = null;
            foreach (var stud in students)
            {
                StudentClone = new Student(stud.Name, stud.Age, stud.Course, TeacherClone);
                lst.Add(StudentClone);
            }
            TeacherClone.students.AddRange(lst);
            return TeacherClone;
        }
        public void AddStudent(Student std)
        {
            if (std.CurrentTeacher != null)
                std.CurrentTeacher.Students.Remove(std);
            students.Add(std);
            std.CurrentTeacher = this;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Teacher)) return false;
            Teacher ObjTeach = (Teacher)obj;
            if (base.Equals(obj))
                if (students.Count == ObjTeach.Students.Count)
                    foreach (var stud1 in students)
                    {
                        bool same = false;
                        foreach (var stud2 in stud1.CurrentTeacher.Students)
                            if ((stud1.Age == stud2.Age) && (stud1.Name == stud2.Name) && (stud1.Course == stud2.Course))
                            {
                                same = true;
                                break;
                            }
                        if (same != true) return false;
                    }
                else return false;
            return true;
        }
        public override int GetHashCode()
        {
            int sum = base.GetHashCode();
            foreach (var stud in students)
                sum += stud.Name.GetHashCode() + stud.Age.GetHashCode() + stud.Course.GetHashCode();
            return sum;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
