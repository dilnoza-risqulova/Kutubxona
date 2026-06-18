using Kutubxona.Service.DTOs;

namespace Kutubxona.Service.Interfaces;

public interface IBookService
{
    public Task<BookResultDto> CreateAsync(BookCreationDto bookCreationDto);
    public Task<BookResultDto> UpdateAsync(int id, BookCreationDto bookCreationDto);
    public Task<bool> DeleteAsync(int id);
    public Task<BookResultDto> GetByIdAsync(int id);
    public Task<IEnumerable<BookResultDto>> GetAllAsync();
}