using System;
using System.Collections.Generic;

namespace CIBPOOT2.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public int? Stock { get; set; }

    public decimal? Precio { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int? IdCategoria { get; set; }

    public virtual Categoria? oCategoria { get; set; }
}
