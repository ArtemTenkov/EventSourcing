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

        [Route("getaccountid")]
        [HttpGet]
        public async Task<Guid> GetAccountIdByUserId(Guid userId)
        {
            return await _accountService.GetAccountIdByUserId(userId);
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
    }
}