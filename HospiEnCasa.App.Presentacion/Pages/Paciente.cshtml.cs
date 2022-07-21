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
        public bool isAdded {get;set;}
        public bool Post {get;set;}

        public PacienteModel(IRepositorioPaciente repositorioPaciente){
            repoPaciente = repositorioPaciente;
            Post=false;
        }

        public IActionResult OnGet(int? idPaciente){
            if(idPaciente.HasValue){
                NuevoPaciente=repoPaciente.GetPaciente(idPaciente.Value);
            }else{
                NuevoPaciente = new Paciente(); 
            }
            return Page();
        }

        public void OnPost(){
            NuevoPaciente=repoPaciente.AddPaciente(NuevoPaciente);
            Post=true;
            if(NuevoPaciente!=null){
                isAdded=true;
            }else{
                isAdded=false;
            }
        }
    }
}
