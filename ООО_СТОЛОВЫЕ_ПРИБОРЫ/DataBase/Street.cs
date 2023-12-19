using System;
using System.Collections.Generic;

namespace ООО_СТОЛОВЫЕ_ПРИБОРЫ.DataBase;

public partial class Street
{
    public int StreetId { get; set; }

    public string StreetName { get; set; } = null!;

    public virtual ICollection<PickupPoint> PickupPoints { get; set; } = new List<PickupPoint>();
}
