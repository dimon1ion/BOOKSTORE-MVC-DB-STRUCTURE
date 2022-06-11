using BookStore_MVC___DB.Models;
using BookStore_MVC___DB.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore_MVC___DB.Services
{
    public interface IBookService
    {
        public IAppData Data { get; }
        Task<Book> GetBook(int id);
    }
}
