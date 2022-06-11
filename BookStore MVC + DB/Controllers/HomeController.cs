using BookStore_MVC___DB.Models;
using BookStore_MVC___DB.Services;
using BookStore_MVC___DB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_MVC___DB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookService _books;

        public HomeController(ILogger<HomeController> logger, IBookService books)
        {
            _logger = logger;
            _books = books;
        }

        [HttpGet]
        public async Task<IActionResult> Index(BookShowView show)
        {
            if (show.DeleteBookId != null)
            {
                await _books.Data.Book.Delete(show.DeleteBookId.Value);
            }
            if (show.EditBook?.Id != null && show.EditBook?.Name != null)
            {
                await _books.Data.Book.Edit(show.EditBook);
            }
            if (show.FindBookId != null)
            {
                show.BookById = await _books.GetBook(show.FindBookId.Value);
            }
            if (show.BookAuthorsId != null)
            {
                show.BookAuthorsById = await _books.Data.Book.GetAuthors(show.BookAuthorsId.Value);
            }
            if (show.BookGenresId != null)
            {
                show.BookGenresById = await _books.Data.Book.GetGenres(show.BookGenresId.Value);
            }
            if (show.IdBookBind != null && show.IdAuthorBind != null)
            {
                await _books.Data.Book.AddAuthor(show.IdBookBind.Value, show.IdAuthorBind.Value);
            }
            if (show.IdBookGenreBind != null && show.IdGenreBind != null)
            {
                await _books.Data.Book.AddGenre(show.IdBookGenreBind.Value, show.IdGenreBind.Value);
            }
            if (show.NewBook != null && show.NewBook.Name != null)
            {
                await _books.Data.Book.Add(show.NewBook);
            }
            show.AllBooks = await _books.Data.Book.Get();
            return View(show);
        }

        //[HttpGet]
        //public async Task<IActionResult> FindBook(int id)
        //{
        //    BookShowView show1 = new BookShowView()
        //    {
        //        BookById = await _books.GetBook(id)
        //    };
        //    return RedirectToAction("Index", "Home", show1);
        //}

        [HttpGet]
        public async Task<IActionResult> Authors(AuthorShowView show)
        {
            if (show.DeleteAuthorId != null)
            {
                await _books.Data.Author.Delete(show.DeleteAuthorId.Value);
            }
            if (show.EditAuthor?.Id != null && show.EditAuthor?.FirstName != null
                && show.EditAuthor?.LastName != null)
            {
                await _books.Data.Author.Edit(show.EditAuthor);
            }
            if (show.FindAuthorId != null)
            {
                show.AuthorById = await _books.Data.Author.Get(show.FindAuthorId.Value);
            }
            if (show.AuthorBooksId != null)
            {
                show.AuthorBooksById = await _books.Data.Author.GetBooks(show.AuthorBooksId.Value);
            }
            if (show.IdBookBind != null && show.IdAuthorBind != null)
            {
                await _books.Data.Author.AddBook(show.IdAuthorBind.Value, show.IdBookBind.Value);
            }
            if (show.NewAuthor != null && show.NewAuthor.FirstName != null && show.NewAuthor.LastName != null)
            {
                await _books.Data.Author.Add(show.NewAuthor);
            }
            show.AllAuthors = await _books.Data.Author.Get();
            return View(show);
        }

        [HttpGet]
        public async Task<IActionResult> Genres(GenreShowView show)
        {
            if (show.DeleteGenreId != null)
            {
                await _books.Data.Genre.Delete(show.DeleteGenreId.Value);
            }
            if (show.EditGenre?.Id != null && show.EditGenre?.Name != null)
            {
                await _books.Data.Genre.Edit(show.EditGenre);
            }
            if (show.FindGenreId != null)
            {
                show.GenreById = await _books.Data.Genre.Get(show.FindGenreId.Value);
            }
            if (show.GenreBooksId != null)
            {
                show.GenreBooksById = await _books.Data.Genre.GetBooks(show.GenreBooksId.Value);
            }
            if (show.IdBookBind != null && show.IdGenreBind != null)
            {
                await _books.Data.Genre.AddBook(show.IdGenreBind.Value, show.IdBookBind.Value);
            }
            if (show.NewGenre != null && show.NewGenre.Name != null)
            {
                await _books.Data.Genre.Add(show.NewGenre);
            }
            show.AllGenres = await _books.Data.Genre.Get();
            return View(show);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
