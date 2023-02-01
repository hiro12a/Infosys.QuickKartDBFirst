﻿using System;
using System.Collections.Generic;

namespace Infosys.DBFirstCore.DataAccessLayer.Models;

public partial class Category
{
    public byte CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
