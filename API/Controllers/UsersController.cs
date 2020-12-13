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
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;
       

        public UsersController(IUserService userService)
        {
            if (userService == null)
            {
                throw new ArgumentNullException(nameof(userService));
            }
            _userService = userService;

           
        }
        [Authorize(Roles ="admin")]
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            return Ok(await _userService.GetAllAsync());
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            var res = await _userService.FindByIdAsync(id);
            if (res == null)
                return NotFound();
            return Ok(res);
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IHttpActionResult> Get(string name)
        {
            
            var res = await _userService.FindByNameAsync(name);
            if (res == null)
                return NotFound();
            return Ok(res);
        }
        
    }
}
