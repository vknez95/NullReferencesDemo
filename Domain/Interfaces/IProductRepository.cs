﻿using System.Collections.Generic;
using NullReferencesDemo.Common;

namespace NullReferencesDemo.Domain.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<IProduct> GetAll();
        Option<IProduct> TryFind(string name);
    }
}
