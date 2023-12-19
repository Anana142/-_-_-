using System;
using System.Collections.Generic;

namespace ООО_СТОЛОВЫЕ_ПРИБОРЫ.DataBase;

public partial class Order
{
    public int OrderId { get; set; }

    public int OrderStatusId { get; set; }

    public DateTime OrderDeliveryDate { get; set; }

    public int OrderPickupPointId { get; set; }

    public DateTime OrderOrderData { get; set; }

    public int OrderReceiptCode { get; set; }

    public int? OrderUserId { get; set; }

    public virtual PickupPoint OrderPickupPoint { get; set; } = null!;

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    public virtual Status OrderStatus { get; set; } = null!;

    public virtual User? OrderUser { get; set; }
}
