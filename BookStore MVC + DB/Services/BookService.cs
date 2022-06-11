using BookStore_MVC___DB.Models;
using BookStore_MVC___DB.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore_MVC___DB.Services
{
    public class BookService : IBookService
    {
        private readonly IAppData _data;

        public IAppData Data { get => _data;}

        public BookService(IAppData data)
        {
            _data = data;
        }
        public async Task<Book> GetBook(int id)
        {
            return await _data.Book.Get(id);
        }
    }
}
