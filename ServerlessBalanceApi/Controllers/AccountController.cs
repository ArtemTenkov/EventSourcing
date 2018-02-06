using Balance.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ServerlessBalanceApi.Controllers
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

        [Route("deposit")]
        [HttpPost]
        public async Task Deposit(Guid accountId, decimal amount)
        {
            await _accountService.Deposit(accountId, amount);
        }

        [Route("withdraw")]
        [HttpPost]
        public async Task Withdraw(Guid accountId, decimal amount)
        {
            await _accountService.Withdraw(accountId, amount);
        }

        [Route("accounts")]
        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
            var ids = await _accountService.GetAllAccountIds();
            return new ObjectResult(ids)
            {
                StatusCode = StatusCodes.Status200OK
            };
        }

        [Route("transactions")]
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
