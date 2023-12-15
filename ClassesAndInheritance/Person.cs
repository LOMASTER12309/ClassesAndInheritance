using System;
using System.Collections.Generic;

namespace University
{
    public class Person
    {
        string name;
        int age;
        static public Person[] PersonMas = new Person[]
        {
            new Person("Анатолий", 16), new Person("Сергей", 17),
            new Person("Настя", 18), new Person("Алёна", 19),
            new Person("Кирилл", 20), new Person("Ксения", 21)
        };
        public static Person RandomPerson(Random rnd = null)
        {
            if (rnd != null)
                return PersonMas[rnd.Next(PersonMas.Length)];
            else return PersonMas[(new Random()).Next(PersonMas.Length)].Clone();
        }
        public int Age
        {
            get { return age; }
            set { if (value < 0) value = 0; age = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Person()
        {
            name = "Noname";
            age = 0;
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public override string ToString()
        {
            return name;
        }

        public virtual void Print()
        {
            Console.WriteLine($"Имя: {name}; Возраст: {age}");
        }

        public virtual Person Clone()
        {
            return new Person(name, age);
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Person)) return false;
            Person ObjPerson = (Person)obj;
            if ((ObjPerson.Age == Age) && (ObjPerson.Name == Name)) return true;
            return false;
        }
        public override int GetHashCode()
        {
            return name.GetHashCode() + age.GetHashCode();
        }
    }
}
