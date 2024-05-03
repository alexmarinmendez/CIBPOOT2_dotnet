using Microsoft.AspNetCore.Mvc.Rendering;

namespace CIBPOOT2.Models.ViewModels
{
    public class ProductoVM
    {
        public Producto oProducto { get; set; }

        public List<SelectListItem> oListaCategoria { get; set; }
    }
}
