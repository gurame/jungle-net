using FastEndpoints;

namespace Books;

internal class ListBooksEnpoint(IBookService bookservice): EndpointWithoutRequest<ListBooksReponse>
{
    private readonly IBookService _bookService = bookservice;
    public override void Configure()
    {
        Get("/books");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await SendAsync(new ListBooksReponse()
        {
            Books = _bookService.ListBooks()
        });
    }
}