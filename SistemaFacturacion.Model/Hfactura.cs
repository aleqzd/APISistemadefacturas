using System;
using System.Collections.Generic;

namespace SistemaFacturacion.Model;

public partial class Hfactura
{
    public string? Factura { get; set; }

    public string? Cliente { get; set; }

    public string? Fecha { get; set; }

    public double? Subtotal { get; set; }

    public double? Impuesto { get; set; }

    public double? Montofacturado { get; set; }
}
