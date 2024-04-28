﻿namespace DatabaseSeed.Models;

public class UserTest
{
    public Guid UserId { get; set; }
    public DatabaseSeed.Models.User.User User { get; set; } = null!;

    public Guid TestId { get; set; }
    public DatabaseSeed.Models.Test.Test Test { get; set; } = null!;

    public float UserScore { get; set; }
    public float TotalScore { get; set; }
    public DateTime StartingTime { get; set; }
    public DateTime EndingTime { get; set; }
    public UserTestStatus UserTestStatus { get; set; }
}