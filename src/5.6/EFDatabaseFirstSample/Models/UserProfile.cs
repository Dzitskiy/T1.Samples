using System;
using System.Collections.Generic;

namespace EFDatabaseFirstSample.Models;

public partial class UserProfile
{
    public Guid Id { get; set; }

    public string Address { get; set; } = null!;

    public Guid UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
