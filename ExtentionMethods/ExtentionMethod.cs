﻿using AprilBookStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AprilBookStore.ExtentionMethods
{
    public static class ExtentionMethod
    {

        public static void Seed(this ModelBuilder modelBuilder)
        {
            #region Author
            modelBuilder.Entity<Author>().HasData(
                  new Author
                  {
                      Id = 54,
                      Name = "Adam Kay",
                      IsDeleted = false,
                      IsVisible = true,
                      CreatedDate = new DateTime(2023, 12, 8),
                      UpdatedDate = new DateTime(2023, 12, 8)
                  },
                new Author
                {
                    Id = 55,
                    Name = "Daniel Kahneman",
                    IsDeleted = false,
                    IsVisible = true,
                    CreatedDate = new DateTime(2023, 12, 8),
                    UpdatedDate = new DateTime(2023, 12, 8)
                },
                new Author
                {
                    Id = 56,
                    Name = "Paul Kalanithi",
                    IsDeleted = false,
                    IsVisible = true,
                    CreatedDate = new DateTime(2023, 12, 8),
                    UpdatedDate = new DateTime(2023, 12, 8)
                },
                new Author
                {
                    Id = 57,
                    Name = "Russ Harris",
                    IsDeleted = false,
                    IsVisible = true,
                    CreatedDate = new DateTime(2023, 12, 8),
                    UpdatedDate = new DateTime(2023, 12, 8)
                },
                new Author
                {
                    Id = 59,
                    Name = "Oliver Sacks",
                    IsDeleted = false,
                    IsVisible = true,
                    CreatedDate = new DateTime(2023, 12, 8),
                    UpdatedDate = new DateTime(2023, 12, 8)
                },
                new Author
                {
                    Id = 60,
                    Name = "Michael Mosley",
                    IsDeleted = false,
                    IsVisible = true,
                    CreatedDate = new DateTime(2023, 12, 8),
                    UpdatedDate = new DateTime(2023, 12, 8)
                },
                new Author
                {
                    Id = 61,
                    Name = "Jordan B. Peterson",
                    IsDeleted = false,
                    IsVisible = true,
                    CreatedDate = new DateTime(2023, 12, 8),
                    UpdatedDate = new DateTime(2023, 12, 8)
                },

                new Author { Id = 58, Name = "Viktor E. Frankl", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 155, Name = "Daniel J. Levitin", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 156, Name = "Erik Larson", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 62, Name = "Atul Gawande", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 63, Name = "Giulia Enders", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 64, Name = "Norman Doidge", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 65, Name = "Anthony William", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 66, Name = "Keri Smith", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 67, Name = "Dr. Natasha Campbell-McBride", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 68, Name = "Austin Kleon", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 69, Name = "Eline Snel", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 70, Name = "Michael Greger", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 71, Name = "Tina Payne Bryson", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 72, Name = "Juju Sundin", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 73, Name = "American Psychiatric Association", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 74, Name = "Philippa Perry", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 75, Name = "American Psychological Association", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 76, Name = "Dr. Eben Alexander", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 77, Name = "Rebecca Skloot", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 78, Name = "Stephen R. Covey", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 79, Name = "C. G. Jung", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 80, Name = "James Clear", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 81, Name = "Dr. Sarah McKay", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 82, Name = "Dr. Rhonda Patrick", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 83, Name = "Peter Singer", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 84, Name = "Helen Fisher", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 85, Name = "Dr. Seuss", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 86, Name = "Brene Brown", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 87, Name = "Marie Kondō", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 88, Name = "James Kerr", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 89, Name = "Yuval Noah Harari", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 90, Name = "Mark Manson", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 91, Name = "Eckhart Tolle", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 92, Name = "Dr. Suess", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 93, Name = "Robert Greene", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 94, Name = "Simon Sinek", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 95, Name = "Adam Grant", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 96, Name = "Carol S. Dweck", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 97, Name = "Malcolm Gladwell", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 98, Name = "Ryan Holiday", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 99, Name = "Tony Robbins", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 100, Name = "J.K. Rowling", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 101, Name = "Dr. Jordan B. Peterson", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 102, Name = "Dale Carnegie", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 103, Name = "Susan Cain", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 104, Name = "Cal Newport", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 105, Name = "Gary Chapman", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 106, Name = "Mark Manson", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 107, Name = "Charles Duhigg", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 108, Name = "Napoleon Hill", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 109, Name = "Daniel H. Pink", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 110, Name = "Tara Westover", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 111, Name = "Angela Duckworth", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 112, Name = "Yuval Noah Harari", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 113, Name = "Ray Dalio", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 114, Name = "Jordan B. Peterson", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 115, Name = "Stephen R. Covey", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 116, Name = "Paul Kalanithi", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 117, Name = "J.D. Vance", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 118, Name = "Atul Gawande", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 119, Name = "Robert T. Kiyosaki", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 120, Name = "Cheryl Strayed", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 121, Name = "Tim Ferriss", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 122, Name = "Dale Carnegie", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 123, Name = "Robin Sharma", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 124, Name = "Brene Brown", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 125, Name = "Timothy Ferriss", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 126, Name = "Jocko Willink", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 127, Name = "David Goggins", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 128, Name = "David Allen", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 129, Name = "Yuval Noah Harari", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 130, Name = "Gary John Bishop", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 131, Name = "James Clear", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 132, Name = "Nir Eyal", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 133, Name = "Stephen R. Covey", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 134, Name = "Charles Duhigg", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 135, Name = "Daniel Kahneman", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 136, Name = "James Clear", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 137, Name = "Brené Brown", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 138, Name = "Dale Carnegie", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 139, Name = "Don Miguel Ruiz", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 140, Name = "Mark Manson", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 141, Name = "Daniel H. Pink", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 142, Name = "Gary Chapman", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 143, Name = "Stephen R. Covey", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 144, Name = "Brene Brown", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 145, Name = "Dr. Shefali Tsabary", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 146, Name = "Michael A. Singer", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 147, Name = "Dale Carnegie", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 148, Name = "Gary Chapman", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 149, Name = "Simon Sinek", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Author { Id = 150, Name = "Mark Manson", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") });
            #endregion
            #region Category
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Medical", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Category { Id = 2, Name = "Science-Geography", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") },
                new Category { Id = 3, Name = "Art-Photography", IsDeleted = false, IsVisible = true, CreatedDate = DateTime.Parse("2023-12-08"), UpdatedDate = DateTime.Parse("2023-12-08") }

                );
            #endregion
            #region Book
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 314, Name = "This is Going to Hurt", Format = "Paperback", ISBN = 9781509858637, Price = 7.60M, ImgPath = "/book-covers/Medical/0000001.jpg", CategoryId = 1, AuthorId = 54, BookStar = 2.1, PublicationYear = new DateTime(2023, 12, 8), Description = "No Description AVAILABLE", QuantityInStock = 9, IsDeleted = false, IsVisible = true, CreatedDate = new DateTime(2023, 12, 8), UpdatedDate = new DateTime(2023, 12, 8) },
                new Book { Id = 315, Name = "Thinking, Fast and Slow", Format = "Paperback", ISBN = 9780141033570, Price = 11.50M, ImgPath = "~/book-covers/Medical/0000002.jpg", CategoryId = 1, AuthorId = 55, BookStar = 1.5, PublicationYear = new DateTime(2023, 12, 8), Description = "No Description AVAILABLE", QuantityInStock = 1, IsDeleted = false, IsVisible = true, CreatedDate = new DateTime(2023, 12, 8), UpdatedDate = new DateTime(2023, 12, 8) },
                new Book { Id = 316, Name = "When Breath Becomes Air", Format = "Paperback", ISBN = 9781784701994, Price = 9.05M, ImgPath = "~/book-covers/Medical/0000003.jpg", CategoryId = 1, AuthorId = 56, BookStar = 2.1, PublicationYear = new DateTime(2023, 12, 8), Description = "No Description AVAILABLE", QuantityInStock = 8, IsDeleted = false, IsVisible = true, CreatedDate = new DateTime(2023, 12, 8), UpdatedDate = new DateTime(2023, 12, 8) },
                new Book { Id = 317, Name = "The Happiness Trap", Format = "Paperback", ISBN = 9781845298258, Price = 8.34M, ImgPath = "/book-covers/Medical/0000004.jpg", CategoryId = 1, AuthorId = 57, BookStar = 3.5, PublicationYear = new DateTime(2023, 12, 8), Description = "No Description AVAILABLE", QuantityInStock = 6, IsDeleted = false, IsVisible = true, CreatedDate = new DateTime(2023, 12, 8), UpdatedDate = new DateTime(2023, 12, 8) },
                new Book { Id = 318, Name = "Man's Search For Meaning", Format = "Paperback", ISBN = 9781846041242, Price = 9.66M, ImgPath = "~/book-covers/Medical/0000005.jpg", CategoryId = 1, AuthorId = 58, BookStar = 2.1, PublicationYear = new DateTime(2023, 12, 8), Description = "No Description AVAILABLE", QuantityInStock = 1, IsDeleted = false, IsVisible = true, CreatedDate = new DateTime(2023, 12, 8), UpdatedDate = new DateTime(2023, 12, 8) },
                new Book { Id = 319, Name = "The Man Who Mistook His Wife for a Hat", Format = "Paperback", ISBN = 9780330523622, Price = 5.92M, ImgPath = "~/book-covers/Medical/0000006.jpg", CategoryId = 1, AuthorId = 59, BookStar = 5.5, PublicationYear = new DateTime(2023, 12, 8), Description = "No Description AVAILABLE", QuantityInStock = 6, IsDeleted = false, IsVisible = true, CreatedDate = new DateTime(2023, 12, 8), UpdatedDate = new DateTime(2023, 12, 8) },
                new Book { Id = 320, Name = "The 8-week Blood Sugar Diet", Format = "Paperback", ISBN = 9781780722405, Price = 8.85M, ImgPath = "~/book-covers/Medical/0000007.jpg", CategoryId = 1, AuthorId = 60, BookStar = 2.1, PublicationYear = new DateTime(2023, 12, 8), Description = "No Description AVAILABLE", QuantityInStock = 4, IsDeleted = false, IsVisible = true, CreatedDate = new DateTime(2023, 12, 8), UpdatedDate = new DateTime(2023, 12, 8) },
                new Book { Id = 321, Name = "The Subtle Art of Not Giving a F*ck", Format = "Paperback", ISBN = 9780062457714, Price = 8.06M, ImgPath = "/book-covers/Medical/0000008.jpg", CategoryId = 1, AuthorId = 61, BookStar = 4.5, PublicationYear = new DateTime(2023, 12, 8), Description = "No Description AVAILABLE", QuantityInStock = 6, IsDeleted = false, IsVisible = true, CreatedDate = new DateTime(2023, 12, 8), UpdatedDate = new DateTime(2023, 12, 8) },
                new Book { Id = 322, Name = "Educated", Format = "Paperback", ISBN = 9780099511021, Price = 8.73M, ImgPath = "~/book-covers/Medical/0000009.jpg", CategoryId = 1, AuthorId = 62, BookStar = 3.5, PublicationYear = new DateTime(2023, 12, 8), Description = "No Description AVAILABLE", QuantityInStock = 8, IsDeleted = false, IsVisible = true, CreatedDate = new DateTime(2023, 12, 8), UpdatedDate = new DateTime(2023, 12, 8) },
                new Book { Id = 323, Name = "The Body Keeps the Score", Format = "Paperback", ISBN = 9780141978611, Price = 10.27M, ImgPath = "~/book-covers/Medical/0000010.jpg", CategoryId = 1, AuthorId = 63, BookStar = 2.1, PublicationYear = new DateTime(2023, 12, 8), Description = "No Description AVAILABLE", QuantityInStock = 2, IsDeleted = false, IsVisible = true, CreatedDate = new DateTime(2023, 12, 8), UpdatedDate = new DateTime(2023, 12, 8) },
                new Book { Id = 324, Name = "Why We Sleep", Format = "Paperback", ISBN = 9780141983769, Price = 9.20M, ImgPath = "/book-covers/Medical/0000011.jpg", CategoryId = 1, AuthorId = 64, BookStar = 3.5, PublicationYear = new DateTime(2023, 12, 8), Description = "No Description AVAILABLE", QuantityInStock = 3, IsDeleted = false, IsVisible = true, CreatedDate = new DateTime(2023, 12, 8), UpdatedDate = new DateTime(2023, 12, 8) },
                new Book { Id = 325, Name = "The Immortal Life of Henrietta Lacks", Format = "Paperback", ISBN = 9780330533447, Price = 6.82M, ImgPath = "~/book-covers/Medical/0000012.jpg", CategoryId = 1, AuthorId = 65, BookStar = 2.1, PublicationYear = new DateTime(2023, 12, 8), Description = "No Description AVAILABLE", QuantityInStock = 5, IsDeleted = false, IsVisible = true, CreatedDate = new DateTime(2023, 12, 8), UpdatedDate = new DateTime(2023, 12, 8) },
                new Book { Id = 326, Name = "Sapiens: A Brief History of Humankind", Format = "Paperback", ISBN = 9780099590087, Price = 10.15M, ImgPath = "~/book-covers/Medical/0000013.jpg", CategoryId = 1, AuthorId = 66, BookStar = 2.1, PublicationYear = new DateTime(2023, 12, 8), Description = "No Description AVAILABLE", QuantityInStock = 7, IsDeleted = false, IsVisible = true, CreatedDate = new DateTime(2023, 12, 8), UpdatedDate = new DateTime(2023, 12, 8) },
                new Book { Id = 327, Name = "Bad Pharma", Format = "Paperback", ISBN = 9780007498086, Price = 7.84M, ImgPath = "/book-covers/Medical/0000014.jpg", CategoryId = 1, AuthorId = 67, BookStar = 3.5, PublicationYear = new DateTime(2023, 12, 8), Description = "No Description AVAILABLE", QuantityInStock = 2, IsDeleted = false, IsVisible = true, CreatedDate = new DateTime(2023, 12, 8), UpdatedDate = new DateTime(2023, 12, 8) },
                new Book { Id = 328, Name = "The Checklist Manifesto", Format = "Paperback", ISBN = 9781846683145, Price = 8.34M, ImgPath = "~/book-covers/Medical/0000015.jpg", CategoryId = 1, AuthorId = 68, BookStar = 2.1, PublicationYear = new DateTime(2023, 12, 8), Description = "No Description AVAILABLE", QuantityInStock = 3, IsDeleted = false, IsVisible = true, CreatedDate = new DateTime(2023, 12, 8), UpdatedDate = new DateTime(2023, 12, 8) },
                new Book { Id = 329, Name = "The Emperor of All Maladies", Format = "Paperback", ISBN = 9780007250929, Price = 8.49M, ImgPath = "~/book-covers/Medical/0000016.jpg", CategoryId = 1, AuthorId = 69, BookStar = 4.5, PublicationYear = new DateTime(2023, 12, 8), Description = "No Description AVAILABLE", QuantityInStock = 5, IsDeleted = false, IsVisible = true, CreatedDate = new DateTime(2023, 12, 8), UpdatedDate = new DateTime(2023, 12, 8) },
                new Book { Id = 330, Name = "The Gene", Format = "Paperback", ISBN = 9780099584574, Price = 12.20M, ImgPath = "/book-covers/Medical/0000017.jpg", CategoryId = 1, AuthorId = 70, BookStar = 2.1, PublicationYear = new DateTime(2023, 12, 8), Description = "No Description AVAILABLE", QuantityInStock = 2, IsDeleted = false, IsVisible = true, CreatedDate = new DateTime(2023, 12, 8), UpdatedDate = new DateTime(2023, 12, 8) }
                );

            #endregion
            #region ApplicationUser
            string roleId = "02174cf0–9412–4cfe-afbf-59f706d72cf6";
            string userId = "341743f0-asd2–42de-afbf-59kmkkmk72cf6";
            modelBuilder.Entity<IdentityRole>().HasData(
                    new IdentityRole
                    {
                        Id = roleId,
                        Name = "SuperAdmin",
                        NormalizedName="SUPERADMIN",
                        ConcurrencyStamp=roleId
                    }
                );
            ApplicationUser user = new ApplicationUser
            {
                UserName = "Abdo",
                NormalizedEmail="TEST@TEST.COM",
                Email="test@test.com",
                NormalizedUserName="ABDO",
                Id=userId,
                EmailConfirmed=true
            };

            PasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = hasher.HashPassword(user, "123@Bdu456");

            modelBuilder.Entity<ApplicationUser>().HasData(
                   user
                );
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = userId,
                RoleId = roleId,
            });
            #endregion
        }
    }
}
