using FluentValidation.Results;

namespace MP.Core.Application.Services
{
    public class ResultService
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public ICollection<ErrorValidation> Errors { get; set; }

        public static ResultService RequestError(string message, ValidationResult validationResult)
        {
            var result = new ResultService()
            {
                IsSuccess = false,
                Message = message,
                Errors = validationResult.Errors.Select(x => new ErrorValidation { Field = x.PropertyName, Message = x.ErrorMessage }).ToList(),
            };

            return result;
        }

        public static ResultService<T> RequestError<T>(string message, ValidationResult validationResult)
        {
            var result = new ResultService<T>()
            {
                IsSuccess = false,
                Message = message,
                Errors = validationResult.Errors.Select(x => new ErrorValidation { Field = x.PropertyName, Message = x.ErrorMessage }).ToList()
            };

            return result;
        }

        public static ResultService Fail(string message)
        {
            var result = new ResultService()
            {
                IsSuccess = false,
                Message = message
            };

            return result;
        }

        public static ResultService<T> Fail<T>(string message)
        {
            var result = new ResultService<T>()
            {
                IsSuccess = false,
                Message = message
            };

            return result;
        }

        public static ResultService Ok(string message)
        {
            var result = new ResultService()
            {
                IsSuccess = true,
                Message = message
            };

            return result;
        }

        public static ResultService<T> Ok<T>(T data)
        {
            var result = new ResultService<T>()
            {
                IsSuccess = true,
                Data = data
            };

            return result;
        }
    }

    public class ResultService<T> : ResultService
    { 
        public T Data { get; set; }
    }
}
