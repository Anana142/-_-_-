using System;
using System.Collections.Generic;

namespace ООО_СТОЛОВЫЕ_ПРИБОРЫ.DataBase;

public partial class Unit
{
    public int UnitId { get; set; }

    public string UnitName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
