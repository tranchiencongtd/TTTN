using System;

namespace Ex_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("123456", "Harry Potter", "J.K Rowling", "Kim Dong");
            Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}", "ISBN number", "Book Name", "Author Name", "Publisher Name");
            Console.WriteLine(book.GetBookInformation());
            Console.ReadLine();
        }
    }
}
