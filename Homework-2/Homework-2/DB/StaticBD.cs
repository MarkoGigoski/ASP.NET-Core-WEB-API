using Homework_2.Models;

namespace Homework_2.DB
{
    public static class StaticBD
    {
        public static List<Book> Books = new List<Book>
        {
            new Book()
            {
                Id = 1,
                Author = "John Steinbeck",
                Title = "The Grapes of Wrath"
            },
            new Book()
            {
                Id = 2,
                Author = "John Steinbeck",
                Title = "East of Eden"
            },
            new Book()
            {
                Id = 3,
                Author = "His Dark Materials",
                Title = "Philip Pullman"
            },
            new Book()
            {
                Id = 4,
                Author = "Gone with the Wind",
                Title = "Margaret Mitchell"
            },
            new Book()
            {
                Id = 5,
                Author = "Edith Wharton",
                Title = "The House of Mirth"
            },
            new Book()
            {
                Id = 6,
                Author = "William Faulkner",
                Title = "Absalom, Absalom!"
            }
        };
        
    }
}
