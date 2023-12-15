using Microsoft.VisualStudio.TestTools.UnitTesting;
using University;

namespace TestUniversity
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetHashCode()
        {
            Teacher T1 = new Teacher("Василий", 30);
            Teacher T2 = new Teacher("Василий", 30);
            Student S1 = new Student("Саша", 21, 3);
            Student S2 = S1.Clone();
            T1.AddStudent(S1);
            T2.AddStudent(S2);
            Assert.IsTrue((T1.GetHashCode() == T2.GetHashCode()) && (S1.GetHashCode() == S2.GetHashCode())); 
        }
        [TestMethod]
        public void TestToString()
        {
            Person person = new Person("Алекс", 25);
            Student student = new Student(person.ToString(), 20, 1);
            Teacher teacher = new Teacher(person.ToString(), 40);
            Assert.IsTrue((person.ToString() == student.ToString()) && (person.ToString() == teacher.ToString()));
        }
        [TestMethod]
        public void TestEquals()
        {
            Teacher T1 = new Teacher("Василий", 30);
            Teacher T2 = new Teacher("Василий", 30);
            Student S1 = new Student("Саша", 21, 3);
            Student S2 = new Student("Саша", 21, 3);
            Student S3 = new Student("Маша", 20, 2);
            T1.AddStudent(S1);
            T2.AddStudent(S2);
            T1.AddStudent(S3);
            T2.AddStudent(S3.Clone());
            Assert.IsTrue(T1.Equals(T2) && S1.Equals(S2));
        }
    }
}
