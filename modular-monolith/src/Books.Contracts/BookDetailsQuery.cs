using Ardalis.Result;
using MediatR;

namespace Books.Contracts;

public record BookDetailsQuery(Guid BookId) : IRequest<Result<BookDetailsResponse>>;

