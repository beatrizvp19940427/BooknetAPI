using APICore.API.BasicResponses;
using APICore.Common.DTO.Request;
using APICore.Common.DTO.Response;
using APICore.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace APICore.API.Controllers
{
    [Route("api/category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Get Category.
        /// </summary>
        /// <param name="catID">Category ID.</param>
        [HttpGet()]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetCategory(int catID)
        {
            var result = await _categoryService.GetCategoryAsync(catID);

            return Ok(new ApiOkResponse(result));
        }
        /// <summary>
        /// Add a Category
        /// </summary>
        /// <param name="category">
        /// Setting request object. Include key and value. Key is unique in database.
        /// </param>
        [HttpPost]
        [Route("add-category")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddCategory([FromBody] CategoryRequest category)
        {
            var result = await _categoryService.PutCategoryAsync(category);

            var categoryResponse = _mapper.Map<CategoryResponse>(result);
            return Ok(new ApiOkResponse(categoryResponse));
        }
    }

   
}
