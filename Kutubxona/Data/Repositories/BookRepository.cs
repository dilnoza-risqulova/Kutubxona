using Kutubxona.Data.IRepositories;
using Kutubxona.Domain.Configuration;
using Kutubxona.Domain.Entities;

namespace Kutubxona.Data.Repositories;

public class BookRepository : IBookRepository
{
    private string path;
    public BookRepository()
    {
        this.path = BookPathHelper.BookPath;
        var txt=File.ReadAllText(path);
        if (string.IsNullOrEmpty(txt))
        {
            File.WriteAllText(path, "[]");
        }
    }
    public async Task<bool> DropAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Book> InsertAsync(Book book)
    {
        List<Book> books = SelectAllAsync().Result.ToList;
        books.Add(book);
        
        var json = JsonConvert.SerializeObject(books, Formatting.Indented);
        await File.WriteAllTextAsync(path, json);

        return book;
    }

    public Task<Book> ModifyAsync(Book book)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Book>> SelectAllAsync()
    {
        var text = await File.ReadAllTextAsync(path);
        var books = JsonConvert.DeserializeObject<Enumerable<BookRepository>>(text);

        return book;
    }

    public Task<Book> SelectByAsync(int id)
    {
        throw new NotImplementedException();
    }
}
