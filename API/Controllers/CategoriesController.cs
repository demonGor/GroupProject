using BLL.DTO;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    [Authorize]
    public class CategoriesController : ApiController
    {

        private readonly ICategoryService _categoryService;


        public CategoriesController(ICategoryService categoryService)
        {
            if (categoryService == null)
            {
                throw new ArgumentNullException(nameof(categoryService));
            }
            _categoryService = categoryService;


        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            return Ok(await _categoryService.GetAllCategoriesAsync());
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            if(id<0)
            {
                return BadRequest();
            }
            var res = await _categoryService.GetByIdAsync(id);
            if (res == null)
                return NotFound();
            return Ok(res);
        }
        [Authorize(Roles ="admin")]
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody]CategoryDTO category)
        {
            if(category==null)
            {
                return BadRequest();
                
            }
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _categoryService.CreateAsync(category);

            }
            catch(ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return StatusCode(HttpStatusCode.Created);
        }
    }
}
