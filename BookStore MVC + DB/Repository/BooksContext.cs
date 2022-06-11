using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace BookStore_MVC___DB.Repository
{
    public static class BooksContext
    {
        private static string ConnectionString = "";
        public static SqlConnection GetConnection()
        {
            ConnectionString = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build()
                .GetConnectionString("BookStore");
            return new SqlConnection(ConnectionString);
        }
    }
}
