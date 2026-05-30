using System;
using System.Collections.Generic;
using System.Text;

namespace PalletIQ.SharedKernel.Results
{
    public class Result
    {
        protected Result(bool isSuccess, Error error)
        {
           if(isSuccess && error != Error.None)
           {
               throw new InvalidOperationException("A successful result cannot have an error.");
           }
           if(!isSuccess && error == Error.None)
           {
                throw new InvalidOperationException("A failed result must have an error.");
           }
              IsSuccess = isSuccess;
              Error = error;
        }

        // Properties

        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; }

        //factory methods
        public static Result Success() => new(true, Error.None);
        public static Result Failure(Error error) => new(false, error);

        public static Result<T> Success<T>(T value) => new(value, true, Error.None);
        public static Result<T> Failure<T>(Error error) => new(default!, false, error);

        //implicit operators
        public static implicit operator Result(Error error) => Failure(error);



    }

    public class Result<T> : Result
    {
        private readonly T? _value;
        protected internal Result(T value, bool isSuccess, Error error) : base(isSuccess, error)
        {
            _value = value;
        }

        public T Value => IsSuccess ? _value! : throw new InvalidOperationException($"Cannot access the value of a failed result. Error: {Error.Code}");

        public static implicit operator Result<T>(T value) => Success(value);

        public static implicit operator Result<T>(Error error) => Failure<T>(error);



        public Result<TNext> Map<TNext>(Func<T, TNext> mapper)
        {
            return IsSuccess ? Success(mapper(Value)) : Failure<TNext>(Error);
        }

        public async Task<Result<TNext>> MapAsync<TNext>(Func<T, Task<TNext>> mapper)
        {
            return IsSuccess ? Success(await mapper(Value)) : Failure<TNext>(Error);
        }

    }


}
