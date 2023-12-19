using System;
using System.Collections.Generic;

namespace ООО_СТОЛОВЫЕ_ПРИБОРЫ.DataBase;

public partial class Manufacturer
{
    public int ManufacturerId { get; set; }

    public string ManufacturerName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
