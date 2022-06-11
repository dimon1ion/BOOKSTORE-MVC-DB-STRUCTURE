using BookStore_MVC___DB.Models;
using System.Collections.Generic;

namespace BookStore_MVC___DB.ViewModels
{
    public class GenreShowView
    {
        public int? FindGenreId { get; set; }
        public int? GenreBooksId { get; set; }
        public int? DeleteGenreId { get; set; }
        public int? IdGenreBind { get; set; }
        public int? IdBookBind { get; set; }
        public Genre EditGenre { get; set; }
        public Genre GenreById { get; set; }
        public Genre NewGenre { get; set; }
        public IEnumerable<Genre> AllGenres { get; set; }
        public IEnumerable<Book> GenreBooksById { get; set; }
    }
}
