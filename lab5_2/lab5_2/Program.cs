using System;
using System.Collections;
using System.Collections.Generic;

namespace lab5_2
{
    public class Book
    {
        private string book_name;
        private string book_author;
        private int book_price;
        public Book(string Name, string Author, int Price)
        {
            book_name = Name;
            book_author = Author;
            book_price = Price;
        }
        public string Name
        {
            get
            {
                return book_name;
            }
            set
            {
                book_name = value;
            }
        }
        public string Author
        {
            get
            {
                return book_author;
            }
            set
            {
                book_author = value;
            }
        }
        public int Price
        {
            get
            {
                return book_price;
            }
            set
            {
                book_price = value;
            }
        }
        public virtual ArrayList Print()
        {
            ArrayList books = new ArrayList();
            books.Add(book_name);
            books.Add(book_author);
            books.Add(book_price);
            return books;
        }
    }
    public class BookGenre : Book //базовый класс Book
    {
        private string genre;
        public BookGenre(string Name, string Author, int Price, string Genre)
            : base(Name, Author, Price)
        {
            genre = Genre;
        }

        public string Genre
        {
            get
            {
                return genre;
            }
            set
            {
                genre = value;
            }
        }

        public override ArrayList Print()
        {
            ArrayList books = new ArrayList();
            books = base.Print();
            books.Add(genre);
            return books;
        }
    }
    sealed class BookGenrePubl : BookGenre
    {
        private string publisher;
        public BookGenrePubl(string Name, string Author, int Price, string Genre, string Publisher)
            : base(Name, Author, Price, Genre)
        {
            publisher = Publisher;
        }

        public string Publisher
        {
            get
            {
                return publisher;
            }
            set
            {
                publisher = value;
            }
        }

        public override ArrayList Print()
        {
            ArrayList books = new ArrayList();
            books = base.Print();
            books.Add(publisher);
            return books;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("База данных книг");
            Console.Write("Введите название книги: ");
            string book_name = Console.ReadLine();
            Console.Write("Введите автора книги: ");
            string book_author = Console.ReadLine();
            Console.Write("Введите цену для книги: ");
            int book_price = Int32.Parse(Console.ReadLine());
            Console.Write("Введите жанр книги: ");
            string genre = Console.ReadLine();
            Console.Write("Введите издателя книги: ");
            string publisher = Console.ReadLine();

            BookGenrePubl book = new BookGenrePubl(book_name, book_author, book_price, genre, publisher);

            Console.WriteLine("Информация о введенной книге: ");
            foreach (object item in book.Print())
                Console.WriteLine(item);
        }
    }
}
