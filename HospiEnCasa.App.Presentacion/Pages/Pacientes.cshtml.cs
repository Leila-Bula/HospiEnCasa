using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Presentacion
{
    public class PacientesModel : PageModel
    {

        public readonly IRepositorioPaciente repoPaciente;
        [BindProperty]
        public IEnumerable<Paciente> Pacientes {get;set;}

        public PacientesModel(IRepositorioPaciente repositorioPaciente){
            repoPaciente = repositorioPaciente;
        }

        public void OnGet()
        {
            Pacientes=repoPaciente.GetAllPacientes();
        }
    }
}
