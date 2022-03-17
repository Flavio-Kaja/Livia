namespace Livia.Domain.Models.Base
{
    using Task = System.Threading.Tasks.Task;
    public class Result : BaseResult
    {
        #region "Static constructors"

        public static Result Ok()
        {
            return new Result();
        }

        public static Result<TValue> Ok<TValue>(TValue value)
        {
            return new Result<TValue>(value);
        }

        public static Result Fail(Message message)
        {
            return new Result()
                .WithError(message);
        }

        public static Result Fail(string message)
        {
            return new Result()
                .WithError(message);
        }

        public static Result Fail(string key, string? message)
        {
            return new Result()
                .WithError(key, message);
        }

        public static Result<TValue> Fail<TValue>(Message message)
        {
            return new Result<TValue>()
                .WithError(message);
        }

        public static Result<TValue> Fail<TValue>(string message)
        {
            return new Result<TValue>()
                .WithError(message);
        }

        public static Result<TValue> Fail<TValue>(string key, string? message)
        {
            return new Result<TValue>()
                .WithError(key, message);
        }

        public static Result<TValue> Fail<TValue>(TValue value, string key, string message)
        {
            var result = new Result<TValue>();
            result.WithError(key, message);
            result.Value = value;
            return result;
        }

        #endregion

        #region Async Overloads

        public static Task<Result> OkAsync()
        {
            return Task.FromResult(new Result());
        }

        public static Task<Result<TValue>> OkAsync<TValue>(TValue value)
        {
            return Task.FromResult(new Result<TValue>(value));
        }

        public static Task<Result> FailAsync(Message message)
        {
            return Task.FromResult(new Result()
                .WithError(message));
        }

        public static Task<Result> FailAsync(string message)
        {
            return Task.FromResult(new Result()
                .WithError(message));
        }

        public static Task<Result> FailAsync(string key, string? message)
        {
            return Task.FromResult(new Result()
                .WithError(key, message));
        }

        public static Task<Result<TValue>> FailAsync<TValue>(Message message)
        {
            return Task.FromResult(new Result<TValue>()
                .WithError(message));
        }

        public static Task<Result<TValue>> FailAsync<TValue>(string message)
        {
            return Task.FromResult(new Result<TValue>()
                .WithError(message));
        }

        public static Task<Result<TValue>> FailAsync<TValue>(string key, string? message)
        {
            return Task.FromResult(new Result<TValue>()
                .WithError(key, message));
        }

        #endregion
    }

    public class Result<TValue> : BaseValueResult<TValue>
    {
        public Result()
        {
        }

        public Result(TValue value)
        {
            Value = value;
        }
    }
    public abstract class BaseValueResult<TValue> : BaseResult
    {
        public TValue Value { get; set; }
    }
}
