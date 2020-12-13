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
    [RoutePrefix("api")]
    public class ItemsController : ApiController
    {
        private readonly IItemService _itemService;
        private readonly IBidService _bidService;
        private readonly IUserService _userService;
        public ItemsController(IItemService itemService, IBidService bidService, IUserService userService)
        {
            if (itemService == null)
            {
                throw new ArgumentNullException(nameof(itemService));
            }
            _itemService = itemService;

            if (bidService == null)
            {
                throw new ArgumentNullException(nameof(bidService));
            }
            _bidService = bidService;
            if (userService == null)
            {
                throw new ArgumentNullException(nameof(itemService));
            }
            _userService = userService;
        }

        [AllowAnonymous]
        [Route("Items")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllItems()
        {
            return Ok(await _itemService.GetAllItemsAsync());
        }

        [AllowAnonymous]
        [Route("LiveItems")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllLiveItems()
        {
            return Ok(await _itemService.GetAllLiveItemsAsync());
        }

        [AllowAnonymous]
        [Route("Categories/{CatId}/Items")]
        [HttpGet]
        public async Task<IHttpActionResult> GetByCategory(int CatId)
        { 
            if(CatId<0)
            {
                return BadRequest();
            }
            return Ok(await _itemService.GetAllItemsInGivenCategoryByCategoryIdAsync(CatId));
        }

        [Authorize]
        [Route("MyItems")]
        [HttpGet]
        public async Task<IHttpActionResult> GetForCurrentUser()
        {
            var UserName = this.User.Identity.Name;
            var user= await _userService.FindByNameAsync(UserName);
            if(user==null)
            {
                return NotFound();
            }
            return Ok(await _itemService.GetAllItemsForGivenUserAsync(user.Id));
        }

        [AllowAnonymous]
        [Route("Items/{search}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetByTitle(string search)
        {
            if (search == null)
            {
                return BadRequest();
            }
            return Ok(await _itemService.SearchByTitleAsync(search));
        }

        [Authorize]
        [Route("ItemsBy/{id}")]
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            var res = await _itemService.GetByIdAsync(id);
            if (res == null)
                return NotFound();
            return Ok(res);
        }
        [Authorize]
        [Route("Items/{id}")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            try
            {
                await _itemService.DeleteAsync(id);
            }
            catch
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
            return Ok();


        }


        [AllowAnonymous]
        [Route("Items/{ItemId}/HighestBid")]
        [HttpGet]
        public async Task<IHttpActionResult> GetHighestAmountForItem(int ItemId)
        {
            if (ItemId < 0)
            {
                return BadRequest();
            }
            var res = await _bidService.GetHighestBidAmountForGivenItemAsync(ItemId);
            if (res == null)
                return NotFound();
            return Ok(res);
        }


        [Authorize]
        [Route("Items")]
        [HttpPost]
        public async Task<IHttpActionResult> CreateItem([FromBody]ItemDTO item)
        {
            if (item == null)
            {
                return BadRequest();

            }
            var UserName = this.User.Identity.Name;
            var user = await _userService.FindByNameAsync(UserName);
            if (user == null)
            {
                return NotFound();
            }
            item.UserId = user.Id;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _itemService.CreateAsync(item);

            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return StatusCode(HttpStatusCode.Created);
        }

        [Authorize]
        [Route("Bids")]
        [HttpPost]
        public async Task<IHttpActionResult> CreateBid([FromBody]BidDTO bid)
        {
            if (bid == null)
            {
                return BadRequest();

            }
            var UserName = this.User.Identity.Name;
            var user = await _userService.FindByNameAsync(UserName);
            if (user == null)
            {
                return NotFound();
            }
            bid.UserId = user.Id;
            bid.MadeOn = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _bidService.CreateAsync(bid);

            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return StatusCode(HttpStatusCode.Created);
        }

        [HttpPut]
        [Route("Items/{id}")]
        [Authorize]
        public async Task<IHttpActionResult> ChangeItem(int id, [FromBody] ItemDTO item)

        {

            if (item == null)

                return BadRequest();

            try
            {
               item.Id = id;

           if (!ModelState.IsValid)
             {
               return BadRequest(ModelState);
             }

                await _itemService.UpdateAsync(item);
            }

            catch (ArgumentNullException exc)
            {
                return BadRequest(exc.Message);
            }
            catch (Exception exc)
            {

                return BadRequest(exc.Message);
            }

            return StatusCode(HttpStatusCode.Accepted);

        }

    }
}
