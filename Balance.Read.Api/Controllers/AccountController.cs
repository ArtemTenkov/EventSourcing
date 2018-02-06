using Balance.Read.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Balance.Read.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        IReadAccountService _readAccountService;
        public AccountController(IReadAccountService readAccountService)
        {
            _readAccountService = readAccountService;
        }
        [Route("transactions")]
        [HttpGet]
        public async Task<IActionResult> GetAllTransactions(Guid userId)
        {
            var transactions = await _readAccountService.GetAllTransactions(userId);
            return new ObjectResult(transactions)
            {
                StatusCode = StatusCodes.Status200OK
            };
        }
    }
}