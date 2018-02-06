using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Enums;
using System.Threading.Tasks;
using User.Application;

namespace ServerlessUserApi.Controllers
{
    [Produces("application/json")]
    [Route("api/users")]
    public class UsersController : Controller
    {
        IUserService _userService;
        public UsersController(IUserService testService)
        {
            _userService = testService;
        }

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> Add(string userName, string lastName)
        {
            var user = await _userService.RegisterUser(userName, lastName, PositionType.NotSet);
            return new ObjectResult(user)
            {
                StatusCode = StatusCodes.Status201Created
            };
        }

        [HttpPatch]
        [Route("update")]
        public async Task<IActionResult> Update(string newUserName, string lastName)
        {
            var success = await _userService.UpdateUserName(newUserName, lastName);
            return new ObjectResult(success)
            {
                StatusCode = success ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError
            };
        }

        [HttpPut]
        [Route("promote")]
        public async Task<IActionResult> Promote(string lastName, int newPosition)
        {
            var position = PositionType.Parse(newPosition);
            var promotionError = await _userService.PromoteUser(lastName, position);
            return new ObjectResult(promotionError)
            {
                StatusCode = string.IsNullOrEmpty(promotionError) ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError
            };
        }


        [HttpDelete]
        [Route("unregister")]
        public async Task<IActionResult> Unregister(string lastName)
        {
            var updateError = await _userService.UnregisterUser(lastName);
            return new ObjectResult(updateError)
            {
                StatusCode = string.IsNullOrEmpty(updateError) ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError
            };
        }
    }
}