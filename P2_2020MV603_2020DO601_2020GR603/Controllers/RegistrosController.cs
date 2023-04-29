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

        public IActionResult CrearRegistros(Casos_Reportados nuevoRegistro)
        {
            _casosDbContext.Add(nuevoRegistro);
            _casosDbContext.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Index()
        {
            var listadeCasos = (from e in _casosDbContext.Casos_Reportados
                                 join m in _casosDbContext.Departamento on e.id_departamento equals m.id_Departamento
                                 join n in _casosDbContext.Genero on e.id_genero equals n.id_Genero
                                 select new
                                 {
                                     nombre_departamento = m.nombre_Departamento,
                                     nombre_genero = n.Tipo_Genero,
                                     casos_confirmados = e.casos_Confirmados,
                                     recuperados = e.casos_Recuperados,
                                     fallecidos = e.casos_Fallecidos
                                 }).ToList();

            ViewData["listadodeCasos"] = listadeCasos;

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
