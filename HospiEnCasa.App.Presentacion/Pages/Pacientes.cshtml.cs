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
        public List<Paciente> Pacientes {get;set;}

        public void OnGet()
        {
            Pacientes = new List<Paciente>();
            Pacientes.Add(new Paciente{
                Nombre="Nicolay",
                Apellidos="Perez",
                Telefono ="3001645",
                Genero = Genero.masculino,
                Direccion = "Calle 4 No 7-4",
                Longitud = 5.07062F,
                Latitud = 75.52290F,
                Ciudad = "Manizales",
                FechaNacimiento = new DateTime(1990, 04, 12)
            });
        }
    }
}
