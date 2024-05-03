using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CIBPOOT2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CIBPOOT2.Models.ViewModels;

namespace CIBPOOT2.Controllers
{
    public class HomeController : Controller
    {
        private readonly Cibpoot2Context _context;

        public HomeController(Cibpoot2Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Producto> lista = _context.Productos.Include(c => c.oCategoria).ToList();
            return View(lista);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Producto_Detalle(int idProducto)
        {
            ProductoVM oProductoVM = new ProductoVM()
            {
                oProducto = new Producto(),
                oListaCategoria = _context.Categoria.Select(categoria => new SelectListItem()
                {
                    Text = categoria.Nombre,
                    Value = categoria.IdCategoria.ToString()
                }).ToList()
            };

            if (idProducto != 0)
            {
                oProductoVM.oProducto = _context.Productos.Find(idProducto);
            }

            return View(oProductoVM);
        }

        [HttpPost]
        public IActionResult Producto_Detalle(ProductoVM oProductoVM)
        {
            if (oProductoVM.oProducto.IdProducto == 0)
            {
                oProductoVM.oProducto.FechaCreacion = DateTime.Now;
                _context.Productos.Add(oProductoVM.oProducto);
            }
            else
            {
                _context.Productos.Update(oProductoVM.oProducto);
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Eliminar(int idProducto)
        {
            Producto oProducto = _context.Productos.Include(c => c.oCategoria).Where(e => e.IdProducto == idProducto).FirstOrDefault();
            return View(oProducto);
        }

        [HttpPost]
        public IActionResult Eliminar(Producto oProducto)
        {
            _context.Productos.Remove(oProducto);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
