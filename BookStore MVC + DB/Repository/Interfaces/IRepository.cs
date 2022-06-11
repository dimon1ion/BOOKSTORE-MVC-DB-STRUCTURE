using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore_MVC___DB.Repository
{
    public interface IRepository<T>
    {
        Task<int> Add(T data);
        Task<int> Delete(int id);
        Task<int> Edit(T data);
        Task<IEnumerable<T>> Get();
        Task<T> Get(int id);
        
    }
}
