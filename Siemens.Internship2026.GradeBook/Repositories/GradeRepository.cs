using System.Net.Http.Json;
using Siemens.Internship2026.GradeBook.Interfaces;
using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Repositories;

public class GradeRepository(HttpClient httpClient) : IGradeRepository
{
    private const string GradesUrl =
        "https://gist.githubusercontent.com/ArdeleanTudor/8ea407832cd9794960e0e6bbd1319f6e/raw";

    public async Task<Grade?> GetByIdAsync(int id)
    {
        var grades = await GetAllAsync();

        return grades.FirstOrDefault(g => g.Id == id);
    }

    public async Task<IReadOnlyCollection<Grade>> GetAllAsync()
    {
        var response = await httpClient.GetFromJsonAsync<GradeResponse>(GradesUrl);

        return response?.Items ?? [];
    }

    private sealed record GradeResponse(IReadOnlyCollection<Grade> Items);
}