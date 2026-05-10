using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Interfaces;

public interface IGradeService
{
    Task<Grade?> GetByIdAsync(int id);

    Task<IReadOnlyCollection<Grade>> GetAllAsync();

    Task<IReadOnlyCollection<Grade>> GetFirstPassingActiveGradesAsync(int count);
}