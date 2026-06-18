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
    }
    public Task<bool> DropAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Book> InsertAsync(Book book)
    {
        var text = $"{book.Id}|{book.Title}|{book.Author}|{book.Year}|{book.UpdatedAt}|{book.CreatedAt}\n";
        File.AppendAllText(path, text);

        return book;
    }

    public Task<Book> ModifyAsync(Book book)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Book>> SelectAllAsync()
    {
        var books = File.ReadAllLines(path);
        var ls = new List<Book>();

        foreach (var item in books)
        {
            if (string.IsNullOrEmpty(item))
                continue;

            var bookline = item.Split("|");

            var book = new Book
            {
                Id = int.Parse(bookline[0]),
                Title = bookline[1],
                Author = bookline[2],
                Year = int.Parse(bookline[3]),
                UpdatedAt = DateTime.Parse(bookline[4]),
                CreatedAt = DateTime.Parse(bookline[5])
            };

            ls.Add(book);
        }
        return ls;
    }

    public Task<Book> SelectByAsync(int id)
    {
        throw new NotImplementedException();
    }
}
