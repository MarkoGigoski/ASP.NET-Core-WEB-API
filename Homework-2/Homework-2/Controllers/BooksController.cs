using Homework_2.DB;
using Homework_2.DTOs;
using Homework_2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace Homework_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        // Gett All
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            try
            {
                var books = StaticBD.Books;

                return Ok(books);

            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error happend please try again");
            }
        }

        // Get buy Id
        [HttpGet("{id}")]
        public IActionResult GetBookBuyId(int id)
        {
            try
            {
                var books = StaticBD.Books;
                var book = books.Where(x => x.Id == id).FirstOrDefault();

                if(id == null)
                {
                    return BadRequest($"Id number is a required field");
                }

                if(id <= 0 || id > 6)
                {
                    return NotFound($"A Note with Id {id} was not found");
                }

                return Ok(book);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error happend please try again");
            }
        }

        // Get buy Filters
        [HttpGet("filter")]
        public IActionResult GetBuyAuthorAndTitle(int? id, string? author, string? title)
        {
            try
            {
                var books = StaticBD.Books;

                // Author filter
                if (!string.IsNullOrEmpty(author))
                {
                    books = books.Where(x => x.Author.Contains(author)).ToList();
                }

                // Title filter
                if (!string.IsNullOrEmpty(title))
                {
                    books = books.Where(x => x.Title.Contains(title)).ToList();
                }

                // Id filter
                if (id.HasValue)
                {
                    if(id.Value == 0 || id.Value > 6)
                    {
                        return BadRequest("The id has values between 1 - 6");
                    }

                    books = books.Where(x => x.Id == id.Value).ToList();
                }

                return Ok(books);

            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error happend please try again");
            }
        }
    }
}
