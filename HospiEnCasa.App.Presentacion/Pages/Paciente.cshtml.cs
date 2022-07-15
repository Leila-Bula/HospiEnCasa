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
    public class PacienteModel : PageModel {

        public readonly IRepositorioPaciente repoPaciente;
        [BindProperty]
        public Paciente NuevoPaciente {get; set;}

        public PacienteModel(IRepositorioPaciente repositorioPaciente){
            repoPaciente = repositorioPaciente;
            NuevoPaciente = new Paciente();
        }

        /*public void OnGet(){
            //Pacientes=repoPaciente.GetAllPacientes();
        }*/

        public void OnPost(){
            NuevoPaciente=repoPaciente.AddPaciente(NuevoPaciente);
        }
    }
}
