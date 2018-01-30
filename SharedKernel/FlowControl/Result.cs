using SharedKernel.Enums;
using System;

namespace SharedKernel.FlowControl
{
    public class Result
    {
        public bool IsSuccess { get; }
        public ErrorType ErrorType { get; private set; }
        public string ErrorMessage { get; protected set; }

        protected Result(bool isSuccess, ErrorType errorType)
        {
            IsSuccess = isSuccess;
            ErrorType = errorType;
        }

        protected Result(bool isSuccess, ErrorType errorType, string errorMessage)
            : this(isSuccess, errorType)
        {
            ErrorMessage = errorMessage;
        }

        public static Result Fail(ErrorType errorType)
        {
            return new Result(false, errorType);
        }

        public static Result Fail(ErrorType errorType, string errorMessage)
        {
            return new Result(false, errorType, errorMessage);
        }

        public static Result<T> Fail<T>(ErrorType errorType, string message)
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

        protected internal Result(T value, bool isSuccess, ErrorType errorType, string errorMessage)
            : base(isSuccess, errorType)
        {
            Value = value;
            ErrorMessage = errorMessage;
        }
    }
}
