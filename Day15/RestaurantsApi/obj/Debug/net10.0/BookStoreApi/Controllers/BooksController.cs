using BookStoreApi.Models;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Mvc;
namespace BookStoreApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly BookService _bookService;
    public BooksController(BookService bookService)
    {
        _bookService = bookService;
    }
    [HttpGet]
    public ActionResult<List<Book>> Get()
    {
        return _bookService.Get();
    }
    [HttpPost]
    public IActionResult Create(Book book)
    {
        _bookService.Create(book);
        return Ok("Book Added Successfully");
    }
}