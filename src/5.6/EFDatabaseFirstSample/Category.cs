﻿using EFDatabaseFirstSample.Models;
using System;
using System.Collections.Generic;

namespace EFDatabaseFirstSample;

public partial class Category
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
