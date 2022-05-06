using APICore.API.BasicResponses;
using APICore.Common.DTO.Request;
using APICore.Common.DTO.Response;
using APICore.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace APICore.API.Controllers
{
    [Route("api/author")]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService ?? throw new ArgumentNullException(nameof(authorService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Get Author.
        /// </summary>
        /// <param name="authorID">Author ID.</param>
        [HttpGet()]
        [Route("get-author")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetAuthor(int authorID)
        {
            var result = await _authorService.GetAuthorAsync(authorID);

            return Ok(new ApiOkResponse(result));
        }

        /// <summary>
        /// Add an Author
        /// </summary>
        /// <param name="author">
        /// Setting request object. 
        /// </param>
        [HttpPost]
        [Route("add-author")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddAuthor([FromBody] AuthorRequest author)
        {
            var result = await _authorService.PutAuthorAsync(author);

            var authorResponse = _mapper.Map<AuthorResponse>(result);
            return Ok(new ApiOkResponse(authorResponse));
        }

        /// <summary>
        /// Get All Authors.
        /// </summary>
        [HttpGet()]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetAllCategory()
        {
            var result = await _authorService.GetAllAuthorsAsync();

            var authorResponse = _mapper.Map<IEnumerable<AuthorResponse>>(result);

            return Ok(new ApiOkResponse(authorResponse));
        }

        /// <summary>
        /// Update an Author
        /// </summary>
        /// <param name="author">
        /// <param name="ID">
        /// Author request object and ID. 
        /// </param>
        [HttpPost]
        [Route("update-author")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> UpdateAuthor([FromBody] AuthorRequest author, int ID)
        {
            var result = await _authorService.UpdateAuthorAsync(ID, author);

            var authorResponse = _mapper.Map<AuthorResponse>(result);
            return Ok(new ApiOkResponse(authorResponse));
        }

        /// <summary>
        /// Delete an Author
        /// </summary>
        /// <param name="ID">
        /// Author request the ID. 
        /// </param>
        [HttpPost]
        [Route("delete-author")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> DeleteAuthor(int ID)
        {
            await _authorService.DeleteAuthorAsync(ID);

            return Ok();
        }
    }
}
