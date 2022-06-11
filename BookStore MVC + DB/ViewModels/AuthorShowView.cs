using BookStore_MVC___DB.Models;
using System.Collections.Generic;

namespace BookStore_MVC___DB.ViewModels
{
    public class AuthorShowView
    {
        public int? FindAuthorId { get; set; }
        public int? AuthorBooksId { get; set; }
        public int? DeleteAuthorId { get; set; }
        public int? IdAuthorBind { get; set; }
        public int? IdBookBind { get; set; }
        public Author EditAuthor { get; set; }
        public Author AuthorById { get; set; }
        public Author NewAuthor { get; set; }
        public IEnumerable<Author> AllAuthors { get; set; }
        public IEnumerable<Book> AuthorBooksById { get; set; }
    }
}
