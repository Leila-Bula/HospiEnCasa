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
    public class FamiliarDesignadoModel : PageModel
    {
        public readonly IRepositorioFamiliarDesignado RepositorioFamiliar;
        [BindProperty]
        public FamiliarDesignado NuevoFamiliar {get; set;}
        [BindProperty]
        public int idPaciente {get;set;}

        public FamiliarDesignadoModel(IRepositorioFamiliarDesignado RepositorioFamiliar){
            this.RepositorioFamiliar = RepositorioFamiliar;
            NuevoFamiliar = new FamiliarDesignado();
        }
        public void OnPost(){
            NuevoFamiliar= RepositorioFamiliar.AddFamiliar(NuevoFamiliar, idPaciente);
        }
    }
}
