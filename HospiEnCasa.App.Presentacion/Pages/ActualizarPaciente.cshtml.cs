using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Presentacion.Pages {
    public class ActualizarPacienteModel : PageModel {

        public readonly IRepositorioPaciente repoPaciente;
        [BindProperty]
        public Paciente NuevoPaciente {get; set;}

        public ActualizarPacienteModel(IRepositorioPaciente repositorioPaciente){
            repoPaciente = repositorioPaciente;
        }

        public IActionResult OnGet(int? idPaciente){
                NuevoPaciente=repoPaciente.GetPaciente(idPaciente.Value);
            return Page();
        }

        public IActionResult OnPost(){

            NuevoPaciente=repoPaciente.UpdatePaciente(NuevoPaciente);
            return Page();
        }
    }
}
