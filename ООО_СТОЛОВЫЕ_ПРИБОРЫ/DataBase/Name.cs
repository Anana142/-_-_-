using System;
using System.Collections.Generic;

namespace ООО_СТОЛОВЫЕ_ПРИБОРЫ.DataBase;

public partial class Name
{
    public int NameId { get; set; }

    public string NameTitle { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
