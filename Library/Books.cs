using System;

namespace Library
{
    public class Book
    {
        string title;
        string author;
        int price;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public int Price
        {
            get { return price; }
            set { price = Math.Abs(value); }
        }
        public Book(string Title, string Author, int Price)
        {
            title = Title;
            author = Author;
            price = Price;
        }
        public virtual void Print()
        {
            Console.WriteLine($"Название: {title}");
            Console.WriteLine($"Автор: {author}");
            Console.WriteLine($"Цена: {price} руб.");
        }
    }

    public class BookGenre: Book
    {
        string genre;
        public BookGenre(string Title, string Author, int Price, string Genre):base(Title, Author, Price)
        {
            genre = Genre;
        }
        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Жанр: {genre}");
        }
    }
    sealed public class BookGenrePubl: BookGenre
    {
        string publisher;
        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }
        public BookGenrePubl(string Title, string Author, int Price, string Genre, string Publisher) : base(Title, Author, Price, Genre)
        {
            publisher = Publisher;
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Издатель: {publisher}");
        }
    }
}
