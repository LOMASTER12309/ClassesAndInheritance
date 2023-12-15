using System;
using Library;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            BookGenrePubl book = new BookGenrePubl("Преступление и наказание", "Ф.М. Достоевский", 300, "Роман", "МИФ");
            ((Book)book).Print();
            Console.WriteLine();
            ((BookGenre)book).Print();
            Console.WriteLine();
            book.Print();
        }
    }
}
