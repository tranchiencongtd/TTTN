using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_1
{
    class Book
    {
        public string ISBN { set; get; }
        public string bookName { set; get; }
        public string authorName { set; get; }
        public string publisherName { set; get; }

        public Book()
        {

        }

        public Book(string iSBN, string bookName, string authorName, string publisherName)
        {
            ISBN = iSBN;
            this.bookName = bookName;
            this.authorName = authorName;
            this.publisherName = publisherName;
        }

        public string GetBookInformation()
        {
            return string.Format("{0,-20}{1,-20}{2,-20}{3,-20}", this.ISBN, this.bookName, this.authorName, this.publisherName);
        }
    }
}
