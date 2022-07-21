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
    public class SignoVitalModel : PageModel
    {
        public readonly IRepositorioSigno repositorioSignoVital;
        [BindProperty]       
        public SignoVital NuevoSigno {get;set;} 
        public bool isAdded {get;set;}
        public bool Post {get;set;}

        public SignoVitalModel(IRepositorioSigno repositorioSignoVital)
        {
          this.repositorioSignoVital = repositorioSignoVital;
            NuevoSigno = new List<SignoVital> {
                new SignoVital {FechaHora = NuevoSigno.FechaHora,Valor =NuevoSigno.Valor, Signo = NuevoSigno.TipoSigno}

            };

            Post=false;
        }

        public void OnPost()
        {
            NuevoSigno = repositorioSignoVital.AddSignoVital(NuevoSigno);
            Post=true;
            if(NuevoSigno!=null){
                isAdded=true;
            }else{
                isAdded=false;
            }
        }
    }
}