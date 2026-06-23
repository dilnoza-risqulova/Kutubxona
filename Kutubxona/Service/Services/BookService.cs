using Kutubxona.Data.IRepositories;
using Kutubxona.Data.Repositories;
using Kutubxona.Domain.Entities;
using Kutubxona.Service.DTOs;
using Kutubxona.Service.Exceptions;
using Kutubxona.Service.Interfaces;
using Kutubxona.Service.Services;

namespace Kutubxona.Service.Services;

public class BookService : IBookService
{
    IBookRepository repository=new BookRepository;
    private int _id=1;

    public async Task<BookResultDto> CreateAsync(BookCreationDto dto)
    {
        var book = await repository.SelectAllAsync().
       
        var book = BookService.FirstOrDefault(x=> x.Author == dto.Author);
        x.Title == dto.Title};

        if (book is not null)
        {
            throw new CustomException("This book already exist", 404);
        }

        var newBook = new Book
        {
            Id = _id++,
            Author = dto.Author,
            Title = dto.Title,
            Year = dto.Year,
            CreatedAt = DateTime.Now
        };

        await repository.InsertAsync(newBook);

        return new BookResultDto
        {
            Id = _id,
            Author = dto.Author,
            Title = dto.Title,
            Year = dto.Year,
        };
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<BookResultDto>> GetAllAsync()
    {
    var books = await repository.SelectAllAsync();
    var ls = new List<BookResultDto>();
        
    foreach (var book in books)
    {
        var resBook = new BookReaultDto
        {
            Id = book.Id,
            Author = book.Author,
            Title = book.Title,
            Year = book.Rear
        };
        ls.Add(resBook);
    }
    return ls;
    }

    public Task<BookResultDto> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<BookResultDto> UpdateAsync(int id, BookCreationDto bookCreationDto)
    {
        throw new NotImplementedException();
    }
}
