namespace SharedKernel.Enums
{
    public class ErrorType : FieldType<string>
    {
        public static ErrorType NotSet => new ErrorType("NA", "Not set");
        public static ErrorType GenericError => new ErrorType("GenericError", "Common error type");
        public static ErrorType DatabaseError => new ErrorType("DatabaseError", "Database error occured");
        protected ErrorType(string value, string description) : base(value, description)
        {
        }
    }
}
