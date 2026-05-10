using Siemens.Internship2026.GradeBook.Interfaces;
using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Services;

// Primary constructor is used to inject the repository dependency directly.
public class GradeService(IGradeRepository gradeRepository) : IGradeService
{
    public async Task<Grade?> GetByIdAsync(int id)
    {
        var grade = await gradeRepository.GetByIdAsync(id);

        // Property pattern matching keeps the active-grade check concise and readable.
        return grade is { IsActive: true } ? grade : null;
    }

    public async Task<IReadOnlyCollection<Grade>> GetAllAsync()
    {
        var grades = await gradeRepository.GetAllAsync();

        return grades
            .Where(g => g.IsActive)
            .ToList();
    }

    public async Task<IReadOnlyCollection<Grade>> GetFirstPassingActiveGradesAsync(int count)
    {
        var grades = await gradeRepository.GetAllAsync();

        return grades
            .Where(g => g.IsActive && g.Value >= 5)
            .Take(count)
            .ToList();
    }
}