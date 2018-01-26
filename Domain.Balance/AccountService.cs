using SharedKernel.ValueObjects;
using System.Threading.Tasks;

namespace Domain.Balance
{
    public interface IBalanceService
    {
        Task PayRegistrationBonus(AccountRoot accountRoot);
    }
    public class AccountService : IBalanceService
    {
        public async Task PayRegistrationBonus(AccountRoot accountRoot)
        {
            var bonusFee = Amount.Create(1000);
            accountRoot.Deposit(bonusFee);            
        }

        private const string expectedCode = "code";
        private const string wrong3TimesCode = "3code";
        public async Task ConfirmOwnerIdentity(string verificationCode, AccountRoot accountRoot)
        {
            switch (verificationCode)
            {   
                case expectedCode:
                    accountRoot.VerifyIdentity();
                    break;
                case wrong3TimesCode:
                    accountRoot.Lock("Incorrect code specified 3 times");
                    break;
            }            
        }
    }
}
