using System;
using System.Collections.Generic;

namespace ООО_СТОЛОВЫЕ_ПРИБОРЫ.DataBase;

public partial class City
{
    public int CityId { get; set; }

    public string CityName { get; set; } = null!;

    public virtual ICollection<PickupPoint> PickupPoints { get; set; } = new List<PickupPoint>();
}
