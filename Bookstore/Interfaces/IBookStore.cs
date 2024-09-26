public interface IBookStore
{
    void CreateBook(Book book);
    IEnumerable<Book> GetAllBooks();
    Book GetOneBook(int id);
    IEnumerable<Book> GetAllRequestedBooks();
    void RequestBook(int id);
}