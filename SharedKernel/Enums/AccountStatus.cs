namespace SharedKernel.Enums
{
    public class AccountStatus : FieldType<string>
    {
        public static AccountStatus NotSet => new AccountStatus("NA", "Not set");
        public static AccountStatus Active => new AccountStatus("A", "Active");
        public static AccountStatus Pending => new AccountStatus("P", "Awaiting for approval");
        public static AccountStatus Locked => new AccountStatus("L", "Locked");
        public AccountStatus Parse(string accountStatus)
        {
            if (string.IsNullOrEmpty(accountStatus)) return NotSet;

            if (accountStatus == Active.Value)
                return Active;

            if (accountStatus == Pending.Value)
                return Pending;

            if (accountStatus == Locked.Value)
                return Locked;

            return NotSet;

        }
        protected AccountStatus(string value, string description) : base(value, description)
        {
        }
    }
}
