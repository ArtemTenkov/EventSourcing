namespace SharedKernel.Enums
{
    public class TransactionStatusCode : FieldType<string>
    {
        public static TransactionStatusCode NotSet => new TransactionStatusCode("NA", "Not set");
        public static TransactionStatusCode Processing => new TransactionStatusCode("PR", "In processing state");
        public static TransactionStatusCode Void => new TransactionStatusCode("VD", "Transaction was voided");
        public static TransactionStatusCode Settled => new TransactionStatusCode("ST", "Transaction was settled");
        public TransactionStatusCode Parse(string transactionStatus)
        {
            if (string.IsNullOrEmpty(transactionStatus)) return NotSet;

            if(transactionStatus == Processing.Value)                
                    return Processing;

            if (transactionStatus == Void.Value)
                return Void;

            if (transactionStatus == Settled.Value)
                return Settled;

            return NotSet;

        }

        protected TransactionStatusCode(string value, string description) : base(value, description)
        {
        }
    }
}
