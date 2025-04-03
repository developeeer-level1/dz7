namespace TrashHw
{
    public class Book : IDisposable
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public int Pages { get; set; }

        public Book(string title, string author, int year, int pages)
        {
            Title = title;
            Author = author;
            Year = year;
            Pages = pages;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Title: {Title}, Author: {Author}, Year: {Year}, Pages: {Pages}");
        }

        public void Dispose()
        {
            Console.WriteLine($"Book \"{Title}\" released (Dispose)");
        }

        ~Book()
        {
            Console.WriteLine($"Finalizer called for book \"{Title}\"");
        }
    }
    public class Library : IDisposable
    {
        private List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void ShowBooks()
        {
            Console.WriteLine("Books in the library:");
            foreach (var book in books)
            {
                book.DisplayInfo();
            }
        }

        public void Dispose()
        {
            Console.WriteLine("Library is closing, books are being released...");
            books.Clear();
        }
    }
    public class FileResource : IDisposable
    {
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public string FilePath { get; set; }

        public FileResource(string fileName, long fileSize, string filePath)
        {
            FileName = fileName;
            FileSize = fileSize;
            FilePath = filePath;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"File: {FileName}, Size: {FileSize} bytes, Path: {FilePath}");
        }

        public void Dispose()
        {
            Console.WriteLine($"File {FileName} closed");
        }

        ~FileResource()
        {
            Console.WriteLine($"Finalizer called for file {FileName}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine("=== Book Testing ===");
            using (Book book1 = new Book("1984", "George Orwell", 1949, 328))
            {
                book1.DisplayInfo();
            }

            Console.WriteLine("\n=== Library Testing ===");
            using (Library library = new Library())
            {
                library.AddBook(new Book("The Master and Margarita", "Mikhail Bulgakov", 1966, 480));
                library.AddBook(new Book("Crime and Punishment", "Fyodor Dostoevsky", 1866, 671));
                library.ShowBooks();
            }

            Console.WriteLine("\n=== File Testing ===");
            using (FileResource file = new FileResource("document.txt", 1024, "C:/files/document.txt"))
            {
                file.DisplayInfo();
            }

            Console.WriteLine("\nTesting completed");
        }
    }
}
