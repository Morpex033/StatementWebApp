using StatementWebApp.Core.Dto;
using StatementWebApp.Core.Entity;

namespace StatementWebApp.Core.Interface;

public interface IGradeRepository
{
    Task<List<Grade>> GetGradesAsync(CancellationToken cancellationToken);
    Task<Grade> GetGradeByIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task<Grade> AddGradeAsync(CreateGradeDto grade, CancellationToken cancellationToken);
    Task<Grade> UpdateGradeAsync(UpdateGradeDto grade, CancellationToken cancellationToken);
    Task DeleteGradeAsync(Guid id, CancellationToken cancellationToken);
}