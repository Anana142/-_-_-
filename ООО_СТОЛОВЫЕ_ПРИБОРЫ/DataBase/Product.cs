using System;
using System.Collections.Generic;

namespace ООО_СТОЛОВЫЕ_ПРИБОРЫ.DataBase;

public partial class Product
{
    public string ProductArticleNumber { get; set; } = null!;

    public int ProductNameId { get; set; }

    public string ProductDescription { get; set; } = null!;

    public int ProductCategoryId { get; set; }

    public byte[]? ProductPhoto { get; set; }

    public int ProductManufacturerId { get; set; }

    public decimal ProductCost { get; set; }

    public byte? ProductDiscountAmount { get; set; }

    public int ProductQuantityInStock { get; set; }

    public int ProductUnitId { get; set; }

    public int? ProductMaxDiscount { get; set; }

    public int ProductProviderId { get; set; }

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    public virtual Category ProductCategory { get; set; } = null!;

    public virtual Manufacturer ProductManufacturer { get; set; } = null!;

    public virtual Name ProductName { get; set; } = null!;

    public virtual Provider ProductProvider { get; set; } = null!;

    public virtual Unit ProductUnit { get; set; } = null!;
}
