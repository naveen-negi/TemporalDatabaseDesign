namespace ProductPricing.API.Entities;

public class TriggerLog
{
    public TriggerLog(Guid id, string tableName, string action)
    {
        Id = id;
        TableName = tableName;
        Action = action;
    }

    public Guid Id { get; private set; }
    public string TableName { get; private set; }
    public string Action { get; private set; }
    public DateTime ActionTime { get; private set; } = DateTime.Now;
}