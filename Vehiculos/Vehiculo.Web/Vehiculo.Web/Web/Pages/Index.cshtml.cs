using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguracion _configuracion;
        public IList<VehiculoResponse> vehiculos { get; set; } = default!;
        public IndexModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        public  void OnGet()
        {
            
        }
    }
}
