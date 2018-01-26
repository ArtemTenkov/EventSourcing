using System;

namespace SharedKernel.FlowControl
{
    public class Result
    {
        public bool IsSuccess { get; }
        public Enum ErrorType { get; private set; }
        public string ErrorMessage { get; protected set; }

        protected Result(bool isSuccess, Enum errorType)
        {
            IsSuccess = isSuccess;
            ErrorType = errorType;
        }

        protected Result(bool isSuccess, Enum errorType, string errorMessage)
            : this(isSuccess, errorType)
        {
            ErrorMessage = errorMessage;
        }

        public static Result Fail(Enum errorType)
        {
            return new Result(false, errorType);
        }

        public static Result Fail(Enum errorType, string errorMessage)
        {
            return new Result(false, errorType, errorMessage);
        }

        public static Result<T> Fail<T>(Enum errorType, string message)
        {
            return new Result<T>(default(T), false, errorType, message);
        }

        public static Result Ok()
        {
            return new Result(true, null);
        }

        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>(value, true, null, null);
        }
    }

    public class Result<T> : Result
    {
        public T Value { get; }

        protected internal Result(T value, bool isSuccess, Enum errorType, string errorMessage)
            : base(isSuccess, errorType)
        {
            Value = value;
            ErrorMessage = errorMessage;
        }
    }
}
