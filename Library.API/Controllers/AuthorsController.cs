using Library.Application.Dtos.AuthorDtos;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var authors = await _authorService.GetAllAsync();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto?>> GetById(int id)
        {
            var author = await _authorService.GetByIdAsync(id);
            if (author is null) return NotFound();
            return Ok(author);
        }

        [HttpPost]
        public async Task<ActionResult<AuthorDto>> Create([FromBody] AuthorDto authorDto)
        {
            if (authorDto is null) return BadRequest();

            var createdAuthor = await _authorService.AddAsync(authorDto); 
            return CreatedAtAction(nameof(GetById), new { id = createdAuthor.Id }, createdAuthor);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<AuthorDto>> Update(int id, [FromBody] AuthorDto authorDto)
        {
            if(authorDto is null || id != authorDto.Id) return BadRequest();
            await _authorService.UpdateAsync(authorDto);
            return Ok(authorDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _authorService.DeleteAsync(id);
            return NoContent();
        }
    }
}
