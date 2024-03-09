using FastEndpoints;
using FastEndpoints.Testing;
using Xunit.Abstractions;
using Books.Endpoints;
using FluentAssertions;

namespace Books.Tests.Endpoints;

public class BookList(Fixture fixture, ITestOutputHelper outputHelper) : TestClass<Fixture>(fixture, outputHelper)
{
  [Fact]
  public async Task ReturnsThreeBooksAsync()
  {
    var testResult = await fixture.Client.GETAsync<List, ListBooksReponse>();
    testResult.Response.EnsureSuccessStatusCode();
    testResult.Result.Books.Count.Should().Be(3);
  }
}

public class BookGetById(Fixture fixture, ITestOutputHelper outputHelper) : TestClass<Fixture>(fixture, outputHelper)
{
  [Theory]
  [InlineData("1904b531-53c9-4376-8da8-3122aa436801", "The Two Towers")]
  public async Task ReturnsExpectedBookGivenId(string validId, string expectedTitle)
  {
    Guid id = Guid.Parse(validId);
    var request = new GetBookByIdRequest() { Id = id };
    var testResult = await fixture.Client.GETAsync<GetById, GetBookByIdRequest, BookDto>(request);
    testResult.Response.EnsureSuccessStatusCode();
    testResult.Result.Title.Should().Be(expectedTitle);
  }
}
