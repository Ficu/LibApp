using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using LibApp.Models;
using LibApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using LibApp.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace LibApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookRepository _bookRepository;

        private readonly IGenreRepository _genreRepository;

        public BooksController(IBookRepository bookRepository, IGenreRepository genreRepository)
        {
            _bookRepository = bookRepository;
            _genreRepository = genreRepository;
        }

        public IActionResult Index()
        {
            var books = _bookRepository.GetBooks();

            return View(books);
        }

        public IActionResult Details(int id)
        {
            var book = _bookRepository.SingleOrDefault(id);

            if (book == null)
            {
                return Content("Book not found");
            }

            return View(book);
        }

        [Authorize(Roles = "StoreManager,Owner")]
        public IActionResult Edit(int id)
        {
            var book = _bookRepository.SingleOrDefault(id);
            if (book == null)
            {
                return NotFound();
            }

            var viewModel = new BookFormViewModel(book)
            {
                Genres = _genreRepository.GetGenres().ToList()
            };

            return View("BookForm", viewModel);
        }

        [Authorize(Roles = "StoreManager,Owner")]
        public IActionResult New()
        {
            var genres = _genreRepository.GetGenres().ToList();
            var viewModel = new BookFormViewModel
            {
                Genres = genres
            };

            return View("BookForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "StoreManager,Owner")]
        public IActionResult Save(Book book)
        {
            if (!ModelState.IsValid)
            {
                return FormViewFor(book);
            }

            if (book.Id == 0)
            {
                book.DateAdded = DateTime.Now;
                _bookRepository.AddBook(book);
            }
            else
            {
                var bookInDb = _bookRepository.SingleOrDefault(book.Id);
                bookInDb.Name = book.Name;
                bookInDb.AuthorName = book.AuthorName;
                bookInDb.ReleaseDate = book.ReleaseDate;
                bookInDb.GenreId = book.GenreId;
                bookInDb.NumberInStock = book.NumberInStock;
                bookInDb.NumberAvailable = book.NumberAvailable;
            }

            try
            {
                _bookRepository.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("Index", "Books");
        }

        protected IActionResult FormViewFor(Book book)
        {
            var viewModel = new BookFormViewModel(book)
            {
                Genres = _genreRepository.GetGenres().ToList()
            };

            return View("BookForm", viewModel);
        }
    }
}
