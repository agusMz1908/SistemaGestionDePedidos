using Microsoft.AspNetCore.Mvc;
using ContadorHandy.AccesoDatos.Repository.IRepository;
using ContadorHandy.Modelos;
using Microsoft.EntityFrameworkCore;
using ContadorHandy.Utils;

namespace ContadorHandy.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PedidoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PedidoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(string sortOrder, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NumeroSortParam"] = string.IsNullOrEmpty(sortOrder) ? "numero_desc" : "";
            ViewData["DateSortParam"] = sortOrder == "Date" ? "date_desc" : "Date";

            var pedidos = _unitOfWork.Pedido.GetAll();

            if (!string.IsNullOrEmpty(searchString))
            {
                pedidos = pedidos.Where(p => p.Numero.ToString().Contains(searchString));
            }

            switch (sortOrder)
            {
                case "numero_desc":
                    pedidos = pedidos.OrderByDescending(p => p.Numero);
                    break;
                case "Date":
                    pedidos = pedidos.OrderBy(p => p.FechaIngreso);
                    break;
                case "date_desc":
                    pedidos = pedidos.OrderByDescending(p => p.FechaIngreso);
                    break;
                default:
                    pedidos = pedidos.OrderBy(p => p.Numero);
                    break;
            }

            int pageSize = 12;
            return View(PaginatedList<Pedido>.Create(pedidos.AsNoTracking(), pageNumber ?? 1, pageSize));

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                pedido.FechaIngreso = DateTime.Now;
                _unitOfWork.Pedido.Add(pedido);
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }

            return View(pedido);
        }

        public IActionResult Details(int id)
        {
            var pedido = _unitOfWork.Pedido.Get(p => p.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        public IActionResult PartialDelivery(int id)
        {
            var pedido = _unitOfWork.Pedido.Get(p => p.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PartialDelivery(int id, int entregadosAntel, int entregadosMovistar, int entregadosClaro, int entregadosETH)
        {
            var pedido = _unitOfWork.Pedido.Get(p => p.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            pedido.EntregadosAntel += entregadosAntel;
            pedido.EntregadosMovistar += entregadosMovistar;
            pedido.EntregadosClaro += entregadosClaro;
            pedido.EntregadosETH += entregadosETH;

            if (pedido.Pendientes == 0 && pedido.FechaFinalizado == null)
            {
                pedido.FechaFinalizado = DateTime.Now;   
            }

            _unitOfWork.Save();

            return RedirectToAction("Details", new { id });
        }

        public IActionResult Delete(int id)
        {
            var pedido = _unitOfWork.Pedido.Get(p => p.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int id)
        {
            var pedido = _unitOfWork.Pedido.Get(p => p.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            try
            {
                _unitOfWork.Pedido.Remove(pedido);
                _unitOfWork.Save();
                TempData["success"] = "Pedido Eliminado con exito";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = "Se produjo un error al eliminar el pedido" + ex.Message;
            }

            return View();
        }
    }
}
