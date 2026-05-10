using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Interfaces;

public interface IGradeRepository
{
    Task<Grade?> GetByIdAsync(int id);

    // IReadOnlyCollection expresses that the returned collection should not be modified.
    // It also provides a more explicit contract than IEnumerable.
    Task<IReadOnlyCollection<Grade>> GetAllAsync();
}