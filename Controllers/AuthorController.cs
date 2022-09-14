using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Demo.Command;
using WebAPI_Demo.DbContexts;
using WebAPI_Demo.Entities;
using WebAPI_Demo.Models;
using WebAPI_Demo.Queries;

namespace WebAPI_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly ISender _sender;

        public AuthorController(ISender sender)
        {
            _sender = sender ?? throw new ArgumentNullException(nameof(sender));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAuthors()
        {
            var authors = await _sender.Send(new GetAuthorsQuery());
            if(authors == null)
            {
                return NoContent();
            }
            return Ok(authors);
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor([FromBody] CreateAuthorDto author)
        {
            if(author == null)
            {
                return BadRequest();
            }

            await _sender.Send(new AddAuthorCommand(author));
            return NoContent();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AuthorDto>>GetAuthorById(Guid id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            var author = await _sender.Send(new GetAuthorByIdQuery(id));
            if(author == null)
            {
                return NotFound("Data is not available.");
            }
            return Ok(author);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAuthor(Guid id,[FromBody] UpdateAuthorDto author)
        {
            if (author == null)
            {
                return BadRequest();
            }
            await _sender.Send(new UpdateAuthorCommand(author));
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAuthor(Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            await _sender.Send(new DeleteAuthorCommand(id));
            return NoContent();
        }
    }
}
