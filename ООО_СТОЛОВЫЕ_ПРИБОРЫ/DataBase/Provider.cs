using System;
using System.Collections.Generic;

namespace ООО_СТОЛОВЫЕ_ПРИБОРЫ.DataBase;

public partial class Provider
{
    public int ProviderId { get; set; }

    public string ProviderName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
