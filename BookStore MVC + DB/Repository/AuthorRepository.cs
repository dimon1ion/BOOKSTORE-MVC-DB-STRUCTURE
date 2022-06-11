using BookStore_MVC___DB.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BookStore_MVC___DB.Repository
{
    public class AuthorRepository : IRepository<Author>
    {
        private readonly SqlConnection connection;
        public AuthorRepository()
        {
            connection = BooksContext.GetConnection();
        }
        public async Task<int> Add(Author data)
        {
            using (IDbConnection db = connection)
            {
                string query = @"INSERT INTO Authors(Firstname, Lastname, Birthdate)" +
                    " VALUES (@FName, @LName, @Birthdate)";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@FName", data.FirstName, DbType.String);
                parameters.Add("@LName", data.LastName, DbType.String);
                parameters.Add("@Birthdate", data.Birthdate, DbType.Date);

                return await db.ExecuteAsync(query, parameters);
            }
        }

        public async Task<int> Delete(int id)
        {
            using (IDbConnection db = connection)
            {
                string query = @"UPDATE Authors SET Status = @Status WHERE Authors.ID = @ID";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Status", Status.Delete);
                parameters.Add("@ID", id, DbType.Int32);

                return await db.ExecuteAsync(query, parameters);
            }
        }

        public async Task<int> Edit(Author data)
        {
            using (IDbConnection db = connection)
            {
                string query = @"UPDATE Authors SET Firstname = @FName, Lastname = @LName, Birthdate = @Birthdate WHERE Authors.ID = @ID AND Status = @Status";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@FName", data.FirstName, DbType.String);
                parameters.Add("@LName", data.LastName, DbType.String);
                parameters.Add("@Birthdate", data.Birthdate, DbType.Date);
                parameters.Add("@Status", Status.Active, DbType.Int32);
                parameters.Add("@ID", data.Id, DbType.Int32);

                return await db.ExecuteAsync(query, parameters);
            }
        }

        public async Task<IEnumerable<Author>> Get()
        {
            using (IDbConnection db = connection)
            {
                string query = @"SELECT * FROM Authors WHERE Status = @Status";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add(@"Status", Status.Active);

                return await db.QueryAsync<Author>(query, parameters);
            }
        }

        public async Task<Author> Get(int id)
        {
            using (IDbConnection db = connection)
            {
                string query = "SELECT * FROM Authors WHERE ID = @ID AND Status = @Status";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add(@"Status", Status.Active);
                parameters.Add("ID", id);

                try
                {
                    return await db.QueryFirstAsync<Author>(query, parameters);
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public async Task<IEnumerable<Book>> GetBooks(int authorId)
        {
            using (IDbConnection db = connection)
            {
                string query = @"SELECT Books.ID, Books.Name, Books.Pages, Books.Price, Books.Stock, Books.Status FROM BookAutors, Books" +
                    " WHERE BookAutors.AuthorId = @AuthorId AND Books.ID = BookAutors.BookId AND Books.Status = @Status";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add(@"Status", Status.Active);
                parameters.Add(@"AuthorId", authorId, DbType.Int32);

                return await db.QueryAsync<Book>(query, parameters);
            }
        }
        public async Task<int> AddBook(int authorId, int bookId)
        {
            using (IDbConnection db = connection)
            {
                string query = @"INSERT INTO BookAutors(BookId, AuthorId)" +
                    " VALUES (@BookId, @AuthorId)";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add(@"BookId", bookId, DbType.Int32);
                parameters.Add(@"AuthorId", authorId, DbType.Int32);

                return await db.ExecuteAsync(query, parameters);
            }
        }
    }
}
