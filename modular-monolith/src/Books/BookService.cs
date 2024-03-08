namespace Books;

internal class BookService : IBookService
{
    public List<BookDto> ListBooks()
    {
        return
        [
            new BookDto(Guid.NewGuid(), "The fellowship of the Ring", "Gurame"),
            new BookDto(Guid.NewGuid(), "The two towers", "Myrestin")
        ];
    }
}