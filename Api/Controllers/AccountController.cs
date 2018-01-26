using System;
using System.Threading.Tasks;
using Application;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
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
    }
}