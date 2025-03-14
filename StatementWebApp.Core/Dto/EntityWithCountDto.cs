namespace StatementWebApp.Core.Dto;

public class EntityWithCountDto<T>
{
    public List<T> Data { get; set; }
    public int TotalCount { get; set; }

    public EntityWithCountDto()
    {
        Data = new List<T>();
        TotalCount = 0;
    }
}
