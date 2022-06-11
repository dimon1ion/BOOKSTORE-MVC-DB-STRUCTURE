using System;

namespace BookStore_MVC___DB.Models
{
    public class Author : Base
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }

    }
}
