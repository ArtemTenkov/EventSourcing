using Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Enums;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/users")]
    public class UsersController : Controller
    {
        IUserService _testService;
        public UsersController(IUserService testService)
        {   
            _testService = testService;
        }
        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> Post(string userName, string lastName)
        {
            var user = await _testService.RegisterUser(userName, lastName, PositionType.NotSet);
            return new ObjectResult(user)
            {
                StatusCode = StatusCodes.Status201Created
            };
        }

        [HttpPatch]
        [Route("update")]
        public async Task<IActionResult> Put(string newUserName, string lastName)
        {
            var nameUpdated = await _testService.UpdateUserName(newUserName, lastName);            
            return new ObjectResult(nameUpdated)
            {
                StatusCode = StatusCodes.Status200OK
            };
        }
    }
}