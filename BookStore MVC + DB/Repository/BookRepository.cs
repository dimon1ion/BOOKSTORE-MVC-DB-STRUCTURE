using BookStore_MVC___DB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;

namespace BookStore_MVC___DB.Repository
{
    public class BookRepository : IRepository<Book>
    {
        private readonly SqlConnection connection;
        public BookRepository()
        {
            connection = BooksContext.GetConnection();
        }
        public async Task<int> Add(Book data)
        {
            using (IDbConnection db = connection)
            {
                string query = @"INSERT INTO Books(Name, Pages, Price, Stock)" +
                    " VALUES (@Name, @Pages, @Price, @Stock)";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Name", data.Name, DbType.String);
                parameters.Add("@Pages", data.Pages, DbType.Int32);
                parameters.Add("@Price", data.Price, DbType.Decimal);
                parameters.Add("@Stock", data.Stock, DbType.Int32);


                return await db.ExecuteAsync(query, parameters);
            }
        }

        public async Task<int> Delete(int id)
        {
            using (IDbConnection db = connection)
            {
                string query = @"UPDATE Books SET Status = @Status WHERE Books.ID = @ID";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Status", Status.Delete);
                parameters.Add("@ID", id, DbType.Int32);

                return await db.ExecuteAsync(query, parameters);
            }
        }

        public async Task<int> Edit(Book data)
        {
            using (IDbConnection db = connection)
            {
                string query = @"UPDATE Books SET Name = @Name, Pages = @Pages, Price = @Price, Stock = @Stock WHERE Books.ID = @ID AND Status = @Status";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Name", data.Name, DbType.String);
                parameters.Add("@Pages", data.Pages, DbType.Int32);
                parameters.Add("@Price", data.Price, DbType.Decimal);
                parameters.Add("@Status", Status.Active);
                parameters.Add("@Stock", data.Stock);
                parameters.Add("@ID", data.Id, DbType.Int32);

                return await db.ExecuteAsync(query, parameters);
            }
        }

        public async Task<IEnumerable<Book>> Get()
        {
            using (IDbConnection db = connection)
            {
                string query = @"SELECT * FROM Books WHERE Status = @Status";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add(@"Status", Status.Active);

                return await db.QueryAsync<Book>(query, parameters);
            }
        }

        public async Task<Book> Get(int id)
        {
            using (IDbConnection db = connection)
            {
                string query = @"SELECT * FROM Books WHERE ID = @ID AND Status = @Status";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add(@"Status", Status.Active);
                parameters.Add("@ID", id, DbType.Int32);

                try
                {
                    return await db.QueryFirstAsync<Book>(query, parameters);
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

            //using (connection)
            //{
            //    string query = @"SELECT * FROM Books WHERE ID = @ID";

            //    SqlCommand command = new SqlCommand(query, connection);
            //    command.Parameters.Add(new SqlParameter("@ID", id));

            //    connection.Open();

            //    DataTable data = new DataTable();

            //    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            //    {
            //        adapter.Fill(data);
            //    }

            //    if (data != null && data.Rows.Count > 0)
            //    {
            //        DataRow row = data.Rows[0];

            //        Book book = new Book()
            //        {
            //            Id = Convert.ToInt32(row["ID"]),
            //            Name = Convert.ToString(row["Name"]),
            //            Pages = Convert.ToInt32(row["Pages"]),
            //            Price = Convert.ToDecimal(row["Price"]),
            //            Stock = Convert.ToInt32(row["Stock"]),
            //            Status = (Status)(Convert.ToInt32(row["Status"]))
            //        };

            //        return book;
            //    }
            //}

            //return null;
        }
        public async Task<IEnumerable<Author>> GetAuthors(int bookId)
        {
            using (IDbConnection db = connection)
            {
                string query = @"SELECT Authors.ID, Authors.Firstname, Authors.Lastname, Authors.Birthdate, Authors.Status FROM BookAutors, Authors" +
                    " WHERE BookAutors.BookId = @BookId AND Authors.ID = BookAutors.AuthorId AND Authors.Status = @Status";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add(@"Status", Status.Active);
                parameters.Add(@"BookId", bookId, DbType.Int32);

                return await db.QueryAsync<Author>(query, parameters);
            }
        }

        public async Task<int> AddAuthor(int bookId, int authorId)
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

        public async Task<IEnumerable<Genre>> GetGenres(int bookId)
        {
            using (IDbConnection db = connection)
            {
                string query = @"SELECT Genres.ID, Genres.Name FROM BookGenres, Genres" +
                    " WHERE BookGenres.BookId = @BookId AND Genres.ID = BookGenres.GenreId AND Genres.Status = @Status";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add(@"Status", Status.Active);
                parameters.Add(@"BookId", bookId, DbType.Int32);

                return await db.QueryAsync<Genre>(query, parameters);
            }
        }

        public async Task<int> AddGenre(int bookId, int genreId)
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
