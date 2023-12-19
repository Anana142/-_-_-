using System;
using System.Collections.Generic;

namespace ООО_СТОЛОВЫЕ_ПРИБОРЫ.DataBase;

public partial class Status
{
    public int StatusId { get; set; }

    public string? StatusName { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
