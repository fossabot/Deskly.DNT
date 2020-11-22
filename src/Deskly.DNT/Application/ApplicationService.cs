using Deskly.DNT.Dependency;
using Deskly.DNT.Functional;
using Deskly.DNT.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deskly.DNT.Application
{
    public interface IApplicationService : IScopedDependency
    {
    }

    public abstract class ApplicationService : IApplicationService
    {
        protected static Result Ok() => Result.Ok();
        protected static Result Fail(string message) => Result.Fail(message);

        protected static Result Fail(string message, IEnumerable<ValidationFailure> failures) =>
            Result.Fail(message, failures);

        protected static Result<T> Ok<T>(T value) => Result.Ok(value);
        protected static Result<T> Fail<T>(string message) => Result.Fail<T>(message);

        protected static Result<T> Fail<T>(string message, IEnumerable<ValidationFailure> failures) =>
            Result.Fail<T>(message, failures);
    }

}
