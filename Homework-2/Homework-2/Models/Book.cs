using System.Security.Cryptography.X509Certificates;

namespace Homework_2.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }

        public Book(int id,string author,string title)
        {
            Id = id;    
            Author = author;    
            Title = title;  
        }

        public Book()
        {
        }
    }
}
