using DatabaseSeed.Models.Test;

namespace DatabaseSeed.Models;

public class UserQuestion
{
    public Guid UserId { get; set; }
    public DatabaseSeed.Models.User.User User { get; set; } = null!;
    
    public Guid QuestionId { get; set; }
    public Question Question { get; set; } = null!;

    public DateTime CreatedTimestamp { get; set; }
}