namespace Siemens.Internship2026.GradeBook.Models;
// Using 'record' instead of 'class' because Grade is a simple data model.
// Records provide a more compact syntax and built-in value-based equality.
public record Grade(int Id, decimal Value, bool IsActive = true);