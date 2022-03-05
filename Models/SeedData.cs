using System;
using System.Linq;
using LibApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // MembershipTypes seed
                if (context.MembershipTypes.Any())
                {
                    Console.WriteLine("MembershipTypes already seeded!");
                }
                else
                {
                    context.MembershipTypes.AddRange(
                        new MembershipType
                        {
                            Id = 1,
                            Name = "Pay as You Go",
                            SignUpFee = 0,
                            DurationInMonths = 0,
                            DiscountRate = 0
                        },
                        new MembershipType
                        {
                            Id = 2,
                            Name = "Monthly",
                            SignUpFee = 30,
                            DurationInMonths = 1,
                            DiscountRate = 10
                        },
                        new MembershipType
                        {
                            Id = 3,
                            Name = "Quaterly",
                            SignUpFee = 90,
                            DurationInMonths = 3,
                            DiscountRate = 15
                        },
                        new MembershipType
                        {
                            Id = 4,
                            Name = "Yearly",
                            SignUpFee = 300,
                            DurationInMonths = 12,
                            DiscountRate = 20
                        });
                    context.SaveChanges();
                }

                // Genre seed
                if (context.Genre.Any())
                {
                    Console.WriteLine("Genres already seeded!");
                } 
                else
                {
                    context.Genre.AddRange(
                        new Genre
                        {
                            Name = "Comedy"
                        },
                        new Genre
                        {
                            Name = "Horror"
                        },
                        new Genre
                        {
                            Name = "Drama"
                        });
                    context.SaveChanges();
                }

                // Books seed
                if (context.Books.Any())
                {
                    Console.WriteLine("Books already seeded!");
                }
                else
                {
                    context.Books.AddRange(
                        new Book
                        {
                            Name = "Harry Potter i Komnata Tajemnic",
                            AuthorName = "J.K. Rowling",
                            GenreId = 1,
                            DateAdded = DateTime.Now,
                            ReleaseDate = new DateTime(2008, 1, 25),
                            NumberInStock = 80,
                            NumberAvailable = 90
                        },
                        new Book
                        {
                            Name = "Ludzie bezdomni",
                            AuthorName = "Stefan Żeromski",
                            GenreId = 2,
                            DateAdded = DateTime.Now,
                            ReleaseDate = new DateTime(2012, 2, 22),
                            NumberInStock = 250,
                            NumberAvailable = 300
                        },
                        new Book
                        {
                            Name = "Zapiski więzienne",
                            AuthorName = "Stefan Wyszyński",
                            GenreId = 3,
                            DateAdded = DateTime.Now,
                            ReleaseDate = new DateTime(2004, 3, 13),
                            NumberInStock = 30,
                            NumberAvailable = 70
                        });
                    context.SaveChanges();
                }

                // Customers seed
                if (context.Customers.Any())
                {
                    Console.WriteLine("Customers already seeded!");
                }
                else
                {
                    context.Customers.AddRange(
                        new Customer
                        {
                            Name = "Krystian Niezgoda",
                            Birthdate = new DateTime(1987, 8, 10),
                            HasNewsletterSubscribed = false,
                            MembershipTypeId = 1
                        },
                        new Customer
                        {
                            Name = "Marek Krecinozka",
                            Birthdate = new DateTime(2000, 4, 7),
                            HasNewsletterSubscribed = true,
                            MembershipTypeId = 2
                        },
                        new Customer
                        {
                            Name = "Paweł Głowa",
                            Birthdate = new DateTime(1987, 7, 11),
                            HasNewsletterSubscribed = false,
                            MembershipTypeId = 3
                        });
                    context.SaveChanges();
                }

                // Rentals seed 
                if (context.Rentals.Any())
                {
                    Console.WriteLine("Rentals already seeded!");
                }
                else
                {
                    context.Rentals.AddRange(
                        new Rental
                        {
                            CustomerId = 1,
                            BookId = 1,
                            DateRented = DateTime.Now
                        },
                        new Rental
                        {
                            CustomerId = 2,
                            BookId = 2,
                            DateRented = DateTime.Now
                        },
                        new Rental
                        {
                            CustomerId = 3,
                            BookId = 3,
                            DateRented = DateTime.Now
                        });
                    context.SaveChanges();
                }
            }
        }
    }
}