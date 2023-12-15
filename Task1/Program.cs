using System;
using System.Collections.Generic;
using University;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int choice = 0;
            List<object> persons = new List<object>(10);
            for (int i = 0; i < 10; i++)
            {
                choice = rnd.Next(3);
                switch (choice)
                {
                    case 0:
                        persons.Add(Person.RandomPerson(rnd));
                        break;
                    case 1:
                        persons.Add(Student.RandomStudent(rnd));
                        break;
                    case 2:
                        persons.Add(Teacher.RandomTeacher(rnd));
                        break;
                }
            }
            Type type;
            List<Person> Persons = new List<Person>();
            List<Student> Students = new List<Student>();
            List<Teacher> Teachers = new List<Teacher>();
            foreach (var obj in persons)
            {
                type = obj.GetType();
                if (type == typeof(Person)) Persons.Add((Person)obj);
                else if (type == typeof(Student))
                {
                    Students.Add((Student)obj);
                    ((Student)obj).Course++;
                }
                else if (type == typeof(Teacher)) Teachers.Add((Teacher)obj);
            }
            Console.WriteLine($"Количество Person = {Persons.Count}");
            Console.WriteLine($"Количество Student = {Students.Count}");
            Console.WriteLine($"Количество Teacher = {Teachers.Count}");
            foreach (var teacher in Teachers)
                teacher.AddStudent(Students[rnd.Next(Students.Count)]);
            int index = 0;
            foreach (var obj in persons)
            {
                Console.Write($"{++index}) ");
                ((Person)obj).Print();
                Console.WriteLine();
            }
            List<Person> lst = new List<Person>();
            lst.Add(Students[0].Clone());
            lst.Add(Teachers[0].Clone());
            lst.Add(Persons[0].Clone());
            foreach (var obj in lst)
                Console.WriteLine(obj.GetType());
            Student.Ancestors();
        }
    }
}
