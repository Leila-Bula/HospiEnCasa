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
        public readonly IRepositorioFamiliarDesignado repoFamiliar;
        [BindProperty]
        public FamiliarDesignado NuevoFamiliar {get; set;}
        [BindProperty]
        public int idPaciente {get;set;}
        public bool isAdded {get;set;}
        public bool Post {get;set;}
        public string Action {get;set;}

        public FamiliarDesignadoModel(IRepositorioFamiliarDesignado RepositorioFamiliar){
            repoFamiliar = RepositorioFamiliar;
            
            Post=false;
        }

         public IActionResult OnGet(int? idFamiliar){
            if(idFamiliar.HasValue){
                NuevoFamiliar=repoFamiliar.GetFamiliar(idFamiliar.Value);
                Action = "Actualizar";
            }else{
                NuevoFamiliar = new FamiliarDesignado();
                Action="Registrar";
            }
            return Page();
        }

        public void OnPost(){
            if(Action=="Registrar"){
                NuevoFamiliar= repoFamiliar.AddFamiliar(NuevoFamiliar, idPaciente);
                Post=true;
                if(NuevoFamiliar!=null){
                    isAdded=true;
                }else{
                    isAdded=false;
                }
            }else{
                NuevoFamiliar = repoFamiliar.UpdateFamiliar(NuevoFamiliar);
                Post=true;
                if(NuevoFamiliar!=null){
                    isAdded=true;
                }else{
                    isAdded=false;
                }
             }
        
        }
        
    }
}
