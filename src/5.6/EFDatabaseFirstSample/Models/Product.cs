using System;
using System.Collections.Generic;

namespace EFDatabaseFirstSample.Models;

public partial class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public Guid OrderId { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}
