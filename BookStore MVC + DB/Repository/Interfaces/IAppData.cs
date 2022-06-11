namespace BookStore_MVC___DB.Repository
{
    public interface IAppData
    {
        BookRepository Book { get; }
        AuthorRepository Author { get; }
        GenreRepository Genre { get; }

    }
}
