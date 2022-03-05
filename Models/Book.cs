using System;
using System.ComponentModel.DataAnnotations;

namespace LibApp.Models
{
    public class Book
    {
        public int Id { get; set; }

		[Required(ErrorMessage = "Name is required.")]
		[StringLength(255)]
		public string Name { get; set; }

		[Required(ErrorMessage = "Author name is required.")]
		public string AuthorName { get; set; }

		public Genre Genre { get; set; }

		[Required(ErrorMessage = "Genre Id is required.")]
		public byte GenreId { get; set; }

		public DateTime DateAdded { get; set; }

		[Required(ErrorMessage = "Release Date is required.")]
		public DateTime ReleaseDate { get; set; }

		[Required(ErrorMessage = "Number in stock is required.")]
		[Range(1, 20, ErrorMessage = "Number in stock must be between 1 and 20.")]
		public int NumberInStock { get; set; }

		[Required(ErrorMessage = "Number available is required.")]
		public int NumberAvailable { get; set; }
	}
}
