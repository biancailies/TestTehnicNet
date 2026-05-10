using Microsoft.AspNetCore.Mvc;
using Siemens.Internship2026.GradeBook.Interfaces;

namespace Siemens.Internship2026.GradeBook.Controllers;

[ApiController]
[Route("api/[controller]")]
// Primary constructor injection reduces boilerplate and keeps dependencies explicit.
public class GradesController(IGradeService gradeService, ILogger<GradesController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        logger.LogInformation("GET api/grades called");

        return Ok(await gradeService.GetAllAsync());
    }

    [HttpGet("{id:int:min(1)}")]
    public async Task<IActionResult> GetById(int id)
    {
        logger.LogInformation("GET api/grades/{Id} called", id);

        var grade = await gradeService.GetByIdAsync(id);

        return grade is not null
            ? Ok(grade)
            : NotFound($"Grade with Id {id} was not found.");
    }

    [HttpGet("passing-active")]
    public async Task<IActionResult> GetFirstPassingActiveGrades([FromQuery] int count)
    {
        logger.LogInformation("GET api/grades/passing-active called with count {Count}", count);

        if (count <= 0)
        {
            return BadRequest("Count must be positive.");
        }

        return Ok(await gradeService.GetFirstPassingActiveGradesAsync(count));
    }
}