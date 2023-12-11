using System;
using System.Collections.Generic;

namespace SistemaFacturacion.Model;

public partial class Producto
{
    public string? Item { get; set; }

    public string? Descripcion { get; set; }

    public int? CantidadEnExistencia { get; set; }

    public double? Costo { get; set; }

    public double? PrecioDeVenta { get; set; }

    public double? Impuesto { get; set; }

    public int? EstatusProducto { get; set; }

    public string? BarCode { get; set; }

    public byte[]? Imagen { get; set; }

    public string? Ruta { get; set; }
}
