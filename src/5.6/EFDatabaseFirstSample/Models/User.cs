﻿using System;
using System.Collections.Generic;

namespace EFDatabaseFirstSample.Models;

public partial class User
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual UserProfile? UserProfile { get; set; }
}
