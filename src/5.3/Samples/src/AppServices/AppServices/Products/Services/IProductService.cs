﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Products.Services
{
    public interface IProductService
    {
        Task<IList<Product>> GetAllAsync(CancellationToken token);
    }
}
