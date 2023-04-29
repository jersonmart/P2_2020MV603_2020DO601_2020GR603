using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using P2_2020MV603_2020DO601_2020GR603.Models;

namespace P2_2020MV603_2020DO601_2020GR603.Controllers
{
    public class RegistrosController : Controller
    {
        private readonly casosDbContext _casosDbContext;

        public RegistrosController(casosDbContext casosDbContext) 
        {
            _casosDbContext = casosDbContext;
        }
        public IActionResult Index()
        {
            var listadeGen = (from g in _casosDbContext.Genero
                              select g).ToList();
            ViewData["listadodeGen"] = new SelectList(listadeGen, "id_Genero", "Tipo_Genero");

            var listadeDepar = (from m in _casosDbContext.Departamento
                                select m).ToList();
            ViewData["listadodeDepar"] = new SelectList(listadeDepar, "id_Departamento", "nombre_Departamento");
            return View();

            
        }
    }
}
