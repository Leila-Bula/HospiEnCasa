using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Presentacion.Pages
{
    public class MedicoModel : PageModel
    {
        public readonly IRepositorioMedico repositorioMedico;
        [BindProperty]
        public Medico NuevoMedico {get;set;} 
        public bool isAdded {get;set;}
        public bool Post {get;set;}

        public MedicoModel(IRepositorioMedico repositorioMedico)
        {
          this.repositorioMedico = repositorioMedico;
            NuevoMedico = new Medico();
            Post=false;
        }

        public void OnPost()
        {
            NuevoMedico = repositorioMedico.AddMedico(NuevoMedico);
            Post=true;
            if(NuevoMedico!=null){
                isAdded=true;
            }else{
                isAdded=false;
            }
        }
    }
}