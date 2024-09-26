public class BookStoreRepository : IBookStore
{
    private readonly List<Book> _books = new List<Book>();

    public void CreateBook(Book book)
    {
        _books.Add(book);
    }

    public IEnumerable<Book> GetAllBooks()
    {
        return _books;
    }

    public Book GetOneBook(int id)
    {
        return _books.FirstOrDefault(b => b.Id == id);
    }

    public IEnumerable<Book> GetAllRequestedBooks()
    {
        return _books.Where(b => b.IsBookRequested);
    }

    public void RequestBook(int id)
    {
        var book = GetOneBook(id);
        if (book != null)
        {
            book.IsBookRequested = true;
        }
    }
}