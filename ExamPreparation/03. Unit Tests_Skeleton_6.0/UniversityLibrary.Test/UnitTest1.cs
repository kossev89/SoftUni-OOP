namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using System.Text;

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddTextBookToLibrary_TestIfInvenotyNumberIncreasesCorrectly()
        {
            UniversityLibrary library = new();
            TextBook book = new("Game Of Thrones", "G. Marting", "Fantasy");
            TextBook book2 = new("Game Of Bones", "G. Marting", "Fantasy");
            TextBook book3 = new("Game Of Mones", "G. Marting", "Fantasy");
            library.AddTextBookToLibrary(book);

            int expectedResult = 3;
            int actualResult = book3.InventoryNumber;

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void AddTextBookToLibrary_TestReturnsCorrectResult()
        {
            UniversityLibrary library = new();
            TextBook book = new("Game Of Thrones", "G. Marting", "Fantasy");
            library.AddTextBookToLibrary(book);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Book: {book.Title} - {book.InventoryNumber}");
            sb.AppendLine($"Category: {book.Category}");
            sb.AppendLine($"Author: {book.Author}");

            string expectedResult = sb.ToString().TrimEnd();
            string actualResult = book.ToString();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void AddTextBookToLibrary_AddsBookToList()
        {
            UniversityLibrary library = new();
            TextBook book = new("Game Of Thrones", "G. Marting", "Fantasy");
            library.AddTextBookToLibrary(book);

            int expectedResult = 1;
            int actualResult = library.Catalogue.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void LoanTextBook_WhenBookIsNotReturned()
        {
            UniversityLibrary library = new();
            TextBook book = new("Game Of Thrones", "G. Marting", "Fantasy");
            library.AddTextBookToLibrary(book);
            book.Holder = "Gosho";

            string expectedResult = $"Gosho still hasn't returned {book.Title}!";
            string actualResult = library.LoanTextBook(1, "Gosho");

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void LoanTextBook_WhenBookIsReturned()
        {
            UniversityLibrary library = new();
            TextBook book = new("Game Of Thrones", "G. Marting", "Fantasy");
            library.AddTextBookToLibrary(book);
            book.Holder = "Pesho";

            string expectedResult = $"{book.Title} loaned to Gosho.";
            string actualResult = library.LoanTextBook(1, "Gosho");

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void ReturnTextBook_ReturnsCorrectValue()
        {
            UniversityLibrary library = new();
            TextBook book = new("Game Of Thrones", "G. Marting", "Fantasy");
            library.AddTextBookToLibrary(book);
            library.LoanTextBook(1, "Gosho");

            string actualResult = library.ReturnTextBook(1);
            string expectedResult= $"{book.Title} is returned to the library.";

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void ReturnTextBook_SetsBookHolderToEmpty()
        {
            UniversityLibrary library = new();
            TextBook book = new("Game Of Thrones", "G. Marting", "Fantasy");
            library.AddTextBookToLibrary(book);
            library.LoanTextBook(1, "Gosho");
            library.ReturnTextBook(1);

            string expectedResult = string.Empty;
            string actualResult = book.Holder;

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void ConstructorWorksProperly()
        {
            UniversityLibrary library = new();

            int expectedResult = 0;
            int actualResult = library.Catalogue.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}