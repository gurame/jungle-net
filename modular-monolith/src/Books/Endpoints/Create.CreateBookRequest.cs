namespace Books.Endpoints;

public record CreateBookRequest(Guid? Id, string Title, string Author, decimal Price);
