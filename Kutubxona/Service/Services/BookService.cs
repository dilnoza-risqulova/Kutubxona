using Kutubxona.Data.IRepositories;
using Kutubxona.Data.Repositories;
using Kutubxona.Domain.Entities;
using Kutubxona.Service.DTOs;
using Kutubxona.Service.Exceptions;
using Kutubxona.Service.Interfaces;

namespace Kutubxona.Service.Services;

public class BookService : IBookService
{
    IBookRepository repository;
    private int _id;

    public BookService()
    {
        repository = new BookRepository();

        var books = repository.SelectAllAsync().Result.ToList();

        if (books.Count == 0)
        {
            _id = 1;
        }
        else
        {
            _id = books.LastOrDefault().Id + 1;
        }
    }
    public async Task<BookResultDto> CreateAsync(BookCreationDto dto)
    {
        var book = repository.
        SelectAllAsync().
        Result.
        FirstOrDefault(x => x.Author == dto.Author &&
        x.Title == dto.Title);

        if (book is null)
        {
            throw new CustomException("This book already exist", 404);
        }

        var newBook = new Book
        {
            Id = _id,
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

    public Task<IEnumerable<BookResultDto>> GetAllAsync()
    {
        throw new NotImplementedException();
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
