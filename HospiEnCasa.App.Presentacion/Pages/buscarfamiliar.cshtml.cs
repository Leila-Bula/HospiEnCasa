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
    public class buscarfamiliarModel : PageModel
    {

        public readonly IRepositorioFamiliarDesignado repoFamiliar;
        [BindProperty]
        public IEnumerable<FamiliarDesignado> Familiares {get;set;}

        public buscarfamiliarModel(IRepositorioFamiliarDesignado RepositorioFamiliar){
            repoFamiliar = RepositorioFamiliar;
        }

        public void OnGet()
        {
        Familiares=repoFamiliar.GetAllfamiliar();
        }
    }
}
