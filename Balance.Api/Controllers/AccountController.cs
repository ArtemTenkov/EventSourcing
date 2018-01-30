using System;
using System.Threading.Tasks;
using Balance.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Balance.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [Route("unlock")]
        [HttpPost]
        public async Task UnlockAccount(Guid accountId)
        {
            await _accountService.UnlockAccount(accountId);
        }

        [Route("all")]
        [HttpGet]
        public async Task<IActionResult> GetAllTransactions(Guid userId)
        {
            var transactions = await _accountService.GetAllTransactions(userId);
            return new ObjectResult(transactions)
            {
                StatusCode = StatusCodes.Status200OK
            };
        }
    }
}