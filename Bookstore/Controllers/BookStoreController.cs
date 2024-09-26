[ApiController]
[Route("api/[controller]")]
public class BookStoreController : ControllerBase
{
    private readonly IBookStore _bookStore;

    public BookStoreController(IBookStore bookStore)
    {
        _bookStore = bookStore;
    }

    [HttpPost]
    public IActionResult CreateBook(Book book)
    {
        _bookStore.CreateBook(book);
        return CreatedAtAction(nameof(GetOneBook), new { id = book.Id }, book);
    }

    [HttpGet]
    public IActionResult GetAllBooks()
    {
        return Ok(_bookStore.GetAllBooks());
    }

    [HttpGet("{id}")]
    public IActionResult GetOneBook(int id)
    {
        var book = _bookStore.GetOneBook(id);
        if (book == null)
        {
            return NotFound();
        }
        return Ok(book);
    }

    [HttpGet("requested")]
    public IActionResult GetAllRequestedBooks()
    {
        return Ok(_bookStore.GetAllRequestedBooks());
    }

    [HttpPatch("{id}/request")]
    public IActionResult RequestBook(int id)
    {
        _bookStore.RequestBook(id);
        return NoContent();
    }
}