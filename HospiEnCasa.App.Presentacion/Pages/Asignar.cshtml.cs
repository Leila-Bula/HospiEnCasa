using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Presentacion.Pages
{
    public class AsignarModel : PageModel
    {
        public readonly IRepositorioMedico repositorioMedico;
        public IEnumerable<Medico> Medicos {get;set;}
        public int IdPaciente {get;set;}

        public AsignarModel(IRepositorioMedico repositorioMedico){
            this.repositorioMedico=repositorioMedico;
        }
        public IActionResult OnGet(int? idPaciente)
        {
            if(idPaciente.HasValue){
                Medicos = repositorioMedico.GetAllMedico();
                IdPaciente = idPaciente.Value;
            }
            return Page();
        }
    }
}
