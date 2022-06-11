namespace BookStore_MVC___DB.Repository
{
    public class AppData : IAppData
    {
        private readonly BookRepository book;
        public BookRepository Book => book ?? new BookRepository();

        private readonly AuthorRepository author;
        public AuthorRepository Author => author ?? new AuthorRepository();

        private readonly GenreRepository genre;
        public GenreRepository Genre => genre ?? new GenreRepository();
    }
}
