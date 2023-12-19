using System;
using System.Collections.Generic;

namespace ООО_СТОЛОВЫЕ_ПРИБОРЫ.DataBase;

public partial class PickupPoint
{
    public int PickupPointId { get; set; }

    public int? PickupPointIndex { get; set; }

    public int? PickupPointCityId { get; set; }

    public int? PickupPointStreetId { get; set; }

    public int? PickupPointHouseId { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual City? PickupPointCity { get; set; }

    public virtual Street? PickupPointStreet { get; set; }
}
