using BookStore_MVC___DB.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BookStore_MVC___DB.Repository
{
    public class GenreRepository : IRepository<Genre>
    {
        private readonly SqlConnection connection;
        public GenreRepository()
        {
            connection = BooksContext.GetConnection();
        }
        public async Task<int> Add(Genre data)
        {
            using (IDbConnection db = connection)
            {
                string query = @"INSERT INTO Genres(Name)" +
                    " VALUES (@Name)";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Name", data.Name, DbType.String);

                return await db.ExecuteAsync(query, parameters);
            }
        }

        public async Task<int> Delete(int id)
        {
            using (IDbConnection db = connection)
            {
                string query = @"UPDATE Genres SET Status = @Status WHERE Genres.ID = @ID";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Status", Status.Delete);
                parameters.Add("@ID", id, DbType.Int32);

                return await db.ExecuteAsync(query, parameters);
            }
        }

        public async Task<int> Edit(Genre data)
        {
            using (IDbConnection db = connection)
            {
                string query = @"UPDATE Genres SET Name = @Name WHERE Genres.ID = @ID AND Status = @Status";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Name", data.Name, DbType.String);
                parameters.Add("@Status", Status.Active, DbType.Int32);
                parameters.Add("@ID", data.Id, DbType.Int32);

                return await db.ExecuteAsync(query, parameters);
            }
        }

        public async Task<IEnumerable<Genre>> Get()
        {
            using (IDbConnection db = connection)
            {
                string query = @"SELECT * FROM Genres WHERE Status = @Status";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add(@"Status", Status.Active);

                return await db.QueryAsync<Genre>(query, parameters);
            }
        }

        public async Task<Genre> Get(int id)
        {
            using (IDbConnection db = connection)
            {
                string query = @"SELECT * FROM Genres WHERE ID = @ID AND Status = @Status";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add(@"Status", Status.Active);
                parameters.Add("@ID", id, DbType.Int32);

                try
                {
                    return await db.QueryFirstAsync<Genre>(query, parameters);
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public async Task<IEnumerable<Book>> GetBooks(int genreId)
        {
            using (IDbConnection db = connection)
            {
                string query = @"SELECT Books.ID, Books.Name, Books.Pages, Books.Price, Books.Stock, Books.Status FROM BookGenres, Books" +
                    " WHERE BookGenres.GenreId = @GenreId AND Books.ID = BookGenres.BookId AND Books.Status = @Status";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add(@"Status", Status.Active);
                parameters.Add(@"GenreId", genreId, DbType.Int32);

                return await db.QueryAsync<Book>(query, parameters);
            }
        }

        public async Task<int> AddBook(int genreId, int bookId)
        {
            using (IDbConnection db = connection)
            {
                string query = @"INSERT INTO BookGenres(BookId, GenreId)" +
                    " VALUES (@BookId, @GenreId)";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add(@"BookId", bookId, DbType.Int32);
                parameters.Add(@"GenreId", genreId, DbType.Int32);

                return await db.ExecuteAsync(query, parameters);
            }
        }
    }
}
