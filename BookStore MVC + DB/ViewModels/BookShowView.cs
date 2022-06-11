using BookStore_MVC___DB.Models;
using System.Collections.Generic;

namespace BookStore_MVC___DB.ViewModels
{
    public class BookShowView
    {
        public int? FindBookId { get; set; }
        public int? BookAuthorsId { get; set; }
        public int? BookGenresId { get; set; }
        public int? DeleteBookId { get; set; }
        public int? IdBookBind { get; set; }
        public int? IdBookGenreBind { get; set; }
        public int? IdAuthorBind { get; set; }
        public int? IdGenreBind { get; set; }
        public Book EditBook { get; set; }
        public Book BookById { get; set; }
        public Book NewBook { get; set; }
        public IEnumerable<Book> AllBooks { get; set; }
        public IEnumerable<Author> BookAuthorsById { get; set; }
        public IEnumerable<Genre> BookGenresById { get; set; }
        //public IEnumerable<Author> Authors { get; set; }
        //public IEnumerable<Genre> Genres { get; set; }
    }
}
