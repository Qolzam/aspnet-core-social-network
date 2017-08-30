using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Green.Core.Domain.Circles;
using Green.Core.Domain.Users;
using Green.Services.Authentication;
using Green.Services.Circles;
using Green.Services.Users;
using Green.Web.Framework.Helpers;
using Green.Web.Models.Circles;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Green.Web.Controllers
{
    [Route("api/[controller]")]
    public class CircleController : Controller
    {

		#region Fields

		private readonly IUserService _userService;
		private readonly IAuthenticationService _authService;
		private readonly ICircleService _circleService;
		private readonly IUserCircleService _userCircleService;


		#endregion


		#region Constructor

		public CircleController(
			IUserService userService,
			IUserCircleService userCircleService,
			ICircleService circleService,
			IAuthenticationService authService)
		{
			this._userService = userService;
			this._userCircleService = userCircleService;
			this._circleService = circleService;
			this._authService = authService;
		}

		#endregion

		// GET: api/values
		[HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/circle/id
        [HttpGet("{id}")]
        public string Get(Guid id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost()]
        public IActionResult Post([FromForm]CreateCircleModel createCircleModel)
        {
            if(createCircleModel == null)
            {
                return BadRequest();
            }

            if (string.IsNullOrEmpty(createCircleModel.CircleName))
			{
				ModelState.AddModelError("errors", "Circle name can't be null or empty.");
            }

			if (!ModelState.IsValid)
			{
				// return 422
				return new UnprocessableEntityObjectResult(ModelState);
			}


			User user = _authService.GetAuthenticatedUser();

			if (user == null)
			{
				return Unauthorized();
			}

            Circle newCircle = new Circle(){
                CircleName = createCircleModel.CircleName,
                 FollowersCounter = 0,
                FollowingCounter = 0,
                IsSystem = false 
            };

            _circleService.InsertCircle(newCircle);

            return Ok(new { key = newCircle.Key, circleName = createCircleModel.CircleName });
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
